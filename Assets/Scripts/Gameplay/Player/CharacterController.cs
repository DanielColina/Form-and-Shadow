using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KinematicCharacterController;

namespace FormandShadow
{
    public enum CharacterState
    {
        Default,
    }

    /// <summary>
    /// Character input structure
    /// </summary>
    public struct PlayerInputSet
    {
        public float moveAxisForward;
        public float moveAxisRight;
        public Quaternion cameraRotation;
        public bool jumpDown;
        public bool crouchDown;
        public bool crouchUp;
    }

    /// <summary>
    /// Default character controller for Form and Shadow.
    /// </summary>
    public class CharacterController : BaseCharacterController
    {
        [Header("Object References")]
        [SerializeField] private Animator animator;

        [Header("Stable Movement")]
        [SerializeField] private float stableMaxMoveSpeed = 10.0f;
        [SerializeField] private float stableMoveSharpness = 15.0f;
        [SerializeField] private float stableOrientationSharpness = 10.0f;

        [Header("Air Movement")]
        [SerializeField] private float maxAirMoveSpeed = 10.0f;
        [SerializeField] private float airAccelerationSpeed = 5.0f;
        [SerializeField] private float drag = 0.1f;

        [Header("Jumping")]
        [SerializeField] private bool allowJumpWhenSliding;
        [SerializeField] private float jumpSpeed = 10.0f;
        [SerializeField] private float jumpPreGroundingGraceTime = 0.0f;
        [SerializeField] private float jumpPostGroundingGraceTime = 0.0f;

        [Header("Crouching")]
        [SerializeField] private float crouchMaxMovementSpeed;
        [SerializeField] private float standingCapsuleHeight;
        [SerializeField] private float standingCapsuleYOffset;
        [SerializeField] private float crouchCapsuleHeight;
        [SerializeField] private float crouchCapsuleYOffset;

        [Header("Misc")]
        [SerializeField] private Vector3 gravity = new Vector3(0.0f, -30.0f, 0.0f);
        [SerializeField] private List<Collider> ignoredColliders = new List<Collider>();

        public CharacterState currentCharacterState = CharacterState.Default;

        private Vector3 moveInputVector;
        private Vector3 lookInputVector;
        private bool jumpRequested = false;
        private bool jumpConsumed = false;
        private bool jumpedThisFrame = false;
        private float timeSinceJumpRequested = Mathf.Infinity;
        private float timeSinceLastAbleToJump = 0.0f;
        private bool shouldBeCrouching;
        private bool isCrouching;
        private Collider[] probedColliders = new Collider[8];
        private Vector3 internalVelocityAdd = Vector3.zero;

        private void Start()
        {
            TransitionToState(CharacterState.Default);
        }

        public void TransitionToState(CharacterState newState)
        {
            CharacterState tmpInitialState = currentCharacterState;

        }

        public void OnStateEnter(CharacterState state, CharacterState fromState)
        {

        }

        public void OnStateExit(CharacterState state, CharacterState toState)
        {

        }

