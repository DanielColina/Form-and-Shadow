using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float m_ConveyorBeltSpeed;
    [HideInInspector] public bool m_Paused;
    [HideInInspector] public bool m_PlayerColliding;

    Vector3 moveDirection;
    Rigidbody body;
    GameObject player;
    Vector2 offset;



    void Start()
    {
        moveDirection = transform.forward;
        body = GetComponent<Rigidbody>();
        player = GameObject.Find("Player_New");
    }

    void Update()
    {
		if (PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Shadowmelded ||
		          PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Shifting ||
		          GameController.m_Paused || GameController.m_Resetting) 
		{
			
			return;
		}
        GetComponentInChildren<Renderer>().material.SetTextureOffset("_MainTex", offset);
        if (m_PlayerColliding)
            player.GetComponent<PlayerMotor>().m_ConveyorVelocity = m_ConveyorBeltSpeed * transform.forward;
    }

	void OnCollisionEnter(Collision collision)
	{
		collision.gameObject.GetComponent<Rigidbody> ().velocity = m_ConveyorBeltSpeed * transform.forward;
	}

    void OnCollisionStay(Collision collision)
    {
		if (PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Shifting || GameController.m_Paused || GameController.m_Resetting) {
			return;
		}
		if (collision.gameObject.CompareTag ("Player"))
			m_PlayerColliding = true;
		else 
		{
			collision.gameObject.GetComponent<Rigidbody> ().velocity = m_ConveyorBeltSpeed * transform.forward;
		}
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            m_PlayerColliding = false;
    }
}