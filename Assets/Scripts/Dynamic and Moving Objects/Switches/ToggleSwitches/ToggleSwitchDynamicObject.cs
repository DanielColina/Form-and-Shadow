using UnityEngine;
using System.Collections.Generic;

public class ToggleSwitchDynamicObject : ToggleSwitch
{
    public enum DynamicObjectTargetType { Moving_Platform, Propellor, Pulley_System, Conveyor_Belt }

    [System.Serializable] public struct DynamicTarget
    {
        public DynamicObjectTargetType targetType;
        public GameObject targetObject;
    }

    public List<DynamicTarget> m_TargetObjects;

	new void Start ()
    {
        base.Start();
	}
	
	new void Update ()
    {
        base.Update();
        if(m_PressedByPlayer)
        {
            foreach(DynamicTarget target in m_TargetObjects)
            {
                switch (target.targetType)
                {
                    case DynamicObjectTargetType.Moving_Platform:
                        target.targetObject.GetComponentInChildren<MovingPlatform>().m_PausedBySwitch = true;
                        break;
                    case DynamicObjectTargetType.Propellor:
                        target.targetObject.GetComponentInChildren<PropellorPlatform>().m_Paused = true;
                        break;
                    case DynamicObjectTargetType.Pulley_System:
                        target.targetObject.GetComponentInChildren<PulleySystem>().m_Paused = true;
                        break;
                    case DynamicObjectTargetType.Conveyor_Belt:
                        target.targetObject.GetComponentInChildren<ConveyorBelt>().m_Paused = true;
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            foreach (DynamicTarget target in m_TargetObjects)
            {
                switch (target.targetType)
                {
                    case DynamicObjectTargetType.Moving_Platform:
                        target.targetObject.GetComponentInChildren<MovingPlatform>().m_PausedBySwitch = false;
                        break;
                    case DynamicObjectTargetType.Propellor:
                        target.targetObject.GetComponentInChildren<PropellorPlatform>().m_Paused = false;
                        break;
                    case DynamicObjectTargetType.Pulley_System:
                        target.targetObject.GetComponentInChildren<PulleySystem>().m_Paused = false;
                        break;
                    case DynamicObjectTargetType.Conveyor_Belt:
                        target.targetObject.GetComponentInChildren<ConveyorBelt>().m_Paused = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
