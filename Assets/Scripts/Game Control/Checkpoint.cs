using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Transform m_RespawnPosition;
    [SerializeField] bool triggered = false;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!triggered)
            {
                PlayerShadowInteraction.m_Instance.m_PlayerRespawnPosition = m_RespawnPosition.position;
                triggered = true;
            }
        }
    }

    public void resetTrigger() {
        triggered = false;
    }
}
