#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;

namespace Climbing
{
    [ExecuteInEditMode]
    public class DrawWireSphere : MonoBehaviour
    {
        public List<IKPositions> ikPos = new List<IKPositions>();

        public bool refresh;

        void Update()
        {
            if(refresh)
            {
                ikPos.Clear();
                refresh = false;
            }
        }
    }
}
#endif