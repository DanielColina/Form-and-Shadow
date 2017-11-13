using System.Collections.Generic;
using UnityEngine;

public class ConveyorCube : MonoBehaviour
{
    public bool m_AtEndOfRoute = false;
	bool resetSpeed = false;

    void Update()
    {
        if (m_AtEndOfRoute)
            DestroyPlatform();
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


    public void DestroyPlatform()
    {
        List<GameObject> platformShadowColliders = new List<GameObject>();
        if (GetComponentInChildren<ShadowCast>().m_ShadowColliders.m_NorthShadowCollider)
            platformShadowColliders.Add(GetComponentInChildren<ShadowCast>().m_ShadowColliders.m_NorthShadowCollider);
        if (GetComponentInChildren<ShadowCast>().m_ShadowColliders.m_EastShadowCollider)
            platformShadowColliders.Add(GetComponentInChildren<ShadowCast>().m_ShadowColliders.m_EastShadowCollider);
        if (GetComponentInChildren<ShadowCast>().m_ShadowColliders.m_SouthShadowCollider)
            platformShadowColliders.Add(GetComponentInChildren<ShadowCast>().m_ShadowColliders.m_SouthShadowCollider);
        if (GetComponentInChildren<ShadowCast>().m_ShadowColliders.m_WestShadowCollider)
            platformShadowColliders.Add(GetComponentInChildren<ShadowCast>().m_ShadowColliders.m_WestShadowCollider);

        foreach (GameObject pulleyShadowCollider in platformShadowColliders)
        {
            Destroy(pulleyShadowCollider);
        }
        Destroy(gameObject);
    }
}
