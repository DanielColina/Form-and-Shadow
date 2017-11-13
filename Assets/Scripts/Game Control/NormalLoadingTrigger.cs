using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NormalLoadingTrigger : MonoBehaviour {

	public string loadName;
	public static NormalLoadingTrigger m_Instance;
	private bool fade;
	private bool load;
	private bool triggered;
	private GameObject loading;


	void Start()
	{
		m_Instance = this;
		fade = false;
		triggered = false;
		load = false;
		GameObject.Find("Fade").GetComponent<Image>().CrossFadeAlpha (0.0f, 3, true);
		loading = GameObject.Find ("Loading");
		loading.SetActive (false);
	}

	void Update()
	{
		if (GameObject.Find ("Fade").GetComponent<Image> ().canvasRenderer.GetAlpha () == 1F)  
		{
			LoadNext ();
		}
	}
	private void OnTriggerEnter(Collider col)
	{
		
		if (col.gameObject.tag == ("Player"))
		{
			if (!triggered)
			{
				triggered = true;
				GameObject.Find ("Fade").GetComponent<Image> ().CrossFadeAlpha (1.0f, 3, true);
			}
		}
	}

	public void LoadNext()
	{
		loading.SetActive (true);
		if (loadName != "")
			SceneManager.LoadScene (loadName, LoadSceneMode.Single);
	}
}

