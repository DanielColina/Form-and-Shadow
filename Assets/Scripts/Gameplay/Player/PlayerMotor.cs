using System;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [Flags]
    public enum PlayerState
    {
        None = 0,
        Grounded = 1 << 0,
        Airborne = 1 << 1,
        Dead = 1 << 2,
    }

    public PlayerState CurrentState { get; private set; }

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Transform groundTransform;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float groundDistance = 0.2f;
    [SerializeField] private LayerMask ground;

    private Rigidbody body;
    private Vector3 inputVector;

    #region State Control
    /// <summary>
    /// Turns off the given state from the player state
    /// </summary>
    /// <param name="state">The state to toggle on</param>
    public void SetState(PlayerState state)
    {
        CurrentState |= state;
    }

    /// <summary>
    /// Turns off the given state from the player state
    /// </summary>
    /// <param name="state">The state to toggle off</param>
    public void UnsetState(PlayerState state)
    {
        CurrentState &= ~state;
    } 

    /// <summary>
    /// Helper method that checks if the given state is active
    /// </summary>
    /// <param name="state">The state to check against</param>
    /// <returns>Whether or not the current state is active</returns>
    public bool CheckState(PlayerState state)
    {
        return (CurrentState & state) == state;
    }

    /// <summary>
    /// Toggles on a state solely for the player
    /// </summary>
    /// <param name="state">The state to toggle on solely</param>
    public void ToggleState(PlayerState state)
    {
        CurrentState ^= state;
    }
    #endregion

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdatePlayerInput();
        UpdatePlayerState();
        UpdatePlayerMotion();
    }

    private void UpdatePlayerInput()
    {
        inputVector = Vector3.zero;
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && CheckState(PlayerState.Grounded))
            body.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
    }

    private void UpdatePlayerState()
    {
        CheckGrounded();
    }

    private void UpdatePlayerMotion()
    {
        body.MovePosition(body.position + inputVector * speed * Time.fixedDeltaTime);
    }

    private void CheckGrounded()
    {
        if (Physics.CheckSphere(groundTransform.position, groundDistance, ground, QueryTriggerInteraction.Ignore))
        {
            UnsetState(PlayerState.Airborne);
            SetState(PlayerState.Grounded);
        }
        else
        {
            UnsetState(PlayerState.Grounded);
            SetState(PlayerState.Airborne);
        }
    }
}
