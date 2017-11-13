using UnityEngine;

public class DownwardShadowControl : MonoBehaviour 
{
	void Update ()
    {
        switch(PlayerShadowInteraction.m_CurrentPlayerState)
        {
            case PlayerShadowInteraction.PlayerState.Shadow:
                gameObject.GetComponent<Light>().enabled = false;
                break;
            case PlayerShadowInteraction.PlayerState.Shadowmelded:
                gameObject.GetComponent<Light>().enabled = false;
                break;
            default:
                gameObject.GetComponent<Light>().enabled = true;
                break;
        }
	}
}
