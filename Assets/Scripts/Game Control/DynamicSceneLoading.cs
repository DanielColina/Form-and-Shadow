using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicSceneLoading : MonoBehaviour {

	public static DynamicSceneLoading Instance{ set; get; }
	public bool m_Loading;

	private void Awake()
	{
		Instance = this;
		Load ("Loading Player");
		Load ("Transition");
		Load ("Master Mechanics Test");
		m_Loading = false;
	}

	
	public void Load(string sceneName)
	{
		if (!SceneManager.GetSceneByName (sceneName).isLoaded)
			SceneManager.LoadScene (sceneName, LoadSceneMode.Additive);
	}

	public void Unload(string sceneName)
	{
		if (SceneManager.GetSceneByName (sceneName).isLoaded)
			SceneManager.UnloadSceneAsync (sceneName);
		m_Loading = false;
	}
}
