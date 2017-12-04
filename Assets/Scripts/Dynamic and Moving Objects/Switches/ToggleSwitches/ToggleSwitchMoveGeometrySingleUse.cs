using UnityEngine;

public class ToggleSwitchMoveGeometrySingleUse : ToggleSwitch
{
    [System.Serializable] public class MoveableGeometry
    {
        public GameObject geometryGameObject;
        public float geometryMoveSpeed;
        public Vector3 geometryMoveDirection;
        [HideInInspector] public Vector3 geometryStartPosition;
        [HideInInspector] public Vector3 geometryEndPosition;
    }

    [SerializeField] MoveableGeometry[] m_TargetGeometry;

	public bool SingleUse = false; //BB following JSM 12.3.17 - Define whether to ever set Triggered to True
	public bool Triggered = false; //BB following JSM 12.3.17 - If ever set True, player can no longer activate switch

    new void Start()
    {
        base.Start();
        foreach (MoveableGeometry currentTargetGeometry in m_TargetGeometry)
        {
            currentTargetGeometry.geometryStartPosition = currentTargetGeometry.geometryGameObject.transform.position;
            currentTargetGeometry.geometryEndPosition = currentTargetGeometry.geometryStartPosition + currentTargetGeometry.geometryMoveDirection;
        }
    }

    new void Update()
    {
        base.Update();
		if(Triggered == false) //BB following JSM 12.3.17 - If Triggered, Do Nothing when Switch Activated (Would be cleaner if implemented before player interaction)
		{
	        if (m_PressedByPlayer)
	        {
	            foreach (MoveableGeometry currentTargetGeometry in m_TargetGeometry)
	            {
	                currentTargetGeometry.geometryGameObject.transform.position = Vector3.MoveTowards(currentTargetGeometry.geometryGameObject.transform.position,
	                    currentTargetGeometry.geometryEndPosition, currentTargetGeometry.geometryMoveSpeed * Time.fixedDeltaTime);
	            }
				if (SingleUse) //BB following JSM 12.3.17 - Only if Switch set to Single Use, flip the Triggered flag to True
				{
					Triggered = true;
				}
	        }
	        else
	        {
	            foreach (MoveableGeometry currentTargetGeometry in m_TargetGeometry)
	            {
	                currentTargetGeometry.geometryGameObject.transform.position = Vector3.MoveTowards(currentTargetGeometry.geometryGameObject.transform.position,
	                    currentTargetGeometry.geometryStartPosition, currentTargetGeometry.geometryMoveSpeed * Time.fixedDeltaTime);
	            }
	        }
		}	
    }
}