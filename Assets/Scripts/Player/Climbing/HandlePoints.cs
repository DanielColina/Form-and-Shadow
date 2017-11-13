#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;

namespace Climbing
{
    [ExecuteInEditMode]
    public class HandlePoints : MonoBehaviour
    {
        [Header("Helper Properties")]
        public bool dismountPoint;
        public bool fallPoint;
        public bool hangingPoint;
        public bool singlePoint;

        [Header("Click after every change")]
        public bool updatePoints;

        [Header("Helper Utilities")]
        public bool deletePoints;
        public bool createEndPoints;

        public GameObject pointPrefab;
        float positionInterval = 0.5f;

        public Point furthestLeft;
        public Point furthestRight;

        public List<Point> pointsInOrder;

        void HandlePrefab()
        {
            pointPrefab = Resources.Load("Climb_Point") as GameObject;
        }

        void Update()
        {
            if(updatePoints)
            {
                HandlePrefab();
                UpdatePoints();
                updatePoints = false;
            }

            if(createEndPoints)
            {
                HandlePrefab();

                if (!singlePoint)
                    CreateEndPoints();
                else
                    CreateSingleEndPoint();

                createEndPoints = false;
            }

            if(deletePoints)
            {
                DeletePoints();
                deletePoints = false;
            }
        }

        void UpdatePoints()
        {
            Point[] points = GetComponentsInChildren<Point>();

            if(singlePoint)
            {
                pointsInOrder = new List<Point>();

                foreach(Point currentPoint in points)
                {
                    pointsInOrder.Add(currentPoint);
                }
                return;
            }

            if(points.Length < 1)
            {
                Debug.Log("No edge point indicators found!");
                return;
            }

            DeletePrevious(points, furthestLeft, furthestRight);

            points = null;
            points = GetComponentsInChildren<Point>();

            CreatePoints(furthestLeft, furthestRight);
        }

        void DeletePrevious(Point[] points, Point furthestLeft, Point furthestRight)
        {
            foreach (Point currentPoint in points)
            {
                if (currentPoint != furthestLeft && currentPoint != furthestRight)
                    DestroyImmediate(currentPoint.transform.parent.gameObject);
            }
        }

        void CreatePoints(Point furthestLeft, Point furthestRight)
        {
            float distanceLeftToRight = Vector3.Distance(GetPos(furthestLeft), GetPos(furthestRight));
            int pointCount = Mathf.FloorToInt(distanceLeftToRight / positionInterval);
            Vector3 direction = GetPos(furthestRight) - GetPos(furthestLeft);
            direction.Normalize();
            Vector3[] pointPositions = new Vector3[pointCount];

            float interval = 0;
            pointsInOrder = new List<Point>();
            pointsInOrder.Add(furthestLeft);

            for(int i = 0; i < pointCount; i++)
            {
                interval += positionInterval;
                pointPositions[i] = GetPos(furthestLeft) + (direction * interval);

                if(Vector3.Distance(pointPositions[i], GetPos(furthestRight)) > positionInterval - 0.1f)
                {
                    GameObject newPoint = Instantiate(pointPrefab, pointPositions[i], transform.rotation) as GameObject;
                    newPoint.name = "Middle_Point";
                    newPoint.transform.parent = transform;
                    pointsInOrder.Add(newPoint.GetComponentInChildren<Point>());
                }
                else
                {
                    furthestRight.transform.parent.transform.localPosition = transform.InverseTransformPoint(pointPositions[i]);
                    break;
                }
            }
            pointsInOrder.Add(furthestRight);
        }

        Vector3 GetPos(Point point)
        {
            return point.transform.parent.position;
        }

        void DeletePoints()
        {
            Point[] points = GetComponentsInChildren<Point>();
            pointsInOrder.Clear();

            foreach (Point currentPoint in points)
                DestroyImmediate(currentPoint.transform.parent.gameObject);
        }

        void CreateEndPoints()
        {
            GameObject leftPoint = Instantiate(pointPrefab, transform.position + -transform.InverseTransformDirection(Vector3.right / 2), transform.rotation, transform) as GameObject;
            GameObject rightPoint = Instantiate(pointPrefab, transform.position + transform.InverseTransformDirection(Vector3.right / 2), transform.rotation, transform) as GameObject;

            leftPoint.name = "Left_EndPoint";
            rightPoint.name = "Right_EndPoint";

            furthestLeft = leftPoint.GetComponentInChildren<Point>();
            furthestRight = rightPoint.GetComponentInChildren<Point>();
        }

        void CreateSingleEndPoint()
        {
            GameObject leftPoint = Instantiate(pointPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero), transform) as GameObject;
            furthestLeft = leftPoint.GetComponentInChildren<Point>();
        }
    }
}
#endif