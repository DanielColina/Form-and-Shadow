using UnityEngine;

public abstract class TimerSwitch : Switch
{
    [SerializeField] AudioClip m_TimerSwitchFlipAudioClip;
	[SerializeField] float m_TimerDuration;

    AudioSource audioSource;
	bool isCinematic;
	float timerDurationStart;
	bool playerCanInteract;
	bool timerIsActive;
	GameObject m_Camera;

	protected new void Start ()
	{
		base.Start();
		m_Camera = GameObject.Find ("Main_Camera");
		if (this.gameObject.tag != "Untagged")
			isCinematic = true;
		else
			isCinematic = false;
        audioSource = GetComponent<AudioSource>();
	}

	protected new void Update ()
	{
		base.Update();

		if(playerCanInteract)
		{
			if (PlayerShadowInteraction.m_CurrentPlayerState != PlayerShadowInteraction.PlayerState.Form)
				playerCanInteract = false;
		}

		if (!timerIsActive)
			UpdateTimerSwitchInput();
		else
			UpdateTimerDuration();
	}

	void UpdateTimerSwitchInput()
	{
		if(playerCanInteract)
		{
			if(Input.GetButtonDown("Grab"))
			{

				Activate();
			}
		}
	}

	void UpdateTimerDuration()
	{
		if (Time.time > timerDurationStart + m_TimerDuration)
		{
			Deactivate();
		}
	}

	void Activate()
	{
        SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_TimerSwitchFlipAudioClip, 1, false, 0);
        audioSource.Play();
		timerDurationStart = Time.time;
		timerIsActive = true;
		m_PressedByPlayer = true;
		if (isCinematic) 
		{
			m_Camera.GetComponent<CameraControl> ().SetupCinematic(this.gameObject.tag);
			m_Camera.GetComponent<CameraControl> ().duration = this.gameObject.GetComponent<SetCinematicSpeed> ().speed;
			m_Camera.GetComponent<CameraControl> ().rotSpeed = this.gameObject.GetComponent<SetCinematicSpeed> ().rotationSpeed;
			isCinematic = false;
		}
	}

	void Deactivate()
    {
        SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_TimerSwitchFlipAudioClip, 1, false, 0);
        audioSource.Stop();
		timerIsActive = false;
		m_PressedByPlayer = false;
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && !timerIsActive && PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Form)
			playerCanInteract = true;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Form)
			playerCanInteract = false;
	}
}
