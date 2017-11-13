using UnityEngine;

public class ConveyorCubeSpawner : MonoBehaviour
{
    [SerializeField] Transform m_ConveyorCubeSpawnLocation;
    [SerializeField] GameObject m_ConveyorCubePrefab;
    [Range(1f, 3f)][SerializeField] float m_SpawnCooldown = 1f;

    float spawnTime;
    float personalTime;

    void Start()
    {
        spawnTime = 0;
    }

    void FixedUpdate()
    {
		//if (DynamicSceneLoading.Instance.m_Loading)
		//	return;
        if (PlayerShadowInteraction.m_CurrentPlayerState != PlayerShadowInteraction.PlayerState.Shifting && !GameController.m_Paused)
        {
            personalTime += Time.deltaTime;
        }

        if (personalTime >= spawnTime + m_SpawnCooldown)
        {
            spawnTime = personalTime;
            GameObject pulleyPlatform = Instantiate(m_ConveyorCubePrefab, m_ConveyorCubeSpawnLocation.position, transform.rotation) as GameObject;
        }
    }
}
