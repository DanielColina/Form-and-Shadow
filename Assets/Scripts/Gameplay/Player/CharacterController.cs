using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KinematicCharacterController;

namespace FormAndShadow
{
    /// <summary>
    /// Character input structure
    /// </summary>
    public struct PlayerInputSet
    {
        public Vector3 moveVector;
        public Quaternion cameraRotation;
        public bool jumpDown;
    }

    /// <summary>
    /// Default character controller for Form and Shadow.
    /// </summary>
    public class CharacterController : BaseCharacterController
    {
        [Header("Stable Movement")]
        [SerializeField] private float maxMoveSpeed = 10.0f;
        [SerializeField] private float moveSharpness = 15.0f;
        [SerializeField] private float orientationSharpness = 10.0f;

        [Header("Air Movement")]
        [SerializeField] private float maxAirMoveSpeed = 10.0f;
        [SerializeField] private float airAccelerationSpeed = 5.0f;
        [SerializeField] private float drag = 0.1f;

        [Header("Jumping")]
        [SerializeField] private bool allowJumpWhenSliding;
        [SerializeField] private float jumpSpeed = 10.0f;
        [SerializeField] private float jumpPreGroundingGraceTime = 0.0f;
        [SerializeField] private float jumpPostGroundingGraceTime = 0.0f;

        [Header("Misc")]
        [SerializeField] private Vector3 gravity = new Vector3(0.0f, -30.0f, 0.0f);

        private Vector3 moveInputVector;
        private Vector3 lookInputVector;
        private bool jumpRequested = false;
        private bool jumpConsumed = false;
        private bool jumpedThisFrame = false;
        private float timeSinceJumpRequested = Mathf.Infinity;
        private float timeSinceLastAbleToJump = 0.0f;
        private Vector3 wallJumpNormal;

        /// <summary>
        /// Called by PlayerInput each frame to tell this character what its input is
        /// </summary>
        /// <param name="input">Input values</param>
        public void SetInput(ref PlayerInputSet input)
        {
            // Project a forward vector that's been rotated to the camera's rotation along the character's plane
            Vector3 cameraPlanarDirection = Vector3.ProjectOnPlane(input.cameraRotation * Vector3.forward, Motor.CharacterUp).normalized;

            // In the case that the previous calculation produced a 0.0f magnitude vector, instead calculate using an up vector
            // (assuming this case is if the camera rotation is looking straight down or up
            if (cameraPlanarDirection.sqrMagnitude == 0.0f)
                cameraPlanarDirection = Vector3.ProjectOnPlane(input.cameraRotation * Vector3.up, Motor.CharacterUp).normalized;

            // Create a new rotation formed out of the project vector and the character's up vector
            Quaternion cameraPlanarRotation = Quaternion.LookRotation(cameraPlanarDirection, Motor.CharacterUp);

            // Rotate my input vector to the camera's planar rotation
            moveInputVector = cameraPlanarRotation * input.moveVector.normalized;

            // Set my look input vector to the camera's planar projected direction
            lookInputVector = cameraPlanarDirection;

            // Process jumping input
            if (input.jumpDown)
            {
                timeSinceJumpRequested = 0.0f;
                jumpRequested = true;
            }
        }

        public override void BeforeCharacterUpdate(float deltaTime)
        {
        }

        public override bool IsColliderValidForCollisions(Collider coll)
        {
            return true;
        }

        public override void PostGroundingUpdate(float deltaTime)
        {
        }

        public override void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        {
        }

        public override void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            if (lookInputVector != Vector3.zero && orientationSharpness > 0.0f)
            {
                // Smoothly interpolate from current look direction to target look direction
                Vector3 smoothedLookInputDirection = Vector3.Slerp(Motor.CharacterForward, lookInputVector, 1 - Mathf.Exp(-orientationSharpness * deltaTime)).normalized;

                // Apply the current rotation
                currentRotation = Quaternion.LookRotation(smoothedLookInputDirection, Motor.CharacterUp);
            }
        }

