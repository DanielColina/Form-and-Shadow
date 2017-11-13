using UnityEngine;

public class PlayerSquishCheck : MonoBehaviour
{
    public LayerMask m_SquishLayerMask;
    float squishedTimer;

    bool timerActive;
    bool wasSquished;

    void Update()
    {
        if (squishedTimer > 0)
            squishedTimer--;

        if (squishedTimer == 0)
        {
            timerActive = false;
            if (wasSquished)
            {
                GameController.m_Instance.Respawn("Crush");
            }
        }

        if (PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Form || PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Shadow)
            CheckforSquish();
    }
    
    void CheckforSquish()
    {
        Collider [] overlappingColliders = Physics.OverlapSphere(transform.position + new Vector3(0, 1.12f, 0), 0.1f, m_SquishLayerMask, QueryTriggerInteraction.Ignore);
        wasSquished = (overlappingColliders.Length != 0);
        if (wasSquished && !timerActive)
        {
            squishedTimer = 6;
            timerActive = true;
        }
    }
}
