#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Climbing
{
    [ExecuteInEditMode]
    public class HandlePointsConnections : MonoBehaviour
    {
        public float minDistance = 2.5f;
        public float directThreshold = 1;
        public bool updateConnections = false;
        public bool resetConnections;

        List<Point> allPoints = new List<Point>();
        Vector3[] availableDirections = new Vector3[8];


        void Start()
        {
            updateConnections = false;
        }

        void Update()
        {
            if(updateConnections)
            {
                GetPoints();
                CreateDirections();
                CreateConnections();
                FindDismountCandidates();
                RefreshAll();

                updateConnections = false;
            }

            if(resetConnections)
            {
                GetPoints();
                foreach (Point currentPoint in allPoints)
                    currentPoint.neighbors.Clear();
                RefreshAll();
                resetConnections = false;
            }
        }

        void GetPoints()
        {
            allPoints.Clear();
            Point[] hp = GetComponentsInChildren<Point>();
            allPoints.AddRange(hp);
        }

        void CreateDirections()
        {
            availableDirections[0] = new Vector3(1, 0, 0);
            availableDirections[1] = new Vector3(-1, 0, 0);
            availableDirections[2] = new Vector3(0, 1, 0);
            availableDirections[3] = new Vector3(0, -1, 0);
            availableDirections[4] = new Vector3(-1, -1, 0);
            availableDirections[5] = new Vector3(1, 1, 0);
            availableDirections[6] = new Vector3(1, -1, 0);
            availableDirections[7] = new Vector3(-1, 1, 0);
        }

        void CreateConnections()
        {
            foreach(Point currentPoint in allPoints)
            {
                foreach (Vector3 availableDirection in availableDirections)
                {
                    List<Point> candidatePoints = CandidatePointsOnDirection(availableDirection, currentPoint);

                    Point closest = ReturnClosestPoint(candidatePoints, currentPoint);

                    if(closest != null)
                    {
                        if(Vector3.Distance(currentPoint.transform.position, closest.transform.position) < minDistance)
                        {
                            if(Mathf.Abs(availableDirection.y) > 0 && Mathf.Abs(availableDirection.x) > 0)
                            {
                                if (Vector3.Distance(currentPoint.transform.position, closest.transform.position) > directThreshold)
                                    continue;
                            }
                            AddNeighbor(currentPoint, closest, availableDirection);
                        }
                    }
                }
            }
        }

        List<Point> CandidatePointsOnDirection(Vector3 targetDirection, Point fromPoint)
        {
            List<Point> candidatePoints = new List<Point>();

            foreach(Point targetPoint in allPoints)
            {
                Vector3 direction = targetPoint.transform.position - fromPoint.transform.position;
                Vector3 relativeDirection = fromPoint.transform.InverseTransformDirection(direction);

                if(IsDirectionValid(targetDirection, relativeDirection))
                {
                    candidatePoints.Add(targetPoint);
                }
            }
            return candidatePoints;
        }

        bool IsDirectionValid(Vector3 targetDirection, Vector3 candidate)
        {
            bool directionIsValid = false;

            float targetAngle = Mathf.Atan2(targetDirection.x, targetDirection.y) * Mathf.Rad2Deg;
            float angle = Mathf.Atan2(candidate.x, candidate.y) * Mathf.Rad2Deg;

            if(angle < targetAngle + 22.5 && angle > targetAngle - 22.5)
            {
                directionIsValid = true;
            }
            return directionIsValid;
        }

        Point ReturnClosestPoint(List<Point> points, Point fromPoint)
        {
            Point closestPoint = null;

            float minDist = Mathf.Infinity;

            foreach(Point point in points)
            {
                float tempDist = Vector3.Distance(point.transform.position, fromPoint.transform.position);

                if(tempDist < minDist && point != fromPoint)
                {
                    minDist = tempDist;
                    closestPoint = point;
                }
            }
            return closestPoint;
        }

        void AddNeighbor(Point fromPoint, Point targetPoint, Vector3 targetDirection)
        {
            Neighbor neighbor = new Neighbor();
            neighbor.direction = targetDirection;
            neighbor.target = targetPoint;
            neighbor.connectionType = (Vector3.Distance(fromPoint.transform.position, targetPoint.transform.position) < directThreshold
                ? ConnectionType.Inbetween : ConnectionType.Direct);
            fromPoint.neighbors.Add(neighbor);

            UnityEditor.EditorUtility.SetDirty(fromPoint);
        }

        void RefreshAll()
        {
            DrawLine dl = transform.GetComponent<DrawLine>();

            if (dl != null)
                dl.refresh = true;

            foreach(Point currentPoint in allPoints)
            {
                DrawLineIndividual d = currentPoint.GetComponent<DrawLineIndividual>();
                if (d != null)
                    d.refresh = true;
            }
        }

        public List<Connection> GetAllConnections()
        {
            List<Connection> allConnections = new List<Connection>();
            foreach(Point currentPoint in allPoints)
            {
                foreach(Neighbor currentNeighbor in currentPoint.neighbors)
                {
                    Connection newConnection = new Connection();
                    newConnection.target1 = currentPoint;
                    newConnection.target2 = currentNeighbor.target;
                    newConnection.connectionType = currentNeighbor.connectionType;

                    if(!ContainsConnection(allConnections, newConnection))
                    {
                        allConnections.Add(newConnection);
                    }
                }
            }
            return allConnections;
        }

        bool ContainsConnection(List<Connection> connectionList, Connection checkConnection)
        {
            bool listContainsConnection = false;

            for(int i = 0; i < connectionList.Count; i++)
            {
                if(connectionList[i].target1 == checkConnection.target1 && connectionList[i].target2 == checkConnection.target2
                    || connectionList[i].target2 == checkConnection.target1 && connectionList[i].target1 == checkConnection.target2)
                {
                    listContainsConnection = true;
                    break;
                }
            }
            return listContainsConnection;
        }

        void FindDismountCandidates()
        {
            GameObject dismountPrefab = Resources.Load("Dismount_Point") as GameObject;

            HandlePoints[] handlePoints = GetComponentsInChildren<HandlePoints>();

            List<Point> dismountCandidates = new List<Point>();

            foreach(HandlePoints handlePoint in handlePoints)
            {
                if (handlePoint.dismountPoint)
                {
                    dismountCandidates.AddRange(handlePoint.pointsInOrder);
                }
            }

            if(dismountCandidates.Count > 0)
            {
                GameObject parentObj = new GameObject();
                parentObj.name = "Dismount Points";
                parentObj.transform.parent = transform;
                parentObj.transform.localPosition = Vector3.zero;

                foreach(Point point in dismountCandidates)
                {
                    Transform worldP = point.transform.parent;
                    GameObject dismountObject = Instantiate(dismountPrefab, worldP.position, worldP.rotation) as GameObject;
                    dismountObject.name = "Dismount_Point";
                    dismountObject.transform.position = worldP.position; ;

                    Point dismountPoint = dismountObject.GetComponentInChildren<Point>();

                    Neighbor dismountUpNeighbor = new Neighbor();
                    dismountUpNeighbor.direction = Vector3.up;
                    dismountUpNeighbor.target = dismountPoint;
                    dismountUpNeighbor.connectionType = ConnectionType.Dismount;
                    point.neighbors.Add(dismountUpNeighbor);

                    Neighbor dismountDownNeighbor = new Neighbor();
                    dismountDownNeighbor.direction = -Vector3.up;
                    dismountDownNeighbor.target = point;
                    dismountDownNeighbor.connectionType = ConnectionType.Dismount;
                    dismountPoint.neighbors.Add(dismountDownNeighbor);

                    dismountObject.transform.parent = parentObj.transform;
                }
            }
        }
    }

    public class Connection
    {
        public Point target1;
        public Point target2;
        public ConnectionType connectionType;
    }
}
#endif