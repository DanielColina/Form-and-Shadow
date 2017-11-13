using UnityEngine;
using System.Collections.Generic;

public class MovingPlatformOnTrigger : MonoBehaviour
{
    [System.Serializable]
    public struct PathLocation
    {
        public Transform transform;
        public bool pauseAtLocation;
        public float pauseTimeAtLocation;
        public float travelTimeToNextLocation;

        public PathLocation(Transform trans, bool pause, float pauseTime, float travelTime)
        {
            transform = trans;
            pauseAtLocation = pause;
            pauseTimeAtLocation = pauseTime;
            travelTimeToNextLocation = travelTime;
        }
    }
    public bool m_LoopRoute = true;
    public List<PathLocation> m_PathLocations;
    [HideInInspector] public bool m_PausedBySwitch = false;
	public bool m_StartOnEnter = false;
	[SerializeField] bool triggered = false;

    bool goingBackwards;
    protected int indexCurrent;
    protected int indexNext;
    bool isPause = false;
    bool isFinished = false;
    float timeCounter = 0f;

    protected void Start()
    {
        indexCurrent = 0;
        indexNext = 1;
        if (m_PathLocations.Count > 0)
        {
            transform.position = m_PathLocations[indexCurrent].transform.position;
        }
    }

    protected void FixedUpdate()
    {
	
		if (PlayerShadowInteraction.m_CurrentPlayerState != PlayerShadowInteraction.PlayerState.Shifting && !GameController.m_Paused && !m_PausedBySwitch && !m_StartOnEnter)
		{
			if (timeCounter > 0)
			{
				timeCounter -= Time.fixedDeltaTime;
				return;
			}
			else
			{
				isPause = false;
			}

			if (isPause || isFinished) { return; }
			if (m_PathLocations.Count == 0) { return; }

			var distanceToNextPoint = Vector3.Distance(m_PathLocations[indexCurrent].transform.position, m_PathLocations[indexNext].transform.position);
			var moveSpeed = distanceToNextPoint / m_PathLocations[indexCurrent].travelTimeToNextLocation;

			transform.position = Vector3.MoveTowards(transform.position, m_PathLocations[indexNext].transform.position, moveSpeed * Time.fixedDeltaTime);

			if (Vector3.Distance(transform.position, m_PathLocations[indexNext].transform.position) < moveSpeed * Time.fixedDeltaTime)
			{
				indexCurrent = indexNext;

				if (indexCurrent == m_PathLocations.Count - 1)
				{
					if(!m_LoopRoute)
					{
						isFinished = true;
						return;
					}
					goingBackwards = true;
				}
				else if (indexCurrent <= 0)
					goingBackwards = false;

				if (!goingBackwards)
					indexNext += 1;
				else
					indexNext -= 1;

				if(m_PathLocations[indexCurrent].pauseAtLocation)
				{
					timeCounter = m_PathLocations[indexCurrent].pauseTimeAtLocation;
					isPause = true;
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (m_StartOnEnter == true)
		{
			if(other.CompareTag("Player"))
			{
				if (!triggered)
				{
					m_StartOnEnter = false;
					triggered = true;
				}
			}
		}
	}
}