        public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            Vector3 targetMovementVelocity = Vector3.zero;
            
            // If we are grounded and stable, apply grounded velocity
            if (Motor.GroundingStatus.IsStableOnGround)
            {
                // Reorient source velocity on the current ground slope to prevent smoothing causing velocity losses when slope changes
                currentVelocity = Motor.GetDirectionTangentToSurface(currentVelocity, Motor.GroundingStatus.GroundNormal) * currentVelocity.magnitude;

                // Calculate target velocity
                Vector3 inputRight = Vector3.Cross(moveInputVector, Motor.CharacterUp);
                Vector3 reorientedInput = Vector3.Cross(Motor.GroundingStatus.GroundNormal, inputRight).normalized * moveInputVector.magnitude;

                targetMovementVelocity = reorientedInput * maxMoveSpeed;

                // Smooth movement velocity
                currentVelocity = Vector3.Lerp(currentVelocity, targetMovementVelocity, 1 - Mathf.Exp(-moveSharpness * deltaTime));
            }

            else
            {
                if (moveInputVector.sqrMagnitude > 0.0f)
                {
                    targetMovementVelocity = moveInputVector * maxAirMoveSpeed;

                    // Prevent climbing on un-stable slopes while in air
                    if (Motor.GroundingStatus.FoundAnyGround)
                    {
                        Vector3 perpendicularObstructionNormal = Vector3.Cross(Vector3.Cross(Motor.CharacterUp, Motor.GroundingStatus.GroundNormal), Motor.CharacterUp).normalized;
                        targetMovementVelocity = Vector3.ProjectOnPlane(targetMovementVelocity, perpendicularObstructionNormal);
                    }

                    Vector3 velocityDiff = Vector3.ProjectOnPlane(targetMovementVelocity - currentVelocity, gravity);
                    currentVelocity += velocityDiff * airAccelerationSpeed * deltaTime;
                }

                // Apply gravity
                currentVelocity += gravity * deltaTime;

                // Apply drag
                currentVelocity *= (1.0f / (1.0f + (drag * deltaTime)));
            }

            // Reset jumping variables
            jumpedThisFrame = false;
            timeSinceJumpRequested += deltaTime;

            if (jumpRequested)
            {
                if (!jumpConsumed && ((allowJumpWhenSliding ? Motor.GroundingStatus.FoundAnyGround : Motor.GroundingStatus.IsStableOnGround) || timeSinceLastAbleToJump <= jumpPostGroundingGraceTime))
                {
                    Vector3 jumpDirection = Motor.CharacterUp;

                    if (Motor.GroundingStatus.FoundAnyGround && !Motor.GroundingStatus.IsStableOnGround)
                        jumpDirection = Motor.GroundingStatus.GroundNormal;

                    // Force the character to unground
                    Motor.ForceUnground();

                    // Add jump velocity to the return value and reset jump state
                    currentVelocity += (jumpDirection * jumpSpeed) - Vector3.Project(currentVelocity, Motor.CharacterUp);
                    jumpRequested = false;
                    jumpConsumed = true;
                    jumpedThisFrame = true;
                }
            }
        }

        public override void AfterCharacterUpdate(float deltaTime)
        {
            // Handle resetting based on pre-ground grace period
            if (jumpRequested && timeSinceJumpRequested > jumpPreGroundingGraceTime)
                jumpRequested = false;

            if (allowJumpWhenSliding ? Motor.GroundingStatus.FoundAnyGround : Motor.GroundingStatus.IsStableOnGround)
            {            
                // If we're on a ground surface, reset jumping values
                if (!jumpedThisFrame)
                {
                    jumpConsumed = false;
                }
                timeSinceLastAbleToJump = 0.0f;
            }
            else
            {
                // Keep track of the time since we were last able to jump for grace period
                timeSinceLastAbleToJump += deltaTime;
            }
        }

        public override void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
        }

        public override void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
        }
    }
}
