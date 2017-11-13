#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;

namespace Climbing
{
    [ExecuteInEditMode]
    public class DrawLine : MonoBehaviour
    {
        public List<Connection> connectedPoints = new List<Connection>();

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
