using UnityEngine;

public class PressureSwitch : Switch
{
    private SpringJoint springJoint;

    private void Awake()
    {
        springJoint = GetComponentInChildren<SpringJoint>();
    }

    private void FixedUpdate()
    {
        if (isSwitched && springJoint.currentForce.sqrMagnitude > 0.1f)
            return;

        if (!isSwitched && springJoint.currentForce.sqrMagnitude < 0.1f)
            return;

        HandleInteract();
    }
}
