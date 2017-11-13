using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingMasterControl : MonoBehaviour
{
    public static Transform m_NorthFloorTransform;
    public static Transform m_EastFloorTransform;
    public static Transform m_SouthFloorTransform;
    public static Transform m_WestFloorTransform;

	void Awake ()
    {
        if (GameObject.Find("North_Floor"))
            m_NorthFloorTransform = GameObject.Find("North_Floor").transform;
        if (GameObject.Find("East_Floor"))
            m_EastFloorTransform = GameObject.Find("East_Floor").transform;
        if(GameObject.Find("South_Floor"))
            m_SouthFloorTransform = GameObject.Find("South_Floor").transform;
        if (GameObject.Find("West_Floor"))
            m_WestFloorTransform = GameObject.Find("West_Floor").transform;
	}
}
