using UnityEngine;

public class ShadowRendererControl : MonoBehaviour 
{
    MeshRenderer[] meshRenderers;

    void Awake()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }
	void Update ()
    {
        switch (PlayerShadowInteraction.m_CurrentPlayerState)
        {
            case PlayerShadowInteraction.PlayerState.Shadow:
                RenderShadow();
                break;
            default:
                RenderFormandShadow();
                break;
        }
    }

    void RenderFormandShadow()
    {
        foreach (MeshRenderer renderer in meshRenderers)
        {
			if (renderer.gameObject.tag == "Solid_Mesh") {
				renderer.enabled = true;
			} else if (renderer.gameObject.tag != "Transparent_Mesh") {
				renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
			}
        }
    }

    void RenderShadow()
    {
        foreach(MeshRenderer renderer in meshRenderers)
        {
			if (renderer.gameObject.tag == "Solid_Mesh") {
				renderer.enabled = false;
			} else if (renderer.gameObject.tag != "Transparent_Mesh") {
				renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
			}
            
        }
    }

    void RenderNone()
    {
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }
    }
}
