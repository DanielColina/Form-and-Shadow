using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

namespace FormandShadow
{
    public class PlayerCamera : MonoBehaviour
    {
        /// <summary>
        /// Sets the follow transform for the attached CinemachineCamera
        /// </summary>
        /// <param name="follow">The transform to follow</param>
        public void SetFollowTransform(Transform follow)
        {
            Debug.Log("Settin' follow target to: " + follow.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collider"></param>
        public void AddIgnoredColliders(Collider[] collider)
        {
            Debug.Log("Adding " + collider.ToString() + " to ignored colliders");
        }
    }
}
