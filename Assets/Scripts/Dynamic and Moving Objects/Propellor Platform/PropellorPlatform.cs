using UnityEngine;
using System.Collections.Generic;

public class PropellorPlatform : MonoBehaviour {
	[Range(20, 120)] public float m_RotationSpeed;
    [SerializeField] bool m_RotateClockwise = true;
    [HideInInspector] public bool m_Paused;

    [HideInInspector] public List<GameObject> propellorShadowColliders;

    void Start()
    {
        if(GetComponent<ShadowCast>())
        {
            if (GetComponent<ShadowCast>().m_ShadowColliders.m_NorthShadowCollider)
                propellorShadowColliders.Add(GetComponent<ShadowCast>().m_ShadowColliders.m_NorthShadowCollider);
            if (GetComponent<ShadowCast>().m_ShadowColliders.m_EastShadowCollider)
                propellorShadowColliders.Add(GetComponent<ShadowCast>().m_ShadowColliders.m_EastShadowCollider);
            if (GetComponent<ShadowCast>().m_ShadowColliders.m_SouthShadowCollider)
                propellorShadowColliders.Add(GetComponent<ShadowCast>().m_ShadowColliders.m_SouthShadowCollider);
            if (GetComponent<ShadowCast>().m_ShadowColliders.m_WestShadowCollider)
                propellorShadowColliders.Add(GetComponent<ShadowCast>().m_ShadowColliders.m_WestShadowCollider);
        }
    }

	void FixedUpdate () 
	{
        foreach (GameObject propellorShadowCollider in propellorShadowColliders)
        {
            propellorShadowCollider.GetComponentInChildren<PropellorPlatformShadowCollider>().m_Paused = m_Paused;
        }
        if (PlayerShadowInteraction.m_CurrentPlayerState != PlayerShadowInteraction.PlayerState.Shifting && !GameController.m_Resetting && !GameController.m_Paused && !m_Paused)
        {
            if(m_RotateClockwise)
            {
                transform.Rotate(Vector3.up, Time.fixedDeltaTime * m_RotationSpeed);
            }
            else
            {
                transform.Rotate(Vector3.up, Time.fixedDeltaTime * -m_RotationSpeed);
            }
        }
    }
}