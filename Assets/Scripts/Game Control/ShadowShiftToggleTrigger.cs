using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowShiftToggleTrigger : MonoBehaviour {
	bool triggered = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			if (!GameController.m_Resetting && !triggered)
			{
				PlayerShadowInteraction.m_CanShift = !PlayerShadowInteraction.m_CanShift;
				triggered = true;
			}
		}
	}
}