        /// <summary>
        /// Called by PlayerInput each frame to tell this character what its input is
        /// </summary>
        /// <param name="input">Input values</param>
        public void SetInput(ref PlayerInputSet input)
        {
            Vector3 rawInputVector = Vector3.ClampMagnitude(new Vector3(input.moveAxisRight, 0f, input.moveAxisForward), 1f);

            // Project a forward vector that's been rotated to the camera's rotation along the character's plane
            Vector3 cameraPlanarDirection = Vector3.ProjectOnPlane(input.cameraRotation * Vector3.forward, Motor.CharacterUp).normalized;

            // In the case that the previous calculation produced a 0.0f magnitude vector, instead calculate using an up vector
            // (assuming this case is if the camera rotation is looking straight down or up
            if (cameraPlanarDirection.sqrMagnitude == 0.0f)
                cameraPlanarDirection = Vector3.ProjectOnPlane(input.cameraRotation * Vector3.up, Motor.CharacterUp).normalized;

            // Create a new rotation formed out of the project vector and the character's up vector
            Quaternion cameraPlanarRotation = Quaternion.LookRotation(cameraPlanarDirection, Motor.CharacterUp);

            // Rotate my input vector to the camera's planar rotation
            moveInputVector = cameraPlanarRotation * rawInputVector.normalized;

            // Set my look input vector to the camera's planar projected direction
            lookInputVector = moveInputVector.normalized;

            // Process jumping input
            if (input.jumpDown)
            {
                timeSinceJumpRequested = 0.0f;
                jumpRequested = true;
            }

            // Process crouching input
            if (input.crouchDown)
            {
                shouldBeCrouching = true;

                if (!isCrouching)
                {
                    isCrouching = true;
                    Motor.SetCapsuleDimensions(Motor.Capsule.radius, crouchCapsuleHeight, crouchCapsuleYOffset);
                    animator.SetBool("IsCrouching", true);
                }
            }
            else if (input.crouchUp)
            {
                shouldBeCrouching = false;
            }
        }

        public override void BeforeCharacterUpdate(float deltaTime)
        {
        }

        public override void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        {
        }

        public override void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            if (lookInputVector != Vector3.zero && stableOrientationSharpness > 0.0f)
            {
                // Smoothly interpolate from current look direction to target look direction
                Vector3 smoothedLookInputDirection = Vector3.Slerp(Motor.CharacterForward, lookInputVector, 1 - Mathf.Exp(-stableOrientationSharpness * deltaTime)).normalized;

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

                targetMovementVelocity = reorientedInput * (isCrouching ? crouchMaxMovementSpeed : stableMaxMoveSpeed);

                // Smooth movement velocity
                currentVelocity = Vector3.Lerp(currentVelocity, targetMovementVelocity, 1 - Mathf.Exp(-stableMoveSharpness * deltaTime));
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

            if (internalVelocityAdd.sqrMagnitude > 0.0f)
            {
                currentVelocity += internalVelocityAdd;
                internalVelocityAdd = Vector3.zero;
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

            // Handle uncrouching
            if (isCrouching && !shouldBeCrouching)
            {
                // Do an overlap test what the character's standing height to see if there are any obstructions
                Motor.SetCapsuleDimensions(Motor.Capsule.radius, standingCapsuleHeight, standingCapsuleYOffset);
                if (Motor.CharacterOverlap(Motor.TransientPosition, Motor.TransientRotation, probedColliders, Motor.CollidableLayers, QueryTriggerInteraction.Ignore) > 0)
                {
                    Motor.SetCapsuleDimensions(Motor.Capsule.radius, crouchCapsuleHeight, crouchCapsuleYOffset);
                }
                else
                {
                    // If there are no obstructions, uncrouch
                    animator.SetBool("IsCrouching", false);
                    isCrouching = false;
                }
            }
        }

        /// <summary>
        /// Overridden from the BaseCharacterController class, called after the controller updates the current grounding state
        /// </summary>
        /// <param name="deltaTime">The delta time of the last frame</param>
        public override void PostGroundingUpdate(float deltaTime)
        {
            if (Motor.GroundingStatus.IsStableOnGround && !Motor.LastGroundingStatus.IsStableOnGround)
            {
                OnLanded();
            }
            else if (!Motor.GroundingStatus.IsStableOnGround && Motor.LastGroundingStatus.IsStableOnGround)
            {
                OnLeaveStableGround();
            }
        }

        public override void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
        }

        public override void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
        }

        public override bool IsColliderValidForCollisions(Collider coll)
        {
            if (ignoredColliders.Contains(coll))
                return false;
            else
                return true;
        }

        public void AddVelocity(Vector3 velocity)
        {
            internalVelocityAdd = velocity;
        }

        protected void OnLanded()
        {

        }

        protected void OnLeaveStableGround()
        {
        }
    }
}
