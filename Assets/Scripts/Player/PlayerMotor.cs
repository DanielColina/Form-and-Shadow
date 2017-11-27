using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public static PlayerMotor m_Instance;
    [Range(0, 10)][SerializeField] float m_MovementSpeed = 4f;
    [Range(0, 10)][SerializeField] float m_2DMovementSpeed = 4f;
    [Range(.25f, 1)][SerializeField] float m_GrabbingMovementSpeed = 0.25f;
    [Range(5, 14)][SerializeField] float m_JumpSpeed = 12f;
    [Range(2, 8)][SerializeField] float m_GravityMultiplier = 21f;
    [HideInInspector] public float m_TerminalVelocity = 20f;
    [HideInInspector] public Vector3 m_MoveVector;
    [HideInInspector] public float m_VerticalVelocity;
    [HideInInspector] public Transform m_GrabbedObjectTransform;
    [HideInInspector] public Transform m_GrabbedObjectPlayerSide;
    [HideInInspector] public Vector3 m_ConveyorVelocity;
    [HideInInspector] public Rigidbody body;

    void Start ()
    {
        m_Instance = this;
        body = GetComponent<Rigidbody>();
	}


    public void UpdateMovement ()
    {
        if (transform.eulerAngles.x != 0 || transform.eulerAngles.z != 0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        switch(PlayerShadowInteraction.m_CurrentPlayerState)
        {
            case PlayerShadowInteraction.PlayerState.Form:
                SnapAlignCharacterWithCamera3D();
                Process3DMotion();
                break;
            case PlayerShadowInteraction.PlayerState.Shadow:
                SnapAlignCharacterWithCamera2D();
                Process2DMotion();
                break;
            case PlayerShadowInteraction.PlayerState.Grabbing:
                ProcessGrabbingMotion();
                break;
            case PlayerShadowInteraction.PlayerState.Shifting:
                ProcessShiftingMotion();
                break;
            case PlayerShadowInteraction.PlayerState.Shadowmelded:
                SnapAlignCharacterWithCamera3D();
                Process3DMotion();
                break;
        }
	}

#region Motion Processing Methods
    void Process3DMotion()
    {
        // Transform MoveVector into world space relative to character's rotation
        // Normalize MoveVector if Magnitude > 1
        if (m_MoveVector.magnitude > 1) 
            m_MoveVector = m_MoveVector.normalized;

        // Multiply normalized MoveVector by MoveSpeed;
        m_MoveVector *= m_MovementSpeed;

        // Apply conveyor velocity to movevector
        m_MoveVector += m_ConveyorVelocity;
        m_ConveyorVelocity = Vector3.zero;

        //// Apply slide velocity to movevector
        //m_MoveVector += GetSlideVelocity();

        // Apply gravity
        if(!PlayerController.m_Instance.m_IsGrounded)
            ApplyExtraGravity();

        // Move the CharacterController in world space using the MoveVector
        body.velocity = new Vector3(m_MoveVector.x, GetComponent<Rigidbody>().velocity.y, m_MoveVector.z);
    }

    void Process2DMotion()
    {
        // Normalize MoveVector if Magnitude > 1
        if (m_MoveVector.magnitude > 1)
            m_MoveVector = m_MoveVector.normalized;

        // Multiply normalized MoveVector by 2D Movement speed;
        m_MoveVector *= m_2DMovementSpeed;

        // Apply gravity
        if(!PlayerController.m_Instance.m_IsGrounded)
            ApplyExtraGravity();

        // Move the CharacterController in world space using the MoveVector
        body.velocity = new Vector3(m_MoveVector.x, GetComponent<Rigidbody>().velocity.y, m_MoveVector.z);
    }

    void ProcessGrabbingMotion()
    {
        if (m_MoveVector.magnitude > 1)
            m_MoveVector = m_MoveVector.normalized;

        //Multiply normalized MoveVector by Grabbing Speed
        m_MoveVector *= m_GrabbingMovementSpeed;

        // Apply gravity
        ApplyExtraGravity();

        // Move the CharacterController in world space using the MoveVector
        body.velocity = new Vector3(m_MoveVector.x, GetComponent<Rigidbody>().velocity.y, m_MoveVector.z);
        
        if(Vector3.Distance(transform.position, m_GrabbedObjectTransform.transform.position) > 1.15f)
            m_GrabbedObjectTransform.GetComponent<Rigidbody>().velocity = new Vector3(m_MoveVector.x, m_GrabbedObjectTransform.GetComponent<Rigidbody>().velocity.y, m_MoveVector.z);
    }

    void ProcessShiftingMotion()
    {
        body.velocity = Vector3.zero;
    }
    #endregion

#region Utility Methods
    void ApplyExtraGravity()
    {
        Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
        body.AddForce(extraGravityForce);
    }

    public void Jump()
    {
        body.AddForce(Vector3.up * m_JumpSpeed, ForceMode.VelocityChange);
    }
#endregion

#region Snap Align Methods
    void SnapAlignCharacterWithCamera3D()
    {
        if (m_MoveVector.magnitude != 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(m_MoveVector, Vector3.up), Time.deltaTime * 6);
    }

    void SnapAlignCharacterWithCamera2D()
    {
        if(m_MoveVector.magnitude != 0)
            transform.Find("Player_Mesh_Master").transform.rotation = Quaternion.LookRotation(m_MoveVector, Camera.main.transform.up);
    }

    // Called by the PushCube.cs script to turn the player to face upon grabbing, but only once
    // because calls repeated in Update cause issues with childing the cube to the player
    public void SnapAlignCharacterWithGrabbedObject()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.Normalize(m_GrabbedObjectTransform.position - m_GrabbedObjectPlayerSide.position), Vector3.up);
    }
#endregion

#region Follow Methods

    void PlayerFollowShiftingObject()
    {
        transform.position = PlayerShadowInteraction.m_ShadowShiftFollowObject.transform.position;
    }
    #endregion
}
