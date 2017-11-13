using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			if (!GameController.m_Resetting) 
			{
				PlayerShadowInteraction.m_Instance.StartShadowShiftOut ();
			}
		}
	}
}
