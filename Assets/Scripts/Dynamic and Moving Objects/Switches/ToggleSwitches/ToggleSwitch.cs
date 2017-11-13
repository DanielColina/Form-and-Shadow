using UnityEngine;

public abstract class ToggleSwitch : Switch
{
    [SerializeField] AudioClip switchFlipAudioClip;
	bool playerCanInteract;
	bool isCinematic;
	float internalCooldown;
	float internalCooldownStart;
	GameObject m_Camera;

	protected new void Start ()
	{
		base.Start();
		internalCooldown = 0.5f;
		internalCooldownStart = 0f;
		m_Camera = GameObject.Find ("Main_Camera");
		if (this.gameObject.tag != "Untagged")
			isCinematic = true;
		else
			isCinematic = false;
	}

	protected new void Update ()
	{
		base.Update();

		if (playerCanInteract)
		{
			if (PlayerShadowInteraction.m_CurrentPlayerState != PlayerShadowInteraction.PlayerState.Form)
				playerCanInteract = false;
		}

		if (Time.time > internalCooldownStart + internalCooldown)
			UpdateToggleSwitchInput();
	}

	void UpdateToggleSwitchInput()
	{
		if(playerCanInteract)
		{
			if (Input.GetButtonDown("Grab"))
			{
                SoundManager.m_Instance.PlaySound3DOneShot(transform.position, switchFlipAudioClip, 1, false, 0);
				internalCooldownStart = Time.time;
				m_PressedByPlayer = !m_PressedByPlayer;
				if (isCinematic) 
				{
					m_Camera.GetComponent<CameraControl> ().SetupCinematic(this.gameObject.tag);
					m_Camera.GetComponent<CameraControl> ().duration = this.gameObject.GetComponent<SetCinematicSpeed> ().speed;
					m_Camera.GetComponent<CameraControl> ().rotSpeed = this.gameObject.GetComponent<SetCinematicSpeed> ().rotationSpeed;
					isCinematic = false;
				}
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Form)
			playerCanInteract = true;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Form)
			playerCanInteract = false;
	}
}
