using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMeldTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			if (!GameController.m_Resetting && PlayerShadowInteraction.m_CurrentPlayerState == PlayerShadowInteraction.PlayerState.Form) 
			{
				PlayerShadowInteraction.m_Instance.EnterShadowmeld ();
			}
		}
	}
}
