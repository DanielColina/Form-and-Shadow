using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLoadCamera : MonoBehaviour 
{
	public enum PlayerState {Form, Shadow, Grabbing, Shifting, Shadowmelded, Climbing};
	[Header("Player State and Respawn")]
	public static PlayerState m_CurrentPlayerState;

	// Use this for initialization
	void Start () 
	{
		m_CurrentPlayerState = PlayerState.Form;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_CurrentPlayerState == PlayerState.Form) 
		{
			PlayerShadowInteraction.m_Instance.CheckShadowShiftIn ();	
		}
		
	}
}
