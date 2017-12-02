using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
	public LayerMask m_GroundLayer3D;
	public LayerMask m_GroundLayer2D;
	public CapsuleCollider m_PlayerCollision;
	public static PlayerController m_Instance;
	GameObject m_Camera;
	public bool m_IsGrounded;
	bool isJumping;

	void Start()
	{
		m_Instance = this;
		m_IsGrounded = false;
		m_Camera = GameObject.Find ("Main_Camera");
		if (GameObject.Find ("Loading_Camera") != null) 
		{
			Destroy (GameObject.Find ("Revert_Button"));
		}
	}

	void Update()
	{
		if(!GameController.m_Resetting && !GameController.m_Paused && m_Camera.GetComponent<CameraControl>().GetCinematic() == false)
		{
			switch (PlayerShadowInteraction.m_CurrentPlayerState)
			{
			case PlayerShadowInteraction.PlayerState.Form:
				GetJumpInput ();
				break;
			case PlayerShadowInteraction.PlayerState.Shadow:
				GetJumpInput ();
				break;
		    case PlayerShadowInteraction.PlayerState.Shadowmelded:
				GetJumpInput ();
				break;
			}
		}
	}

	void FixedUpdate()
	{
		if(!GameController.m_Resetting && !GameController.m_Paused && m_Camera.GetComponent<CameraControl>().GetCinematic() == false)
        {
            CheckGrounded();
            switch (PlayerShadowInteraction.m_CurrentPlayerState)
            {
				case PlayerShadowInteraction.PlayerState.Form:
					Get3DLocomotionInput ();
                    if (isJumping) 
					{
						Jump ();
						isJumping = false;
					}
                    break;
                case PlayerShadowInteraction.PlayerState.Shadow:
                    Get2DLocomotionInput();
					if (isJumping) 
					{
						Jump ();
						isJumping = false;
					}
                    break;
                case PlayerShadowInteraction.PlayerState.Grabbing:
                    GetGrabbingLocomotionInput();
                    break;
                case PlayerShadowInteraction.PlayerState.Shadowmelded:
                    Get3DLocomotionInput();
					if (isJumping) 
					{
						Jump ();
						isJumping = false;
					}
                    break;
            }
            PlayerMotor.m_Instance.UpdateMovement();
            PlayerAnimator.m_Instance.UpdateAnimator();
        }
		else if ((m_Camera.GetComponent<CameraControl>().GetCinematic() == true || GameController.m_Paused) && PlayerMotor.m_Instance.body.velocity != Vector3.zero)
		{
			PlayerMotor.m_Instance.body.velocity = Vector3.zero;
			PlayerAnimator.m_Instance.UpdateAnimator();
		}
	}

	void CheckGrounded()
	{
		float radius = m_PlayerCollision.radius * .95f;
		Vector3 pos = m_PlayerCollision.transform.position + Vector3.up * (radius * 0.9f);

		if (PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Shadow)
			m_IsGrounded = Physics.CheckSphere(pos, radius, m_GroundLayer2D, QueryTriggerInteraction.Ignore);
		else
			m_IsGrounded = Physics.CheckSphere(pos, radius, m_GroundLayer3D, QueryTriggerInteraction.Ignore);
	}

	void Get3DLocomotionInput()
	{
		var deadZone = 0.1f;

		PlayerMotor.m_Instance.m_MoveVector = Vector3.zero;

		if (CrossPlatformInputManager.GetAxis("Vertical") > deadZone || CrossPlatformInputManager.GetAxis("Vertical") < -deadZone)
			PlayerMotor.m_Instance.m_MoveVector += CrossPlatformInputManager.GetAxis("Vertical") * (Vector3.Scale(new Vector3(1, 0, 1), Camera.main.transform.forward).normalized);

		if (CrossPlatformInputManager.GetAxis("Horizontal") > deadZone || CrossPlatformInputManager.GetAxis("Horizontal") < -deadZone)
			PlayerMotor.m_Instance.m_MoveVector += CrossPlatformInputManager.GetAxis("Horizontal") * Camera.main.transform.right;
        Debug.DrawRay(transform.position, PlayerMotor.m_Instance.m_MoveVector, Color.red);
	}

	void Get2DLocomotionInput()
	{
		var deadZone = 0.1f;

		PlayerMotor.m_Instance.m_MoveVector = Vector3.zero;

		if (CrossPlatformInputManager.GetAxis("Horizontal") > deadZone || CrossPlatformInputManager.GetAxis("Horizontal") < -deadZone)
			PlayerMotor.m_Instance.m_MoveVector += CrossPlatformInputManager.GetAxis("Horizontal") * Camera.main.transform.right;
	}

	void GetGrabbingLocomotionInput()
	{
		var deadZone = 0.1f;

		PlayerMotor.m_Instance.m_MoveVector = Vector3.zero;

		if (CrossPlatformInputManager.GetAxis("Vertical") > deadZone || CrossPlatformInputManager.GetAxis("Vertical") < deadZone)
			PlayerMotor.m_Instance.m_MoveVector += CrossPlatformInputManager.GetAxis("Vertical") * transform.forward;
	}

	void GetJumpInput()
	{
		if (CrossPlatformInputManager.GetButtonDown ("Jump"))
			isJumping = true;
	}

	void Jump()
	{
		if (m_IsGrounded)
        {
            PlayerAudio.m_Instance.PlayJumpAudioClip();
            PlayerAnimator.m_Instance.ToggleJump();
            PlayerMotor.m_Instance.Jump();
        }
    }
}