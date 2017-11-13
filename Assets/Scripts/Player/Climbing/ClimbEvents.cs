using UnityEngine;
using System.Collections;

namespace Climbing
{
    public class ClimbEvents : MonoBehaviour
    {
        ClimbBehavior cb;

        void Start()
        {
            cb = GetComponent<ClimbBehavior>();
        }

        public void EnableRootMovement(float t)
        {
            StartCoroutine(Enable(t));
        }

        IEnumerator Enable(float t)
        {
            yield return new WaitForSeconds(t);
            cb.enableRootMovement = true;
        }
    }
}
