using UnityEngine;
using System.Collections.Generic;

namespace Climbing
{
    [System.Serializable]
    public class Point : MonoBehaviour
    {
        public List<Neighbor> neighbors = new List<Neighbor>();
        public List<IKPositions> iks = new List<IKPositions>();

        public IKPositions ReturnIK(AvatarIKGoal goal)
        {
            IKPositions returnIKValue = null;

            foreach(IKPositions ikPos in iks)
            {
                if(ikPos.ik == goal)
                {
                    returnIKValue = ikPos;
                    break;
                }
            }
            return returnIKValue;
        }


        public Neighbor ReturnNeighbor(Point target)
        {
            Neighbor returnNeighborValue = null;

            foreach(Neighbor neighbor in neighbors)
            {
                if(neighbor.target == target)
                {
                    returnNeighborValue = neighbor;
                }
            }
            return returnNeighborValue;
        }
    }


    [System.Serializable]
    public class IKPositions
    {
        public AvatarIKGoal ik;
        public Transform target;
        public Transform hint;
    }

    [System.Serializable]
    public class Neighbor
    {
        public Vector3 direction;
        public Point target;
        public ConnectionType connectionType;
    }

    public enum ConnectionType
    {
        Inbetween, Direct, Dismount, Fall
    }
}

