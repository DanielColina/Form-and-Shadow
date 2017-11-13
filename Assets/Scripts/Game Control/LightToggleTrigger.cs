using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggleTrigger : MonoBehaviour 
{
	public GameObject turnOff;
	public GameObject turnOn;
	private bool triggered;

	void start()
	{
		triggered = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			if (!GameController.m_Resetting) 
			{
				if (!triggered) 
				{
					turnOff.SetActive (false);
					turnOn.SetActive (true);
					triggered = true;
				}
			}
		}
	}
}
