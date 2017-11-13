using UnityEngine;

public class PulleySystem : MonoBehaviour
{
    public GameObject m_PulleyPlatformPrefab;
    [SerializeField] float m_PulleyTravelTime;
    [Range(1f, 12f)][SerializeField] float m_SpawnCooldown = 1f;
    [HideInInspector] public bool m_Paused;

    float spawnTime;
	float personalTime;

	void Start ()
	{
		spawnTime = 0;
	}
	
	void FixedUpdate ()
	{
		//if (DynamicSceneLoading.Instance.m_Loading)
		//	return;
		if(PlayerShadowInteraction.m_CurrentPlayerState != PlayerShadowInteraction.PlayerState.Shifting && !GameController.m_Paused && !m_Paused)
		{
			personalTime += Time.fixedDeltaTime;	
		}

        if (personalTime >= spawnTime + m_SpawnCooldown)
        {
            spawnTime = personalTime;
            GameObject pulleyPlatform = Instantiate(m_PulleyPlatformPrefab, transform.GetChild(0).position, transform.rotation) as GameObject;
            foreach (Transform pathNode in GetComponentInChildren<Transform>())
            {
                MovingPlatform.PathLocation temp = new MovingPlatform.PathLocation(pathNode, false, 0f, m_PulleyTravelTime);
                pulleyPlatform.GetComponent<PulleyMovingPlatform>().m_PathLocations.Add(temp);
            }
        }
    }
}

