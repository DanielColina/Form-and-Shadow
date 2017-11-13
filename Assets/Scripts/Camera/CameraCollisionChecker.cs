using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionChecker : MonoBehaviour {

	BoxCollider box;
	MeshCollider mes;
	GameObject m_Camera;
	CameraControl control;

	void Start()
	{
		m_Camera = GameObject.Find ("Main_Camera");
		control = GameObject.Find ("Main_Camera").GetComponent<CameraControl> ();
		box = this.GetComponent<BoxCollider>();
		mes = this.GetComponent<MeshCollider> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance(transform.position, m_Camera.transform.position) < 5f)
		{
			if (box) 
			{
				if (box.bounds.Contains (m_Camera.transform.position)) 
				{
					control.messaged = true;
					control.revertDelay = 30;
				} 
			}
			else if (mes)
			{
				if (mes.bounds.Contains(m_Camera.transform.position))
				{
					control.messaged = true;
					control.revertDelay = 30;
				}
			}
		}
	}
}
