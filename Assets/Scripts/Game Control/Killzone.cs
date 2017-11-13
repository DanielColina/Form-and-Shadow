using UnityEngine;

public class Killzone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!GameController.m_Resetting)
            {
                if(GetComponentInParent<ShadowCollider>())
                {
                    if(GetComponentInParent<ShadowCollider>().m_TransformParent.GetComponent<ShadowmeldObjectControl>().m_ShadowmeldObjectType == ShadowmeldObjectControl.ShadowMeldObjectType.Water)
                        GameController.m_Instance.Respawn("Drown");
                    else
                        GameController.m_Instance.Respawn("Spike");
                }
                else if(GetComponentInParent<ShadowmeldObjectControl>())
                {
                    if (GetComponentInParent<ShadowmeldObjectControl>().m_ShadowmeldObjectType == ShadowmeldObjectControl.ShadowMeldObjectType.Water)
                        GameController.m_Instance.Respawn("Drown");
                    else
                        GameController.m_Instance.Respawn("Spike");
                }
                else
                {
                    GameController.m_Instance.Respawn("Spike");
                }
            }
        }
    }
}
