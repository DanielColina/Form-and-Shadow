using UnityEngine;

public class PushCubeMoveReference : MonoBehaviour
{
    public Transform m_RightHandTransform;
    public Transform m_LeftHandTransform;
    [HideInInspector] public bool m_PlayerInTrigger;
	PushCube pushCube;

	void Start()
	{
		pushCube = GetComponentInParent<PushCube>();
	}

	void Update()
	{
		//force player to exit trigger if shadow shifting
		switch (PlayerShadowInteraction.m_CurrentPlayerState)
		{
		case PlayerShadowInteraction.PlayerState.Shifting:
			m_PlayerInTrigger = false;
			pushCube.m_PlayerCanInteract = false;
			break;
		}
	}

	void OnTriggerEnter(Collider other)
	{
        if (PlayerShadowInteraction.m_CurrentPlayerState != PlayerShadowInteraction.PlayerState.Form || GameController.m_Paused)
            return;

        if (other.gameObject.CompareTag("Player"))
		{
            m_PlayerInTrigger = true;
            pushCube.m_PlayerCanInteract = true;
            PlayerMotor.m_Instance.m_GrabbedObjectPlayerSide = gameObject.transform;
        }
	}

    void OnTriggerExit(Collider other)
	{
        if (GameController.m_Paused)
            return;

        if (other.gameObject.CompareTag("Player"))
        {
            m_PlayerInTrigger = false;
            pushCube.m_PlayerCanInteract = false;
            if(pushCube.m_Grabbed)
                pushCube.Release();
        }
    }
}

