using UnityEngine;

public class PressureSwitchMoveGeometry2 : PressureSwitch
{
	[System.Serializable] public class MoveableGeometry
	{
		public GameObject geometryGameObject;
		public float geometryMoveSpeed;
		public Vector3 geometryMoveDirection;
		[HideInInspector] public Vector3 geometryStartPosition;
		[HideInInspector] public Vector3 geometryEndPosition;
		[HideInInspector] public Vector3 geometryEndPosition2;
	}

	public bool Primitive = false;

	[System.Serializable] public class PrimitivePlatform
	{
		public PressureSwitch otherSwitch;
		public bool Activated;
	}

	[SerializeField] MoveableGeometry [] m_TargetGeometry;
	[SerializeField] PrimitivePlatform [] m_OtherPlatform;

	new void Start ()
	{
		base.Start();
		foreach(MoveableGeometry currentTargetGeometry in m_TargetGeometry)
		{
			currentTargetGeometry.geometryStartPosition = currentTargetGeometry.geometryGameObject.transform.position;
			currentTargetGeometry.geometryEndPosition2 = currentTargetGeometry.geometryGameObject.transform.position;
			currentTargetGeometry.geometryEndPosition = currentTargetGeometry.geometryStartPosition + currentTargetGeometry.geometryMoveDirection;
		}
	}

	new void Update ()
	{
		base.Update();

		if (Primitive == true)
		{
			foreach(PrimitivePlatform currentPlatform in m_OtherPlatform)
			{
				if (currentPlatform.otherSwitch.m_PressedByPlayer || currentPlatform.otherSwitch.m_PressedByPushCube)
				{
					currentPlatform.Activated = true;
				}
				else
				{
					currentPlatform.Activated = false;
				}

				if(m_PressedByPlayer || m_PressedByPushCube)
				{
					if(currentPlatform.Activated == true)
					{
						foreach(MoveableGeometry currentTargetGeometry in m_TargetGeometry)
						{
							currentTargetGeometry.geometryGameObject.transform.position = Vector3.MoveTowards(currentTargetGeometry.geometryGameObject.transform.position, 
								currentTargetGeometry.geometryEndPosition2, currentTargetGeometry.geometryMoveSpeed * Time.fixedDeltaTime);
						}
					}
					else
					{
						foreach(MoveableGeometry currentTargetGeometry in m_TargetGeometry)
						{
							currentTargetGeometry.geometryGameObject.transform.position = Vector3.MoveTowards(currentTargetGeometry.geometryGameObject.transform.position, 
								currentTargetGeometry.geometryEndPosition, currentTargetGeometry.geometryMoveSpeed * Time.fixedDeltaTime);
						}
					}
				}
				else
				{
					foreach (MoveableGeometry currentTargetGeometry in m_TargetGeometry)
					{
						if(currentPlatform.Activated == false)
						{
							currentTargetGeometry.geometryGameObject.transform.position = Vector3.MoveTowards(currentTargetGeometry.geometryGameObject.transform.position,
								currentTargetGeometry.geometryStartPosition, currentTargetGeometry.geometryMoveSpeed * Time.fixedDeltaTime);
						}
					}
				}
			}
		}
		else
		{        
			if(m_PressedByPlayer || m_PressedByPushCube)
			{
				foreach(MoveableGeometry currentTargetGeometry in m_TargetGeometry)
				{
					currentTargetGeometry.geometryGameObject.transform.position = Vector3.MoveTowards(currentTargetGeometry.geometryGameObject.transform.position, 
						currentTargetGeometry.geometryEndPosition, currentTargetGeometry.geometryMoveSpeed * Time.fixedDeltaTime);
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