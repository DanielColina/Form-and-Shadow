using UnityEngine;

public class PropellorPlatformShadowCollider : MonoBehaviour
{
    public float m_PropellorRotationSpeed;
    [HideInInspector] public bool m_ZAxisCast;
    [HideInInspector] public bool m_Paused;

    float personalTime;
    Vector3 startingScale;
    Vector3 currentScale;

	void Start ()
	{
        startingScale = transform.localScale;
        currentScale = startingScale;
        personalTime = 0;
    }

    void FixedUpdate()
    {
        if (PlayerShadowInteraction.m_CurrentPlayerState != PlayerShadowInteraction.PlayerState.Shifting && !GameController.m_Resetting && !GameController.m_Paused && !m_Paused)
            personalTime += Time.fixedDeltaTime;

        if (m_ZAxisCast)
            currentScale.x = startingScale.x - (startingScale.x - startingScale.z) * Mathf.Abs(Mathf.Cos(m_PropellorRotationSpeed * personalTime * Mathf.PI / 180));
        else
            currentScale.x = startingScale.z - (startingScale.z - startingScale.x) * Mathf.Abs(Mathf.Cos(m_PropellorRotationSpeed * personalTime * Mathf.PI / 180));
        transform.localScale = currentScale;
    }
}

