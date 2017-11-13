﻿using UnityEngine;
using System.Collections;

namespace Climbing
{
    public class EnableRootMovement : StateMachineBehaviour
    {
        ClimbEvents ce;

        public float timer = 0.2f;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (ce == null)
            {
                ce = animator.transform.parent.GetComponent<ClimbEvents>();
            }

            if (ce == null)
                return;
            
            ce.EnableRootMovement(timer);
        }

    }
}
