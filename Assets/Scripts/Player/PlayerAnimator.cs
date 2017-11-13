using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	GameObject m_Camera;

    public enum Direction
    {
        Stationary, Forward, Backward, Left, Right, LeftForward, RightForward, LeftBackward, RightBackward
    }

    public Direction m_MoveDirection { get; set; }

    public static PlayerAnimator m_Instance;
    [HideInInspector] public Animator anim;
    public Animator cloak_anim;
    [HideInInspector] public Transform m_RightHandIKTransform;
    [HideInInspector] public Transform m_LeftHandIKTransform;
    float deadZone = 0.1f;


    void Awake()
    {
        m_Instance = this;
    }

	void Start ()
    {
        anim = GetComponentInChildren<Animator>();
		m_Camera = GameObject.Find ("Main_Camera");
	}

    public void UpdateAnimator()
    {
		if (!GameController.m_Resetting && !GameController.m_Paused && m_Camera.GetComponent<CameraControl> ().GetCinematic () == false)
        {
            switch (PlayerShadowInteraction.m_CurrentPlayerState)
            {
                case PlayerShadowInteraction.PlayerState.Form:
                    Update3DAnimationParameters();
                    break;
                case PlayerShadowInteraction.PlayerState.Shadow:
                    Update2DAnimationParameters();
                    break;
                case PlayerShadowInteraction.PlayerState.Grabbing:
                    UpdateGrabbingAnimationParameters();
                    break;
                case PlayerShadowInteraction.PlayerState.Shadowmelded:
                    Update3DAnimationParameters();
                    break;
                case PlayerShadowInteraction.PlayerState.Shifting:
                    break;
            }

            anim.SetBool("IsGrounded", PlayerController.m_Instance.m_IsGrounded);
            if (!PlayerController.m_Instance.m_IsGrounded)
                anim.SetFloat("JumpValue", PlayerMotor.m_Instance.body.velocity.y);
        }
		else if (m_Camera.GetComponent<CameraControl>().GetCinematic() == true)
		{
			anim.Rebind ();
		}
    }

    void Update3DAnimationParameters()
    {
        if(anim.GetBool("Grabbing"))
            anim.SetBool("Grabbing", false);
        anim.SetFloat("Forward", Input.GetAxis("Vertical"), 0.1f, Time.deltaTime);
        anim.SetFloat("Sideways", Input.GetAxis("Horizontal"), 0.1f, Time.deltaTime);

        cloak_anim.SetFloat("Forward", Input.GetAxis("Vertical"));
        cloak_anim.SetFloat("Sideways", Input.GetAxis("Horizontal"));
    }

    void Update2DAnimationParameters()
    {
        anim.SetFloat("Forward", Mathf.Abs(Input.GetAxis("Horizontal")), 0.1f, Time.deltaTime);
    }

    void UpdateGrabbingAnimationParameters()
    {
        if (!anim.GetBool("Grabbing"))
            anim.SetBool("Grabbing", true);
        anim.SetFloat("Forward", Input.GetAxis("Vertical"));
    }

    public void SetShifting(bool shifting)
    {
        anim.SetBool("Shifting", shifting);
    }


    public void SetPlayerInShadow(bool playerInShadow)
    {
        anim.SetBool("PlayerInShadow", playerInShadow);
    }

    public void ToggleJump()
    {
        anim.SetTrigger("Jumping");
        cloak_anim.SetTrigger("Jumping");
    }

    void OnAnimatorIK()
    {
        if(m_RightHandIKTransform)
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, m_RightHandIKTransform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        }

        if(m_LeftHandIKTransform)
        {
            anim.SetIKPosition(AvatarIKGoal.LeftHand, m_LeftHandIKTransform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        }
    }
}
