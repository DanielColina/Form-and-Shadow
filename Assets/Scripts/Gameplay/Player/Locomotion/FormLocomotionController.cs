using UnityEngine;

using KinematicCharacterController;

[System.Serializable]
public class FormInputSet : AInputSet
{
    public bool JumpDown;

    public bool CrouchDown;

    public bool CrouchUp;

    public FormInputSet()
    {
        HorizontalAxis = 0.0f;
        VerticalAxis = 0.0f;
        CameraRotation = Quaternion.identity;
        JumpDown = false;
        CrouchDown = false;
        CrouchUp = false;
    }
}

public class FormLocomotionController : ALocomotionController<FormInputSet>
{
    public override FormInputSet GetInputSet()
    {
        return new FormInputSet();
    }

    public override void ProcessInputSet(ref FormInputSet inputs)
    {
    }

    public override void AfterCharacterUpdate(float deltaTime)
    {
    }

    public override void BeforeCharacterUpdate(float deltaTime)
    {
    }

    public override bool IsColliderValidForCollisions(Collider coll)
    {
        return false;
    }

    public override void OnDiscreteCollisionDetected(Collider hitCollider)
    {
    }

    public override void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
    }

    public override void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
    }

    public override void PostGroundingUpdate(float deltaTime)
    {
    }

    public override void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
    }

    public override void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
    }

    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
    }
}
