using UnityEngine;
using System.Collections.Generic;

public class ToggleSwitchDynamicObjectSingleUse : ToggleSwitch
{
    public enum DynamicObjectTargetType { Moving_Platform, Propellor, Pulley_System, Conveyor_Belt }

    [System.Serializable] public struct DynamicTarget
    {
        public DynamicObjectTargetType targetType;
        public GameObject targetObject;
    }

    public List<DynamicTarget> m_TargetObjects;
	public bool SingleUse = false; //JSM 11.5.17 - Define whether to ever set Triggered to True
	public bool Triggered = false; //JSM 11.5.17 - If ever set True, player can no longer activate switch

	new void Start ()
    {
        base.Start();
	}
	
	new void Update ()
    {
        base.Update();
		if(Triggered == false) //JSM 11.5.17 - If Triggered, Do Nothing when Switch Activated (Would be cleaner if implemented before player interaction)
		{
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
				if (SingleUse) //JSM 11.5.17 - Only if Switch set to Single Use, flip the Triggered flag to True
				{
					Triggered = true;
				}
			}
		}
    }
}
