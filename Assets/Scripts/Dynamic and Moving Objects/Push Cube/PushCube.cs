using UnityEngine;

public class PushCube : MonoBehaviour
{
    [HideInInspector] public bool m_PlayerCanInteract;
    [HideInInspector] public bool m_Grabbed;

    [SerializeField] BoxCollider m_BaseCollider;
    [SerializeField] AudioClip grabAudioClip;
    [SerializeField] AudioClip releaseAudioClip;

    Rigidbody body;
	bool resetSpeed = false;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

	void Update()
	{
        UpdateGrabbingInput();
        UpdatePushCubeDragAudio();

		if (PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Shadowmelded ||
			PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Shifting ||
			GameController.m_Paused || GameController.m_Resetting)
			resetSpeed = true;
		else if (resetSpeed) 
		{
			gameObject.GetComponent<Rigidbody> ().velocity = .001f * transform.forward;
			resetSpeed = false;
		}
    }

    void UpdateGrabbingInput()
    {
        if(m_PlayerCanInteract)
        {
            if(!m_Grabbed)
            {
                if (Input.GetButtonDown("Grab"))
                {
                    Grab();
                }
            }
            if (Input.GetButtonUp("Grab"))
            {
                Release();
            }
        }
    }

    void UpdatePushCubeDragAudio()
    {
        if (m_Grabbed && (body.velocity.x > 0.1f || body.velocity.x < -0.1f || body.velocity.z > 0.1f || body.velocity.z < -0.1f))
        {
            if (!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();
        }
        else
            GetComponent<AudioSource>().Stop();
    }

    void Grab()
    {
        m_Grabbed = true;
        PlayerMotor.m_Instance.m_GrabbedObjectTransform = gameObject.transform;
        PlayerMotor.m_Instance.SnapAlignCharacterWithGrabbedObject();
        PlayerShadowInteraction.m_CurrentPlayerState = PlayerShadowInteraction.PlayerState.Grabbing;
        m_BaseCollider.material = PlayerController.m_Instance.m_PlayerCollision.sharedMaterial;
        PlayerController.m_Instance.m_PlayerCollision.transform.localScale = new Vector3(1, 1, 1.5f);
        body.mass = 1f;

        foreach (Transform child in transform)
        {
            if (child.GetComponent<PushCubeMoveReference>())
            {
                PushCubeMoveReference moveReference = child.GetComponent<PushCubeMoveReference>();
                if (moveReference.m_PlayerInTrigger)
                {
                    PlayerAnimator.m_Instance.m_RightHandIKTransform = moveReference.m_RightHandTransform;
                    PlayerAnimator.m_Instance.m_LeftHandIKTransform = moveReference.m_LeftHandTransform;
                }
            }
        }
        SoundManager.m_Instance.PlaySound3DOneShot(transform.position, grabAudioClip, 1, false, 0);
    }

    public void Release()
    {
        m_Grabbed = false;
        PlayerMotor.m_Instance.m_GrabbedObjectTransform = null;
        m_BaseCollider.material = null;
        PlayerController.m_Instance.m_PlayerCollision.transform.localScale = new Vector3(1, 1, 1);
        body.mass = 100f;

        PlayerShadowInteraction.m_CurrentPlayerState = PlayerShadowInteraction.PlayerState.Form;
        PlayerAnimator.m_Instance.m_RightHandIKTransform = null;
        PlayerAnimator.m_Instance.m_LeftHandIKTransform = null;
        SoundManager.m_Instance.PlaySound3DOneShot(transform.position, releaseAudioClip, 1, false, 0);
    }
}
