using UnityEngine;
using System.Collections.Generic;

namespace Climbing
{
    public class ClimbManager : MonoBehaviour
    {
        public List<Point> allPoints = new List<Point>();

        void Start()
        {
            PopulateAllPoints();
        }

        void PopulateAllPoints()
        {
            Point[] points = GetComponentsInChildren<Point>();

            foreach(Point point in points)
            {
                if (!allPoints.Contains(point))
                    allPoints.Add(point);
            }
        }

        public Neighbor ReturnNeighbor(Vector3 inputDirection, Point currentPoint)
        {
            Neighbor neighbor = null;

            foreach(Neighbor currentNeighbor in currentPoint.neighbors)
            {
                if(currentNeighbor.direction == inputDirection)
                {
                    neighbor = currentNeighbor;
                }
            }
            return neighbor;
        }

        public Point ReturnClosest(Vector3 from)
        {
            Point closestPoint = null;

            float minDist = Mathf.Infinity;

            foreach(Point currentPoint in allPoints)
            {
                float dist = Vector3.Distance(currentPoint.transform.position, from);

                if(dist < minDist)
                {
                    closestPoint = currentPoint;
                    minDist = dist;
                }
            }

            return closestPoint;
        }
    }
}
