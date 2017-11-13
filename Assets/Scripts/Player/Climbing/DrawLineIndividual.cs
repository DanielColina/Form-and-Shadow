#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;

namespace Climbing
{
    [ExecuteInEditMode]
    public class DrawLineIndividual : MonoBehaviour
    {
        public List<Neighbor> connectedPoints = new List<Neighbor>();

        public bool refresh;

        void Update()
        {
            if (refresh)
            {
                connectedPoints.Clear();
                refresh = false;
            }
        }
    }
}
#endif