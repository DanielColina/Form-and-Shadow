using UnityEngine;

public abstract class PressureSwitch : Switch
{
    [SerializeField] AudioClip m_PressedAudioClip;
    [SerializeField] AudioClip m_ReleasedAudioClip;

	[HideInInspector] public bool m_PressedByPushCube;
	bool isCinematic;
	bool cinematicStarted;
	GameObject m_Camera;

	protected new void Start ()
	{
		base.Start();
		cinematicStarted = false;
		m_Camera = GameObject.Find ("Main_Camera");
		if (this.gameObject.tag != "Untagged")
			isCinematic = true;
		else
			isCinematic = false;
	}

	protected new void Update ()
    {
        base.Update();
        if(PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Shadowmelded || PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Shadow)
        {
            if (!m_PressedByPushCube)
                m_PressedByPlayer = false;
        }
        UpdateSwitchAnimator();
		if (m_PressedByPlayer || m_PressedByPushCube)
            StartCinematic();
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Push Cube"))
        {
            SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_PressedAudioClip, 1, true, 1.75f);
            m_PressedByPushCube = true;
        }
        else if (other.gameObject.CompareTag("Player"))
		{
			if (PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Form && !m_PressedByPushCube)
            {
                SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_PressedAudioClip, 1, true, 1.75f);
                m_PressedByPlayer = true;
            }
        }
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Push Cube"))
        {
            SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_ReleasedAudioClip, 1, true, 1.75f);
            m_PressedByPushCube = false;
        }
        else if (other.gameObject.CompareTag("Player"))
		{
			if (PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Form && !m_PressedByPushCube)
            {
                SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_ReleasedAudioClip, 1, true, 1.75f);
                m_PressedByPlayer = false;
            }
        }
	}

	void StartCinematic()
	{
		//play cinematic once
		if ((isCinematic && !cinematicStarted) && PlayerShadowInteraction.m_CurrentPlayerState != PlayerShadowInteraction.PlayerState.Shadow) 
		{
			m_Camera.GetComponent<CameraControl> ().SetupCinematic (this.gameObject.tag);
			m_Camera.GetComponent<CameraControl> ().duration = this.gameObject.GetComponent<SetCinematicSpeed> ().speed;
			m_Camera.GetComponent<CameraControl> ().rotSpeed = this.gameObject.GetComponent<SetCinematicSpeed> ().rotationSpeed;
			isCinematic = false;
		}
		cinematicStarted = true;
	}

	new void UpdateSwitchAnimator()
	{
		base.UpdateSwitchAnimator();
		if(!m_PressedByPlayer && m_PressedByPushCube)
			switchAnimator.SetBool("Pressed", m_PressedByPushCube);
	}
}

