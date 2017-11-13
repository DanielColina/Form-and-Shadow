using UnityEngine;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
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
	public bool m_HardReset = false; //JSM 10.02.17 - Temporary Fix for Level One Side-Piston Puzzle
    public List<PathLocation> m_PathLocations;
    [HideInInspector] public bool m_PausedBySwitch = false;

    bool goingBackwards;
    protected int indexCurrent;
    protected int indexNext;
    bool isPause = false;
    bool isFinished = false;
    float timeCounter = 0f;

    //Temporary for rushing water
    public bool m_RushingWater;
    public AudioClip m_RushingWaterAudioClip;

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
        if(m_PathLocations.Count > 0)
        {
            if (transform.position != m_PathLocations[0].transform.position && m_HardReset && m_PausedBySwitch) //JSM 10.02.17 - Temporary Fix for Level One Side-Piston Puzzle
            {
                indexCurrent = 0;
                indexNext = 1;
                if (m_PathLocations.Count > 0)
                {
                    transform.position = m_PathLocations[indexCurrent].transform.position;
                }
                isFinished = false;
            }
        }


        if (PlayerShadowInteraction.m_CurrentPlayerState != PlayerShadowInteraction.PlayerState.Shifting && !GameController.m_Paused && !m_PausedBySwitch)
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

            if (m_RushingWater)
                SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_RushingWaterAudioClip, 1f, false, 1f);
            float distanceToNextPoint = Vector3.Distance(m_PathLocations[indexCurrent].transform.position, m_PathLocations[indexNext].transform.position);
            float moveSpeed = distanceToNextPoint / m_PathLocations[indexCurrent].travelTimeToNextLocation;


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
}
