using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingTrigger : MonoBehaviour {

	public string loadName;
	public string unloadName;

	private void OnTriggerEnter(Collider col)
	{
		if (loadName != "")
			DynamicSceneLoading.Instance.Load (loadName);

		if (unloadName != "")
			StartCoroutine ("UnloadScene");

		PlayerShadowInteraction.m_Instance.m_LightingMaster = GameObject.Find("Lighting_Master_Control");
	}
			
	IEnumerator UnloadScene()
	{
		yield return new WaitForSeconds (.10f);
		DynamicSceneLoading.Instance.m_Loading = true;
		DynamicSceneLoading.Instance.Unload (unloadName);
	}
}
