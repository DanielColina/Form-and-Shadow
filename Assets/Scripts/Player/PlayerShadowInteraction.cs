using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShadowInteraction : MonoBehaviour
{
	public static PlayerShadowInteraction m_Instance;
	[Header("Master References")]
	[HideInInspector] public GameObject m_LightingMaster;
	[HideInInspector] public GameObject m_LightSourceAligned;

	[Header("Shadow Shift Variables")]
	public AudioClip m_ShiftInAudioClip;
	public AudioClip m_ShiftOutAudioClip;
	public AudioClip m_ShiftFailAudioClip;
	public LayerMask m_ShadowShiftLayerMask;
	public LayerMask m_BlockLayerMask;
	public GameObject m_ExitParticle;
	public bool m_ShadowshiftAvailable;
	public static bool m_CanShift;
	[SerializeField] GameObject m_ShadowShiftFollowPrefab;
	[SerializeField] float m_ShadowShiftDuration;
	[HideInInspector] public static GameObject m_ShadowShiftFollowObject;
	List<GameObject> m_ShadowShiftOutPlatforms;
	List<Vector3> m_ShadowShiftOutLocations;
	List<Material> m_PlatformMaterials;
	List<GameObject> m_ExitParticles;
	public LayerMask m_FormMask;
	public LayerMask m_DefaultMask;
	public LayerMask m_PlayerCollisionOnlyMask;

	[Header("Shadowmeld Variables and References")]
	public GameObject m_PlayerMesh;
	public GameObject m_CloakMesh;
	public GameObject m_HoodMesh;
	public Material m_NormalPlayerMaterial;
	public Material m_ShadowmeldPlayerMaterial;
	public Material m_NormalCloakMaterial;
	public Material m_ShadowmeldCloakMaterial;
	public AudioClip m_MeldEnterAudioClip;
	public AudioClip m_MeldExitAudioClip;
	public bool m_ShadowmeldAvailable;
	[Range(0, 20)][SerializeField] float m_ShadowmeldResourceCost;
	[Range(5, 50)][SerializeField] float m_ShadowmeldResourceRegen;
	public float m_MaxShadowmeldResource;
	[HideInInspector] public float m_CurrentShadowmeldResource;

	public enum PlayerState {Form, Shadow, Grabbing, Shifting, Shadowmelded};
	[Header("Player State and Respawn")]
	public static PlayerState m_CurrentPlayerState;
	[HideInInspector] public Vector3 m_PlayerRespawnPosition;
	[HideInInspector] public bool m_ZAxisTransition;

	Material playerStartMaterial;
	int currentPlatformIndex;
	float playerShiftInOffset;
	Vector3 cameraPanInStartPosition;
	Vector3 cameraRelativeDirectionOffset;
	float cameraPanInRelativeDistance;
	bool highlighted;
	bool shadowStart;
	bool madeTransparent;
	public int shiftDelay;

	void Start()
	{
		m_Instance = this;
		m_CanShift = true;
		m_PlayerRespawnPosition = transform.position;
		m_CurrentPlayerState = PlayerState.Form;
		m_CurrentShadowmeldResource = m_MaxShadowmeldResource;
		m_LightingMaster = GameObject.Find("Lighting_Master_Control");
		currentPlatformIndex = 0;
		playerStartMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
		highlighted = false;
		madeTransparent = false;
		m_ShadowShiftOutPlatforms = new List<GameObject>();

		if (GameObject.Find ("Loading_Camera") != null) 
		{
			shadowStart = true;
			shiftDelay = 15;
		} 
		else 
		{
			shadowStart = false;
			shiftDelay = 0;
		}
	}

	void Update()
	{
		if(!GameController.m_Resetting && !GameController.m_Paused)
		{
			if (shiftDelay > 0)
				shiftDelay--;

			switch(m_CurrentPlayerState)
			{
			case PlayerState.Form:
				if (m_ShadowshiftAvailable)
					UpdateShadowShiftMaster();
				if (m_ShadowmeldAvailable)
					UpdateShadowmeldMaster();
				break;
			case PlayerState.Shadow:
				UpdateShadowShiftMaster();
				break;
			case PlayerState.Grabbing:
				break;
			case PlayerState.Shadowmelded:
				UpdateShadowmeldMaster();
				break;
			case PlayerState.Shifting:
				if(!CameraControl.cameraIsPanning)
					UpdateShadowShiftingInput();
				break;
			}
		}
	}

	#region Shadowmeld Methods
	void UpdateShadowmeldMaster()
	{
		UpdateShadowmeldInput();
		UpdateShadowmeldResource();
	}

	void UpdateShadowmeldInput()
	{
		if (Input.GetButtonDown("Shadowmeld"))
		{
			switch (m_CurrentPlayerState)
			{
			case PlayerState.Form:
				if (m_CurrentShadowmeldResource > 0)
					EnterShadowmeld();
				break;
			case PlayerState.Shadowmelded:
				CheckShadowmeldExit();
				break;
			}
		}
	}

	void UpdateShadowmeldResource()
	{
		switch(m_CurrentPlayerState)
		{
		case PlayerState.Form:
			if (m_CurrentShadowmeldResource < m_MaxShadowmeldResource)
				m_CurrentShadowmeldResource += m_ShadowmeldResourceRegen * Time.deltaTime;
			break;
		case PlayerState.Shadowmelded:
			if (m_CurrentShadowmeldResource > 0)
				m_CurrentShadowmeldResource -= m_ShadowmeldResourceCost * Time.deltaTime;
			if (m_CurrentShadowmeldResource < 0)
				CheckShadowmeldExit();
			break;
		}
	}

	public void EnterShadowmeld()
	{
		SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_MeldEnterAudioClip, 1f, false, 1f);
		m_CurrentPlayerState = PlayerState.Shadowmelded;
		TogglePlayerShadowmeldAppearance(true);
	}

	void CheckShadowmeldExit()
	{
		ExitShadowmeld();
	}

	public void ExitShadowmeld()
	{
		SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_MeldExitAudioClip, 1f, false, 1f);
		m_CurrentPlayerState = PlayerState.Form;
		TogglePlayerShadowmeldAppearance(false);
	}
	#endregion

	#region Shadow Shift Methods
	void UpdateShadowShiftMaster()
	{
		UpdateShadowShiftInput();        
	}

	void UpdateShadowShiftInput()
	{
		if ((Input.GetButtonDown("Shadowshift") && shiftDelay <= 0) || (shadowStart && shiftDelay <= 0))
		{
			switch (m_CurrentPlayerState)
			{
			case PlayerState.Form:
				if (m_CanShift)
					CheckShadowShiftIn();
				break;
			case PlayerState.Shadow:
				if (m_CanShift)
					StartShadowShiftOut();
				break;
			}
		}
	}

	void UpdateShadowShiftingInput()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			Vector3 targetLocation = PlayerController.m_Instance.m_PlayerCollision.transform.position;
			if (currentPlatformIndex + 1 < m_ShadowShiftOutPlatforms.Count)
			{
				currentPlatformIndex += 1;
				if(m_ZAxisTransition)
				{
					targetLocation.y = m_ShadowShiftOutLocations[currentPlatformIndex].y + .5f;
					targetLocation.z = m_ShadowShiftOutPlatforms[currentPlatformIndex].transform.position.z;
				}
				else
				{
					targetLocation.x = m_ShadowShiftOutPlatforms[currentPlatformIndex].transform.position.x;
					targetLocation.y = m_ShadowShiftOutLocations[currentPlatformIndex].y + .5f;
				}

				StartCoroutine(ShiftPlayerOut(m_ShadowShiftFollowObject.transform.position, targetLocation, false));
			}
		}
		if(Input.GetKeyDown(KeyCode.W))
		{
			Vector3 targetLocation = PlayerController.m_Instance.m_PlayerCollision.transform.position;
			if (currentPlatformIndex == 0)
			{
				// If the player is at index 0 of the platforms, or the first platform, and they try to go forward,
				// they return to the wall

				//DRF 11/27/2017 platforms return to normal if player returns to wall, should fix pink bug
				if (madeTransparent == true) 
				{
					for (int i = 0; i < CameraControl.shad.Count; i++) 
					{
						CameraControl.transparentObjects [i].GetComponent<Renderer> ().material.shader = CameraControl.shad [i];
					}
					CameraControl.transparentObjects.Clear ();
					CameraControl.shad.Clear ();
					madeTransparent = false;
				}
				RaycastHit hit;
				Physics.Raycast(m_ShadowShiftFollowObject.transform.position, m_LightSourceAligned.GetComponent<LightSourceControl>().m_LightSourceForward, out hit, Mathf.Infinity, m_ShadowShiftLayerMask);
				targetLocation = hit.point + m_LightSourceAligned.GetComponent<LightSourceControl>().m_LightSourceForward;            
				StartCoroutine(ShiftPlayerIn(m_ShadowShiftFollowObject.transform.position, targetLocation, 
					-m_LightSourceAligned.GetComponent<LightSourceControl>().m_LightSourceForward * Camera.main.GetComponent<CameraControl>().m_DistanceToPlayer2D));
			}
			else
			{
				currentPlatformIndex -= 1;
				if (m_ZAxisTransition)
				{
					targetLocation.y = m_ShadowShiftOutLocations[currentPlatformIndex].y + .5f;
					targetLocation.z = m_ShadowShiftOutPlatforms[currentPlatformIndex].transform.position.z;
				}
				else
				{
					targetLocation.x = m_ShadowShiftOutPlatforms[currentPlatformIndex].transform.position.x;
					targetLocation.y = m_ShadowShiftOutLocations[currentPlatformIndex].y + .5f;
				}
				StartCoroutine(ShiftPlayerOut(m_ShadowShiftFollowObject.transform.position, targetLocation, false));
			}
		}

		if(Input.GetButtonDown("Shadowshift"))
		{
			FinishShiftingOut();
		}
	}

	public void CheckShadowShiftIn()
	{
		RaycastHit shadowWallHit;
		RaycastHit blockHit;
		if(CheckLightSourceAligned() != null)
		{
			Debug.Log("Aligned light source found!");
			switch(m_LightSourceAligned.GetComponent<LightSourceControl>().m_CurrentFacingDirection)
			{
			case LightSourceControl.FacingDirection.North:
				m_ZAxisTransition = true;
				break;
			case LightSourceControl.FacingDirection.East:
				m_ZAxisTransition = false;
				break;
			case LightSourceControl.FacingDirection.South:
				m_ZAxisTransition = true;
				break;
			case LightSourceControl.FacingDirection.West:
				m_ZAxisTransition = false;
				break;
			}
			// Cast a sphere in the direction of the most aligned light source on the
			// shadow wall layer
			if (Physics.Raycast(transform.position + new Vector3(0, 0.6f, 0), m_LightSourceAligned.GetComponent<LightSourceControl>().m_LightSourceForward, out shadowWallHit, Mathf.Infinity, m_ShadowShiftLayerMask))
			{
				Debug.Log("Hit a shadow wall");
				if (!Physics.SphereCast(transform.position + new Vector3(0, 0.6f, 0), 0.2f, m_LightSourceAligned.GetComponent<LightSourceControl>().m_LightSourceForward, out blockHit, Vector3.Distance(transform.position, shadowWallHit.point), m_BlockLayerMask))
				{
					if (!Physics.Raycast(shadowWallHit.point, m_LightSourceAligned.GetComponent<LightSourceControl>().m_LightSourceForward, Mathf.Infinity, 1 << 11))
					{
						if (m_ZAxisTransition)
							playerShiftInOffset = transform.position.z;
						else
							playerShiftInOffset = transform.position.x;
						TogglePlayerMeshVisibility(true);
						TogglePlayerCollision(true);
						SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_ShiftInAudioClip, 1f, false, 1f);
						PlayerAnimator.m_Instance.SetShifting(true);    
						StartCoroutine(ShiftPlayerIn(transform.position, shadowWallHit.point - new Vector3(0, 0.6f, 0) + m_LightSourceAligned.GetComponent<LightSourceControl>().m_LightSourceForward,
							-m_LightSourceAligned.GetComponent<LightSourceControl>().m_LightSourceForward * 8));
					}
					else
						SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_ShiftFailAudioClip, 1f, false, 1f);
				}
				else
					SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_ShiftFailAudioClip, 1f, false, 1f);
			}
			else
				SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_ShiftFailAudioClip, 1f, false, 1f);
		}
		else
			SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_ShiftFailAudioClip, 1f, false, 1f);
	}

	public void StartShadowShiftOut()
	{
		SetupShadowShiftOut();
		m_CurrentPlayerState = PlayerState.Shifting;

		Vector3 targetLocation = PlayerController.m_Instance.m_PlayerCollision.transform.position;
		if (m_ZAxisTransition)
		{
			switch (m_ShadowShiftOutPlatforms.Count)
			{
			case 0:
				targetLocation.z = playerShiftInOffset;
				break;
			default:
				targetLocation.y = m_ShadowShiftOutLocations[0].y + .5f;
				targetLocation.z = m_ShadowShiftOutPlatforms[0].transform.position.z;
				break;
			}
		}
		else
		{
			switch (m_ShadowShiftOutPlatforms.Count)
			{
			case 0:
				targetLocation.x = playerShiftInOffset;
				break;
			default:
				targetLocation.x = m_ShadowShiftOutPlatforms[0].transform.position.x;
				targetLocation.y = m_ShadowShiftOutLocations[0].y + .5f;
				break;
			}
		}

		Ray ray = new Ray(PlayerController.m_Instance.m_PlayerCollision.transform.position, -m_LightSourceAligned.GetComponent<LightSourceControl>().m_LightSourceForward);
		RaycastHit hit;
		Physics.Raycast(ray, out hit, Mathf.Infinity, m_ShadowShiftLayerMask);

		SoundManager.m_Instance.PlaySound3DOneShot(transform.position, m_ShiftOutAudioClip, 1f, false, 1f);
		Vector3 startLocation = hit.point;
		TogglePlayerCollision(true);
		PlayerAnimator.m_Instance.SetShifting(true);
		if (m_ShadowShiftOutPlatforms.Count == 0 || m_ShadowShiftOutPlatforms.Count == 1)
			StartCoroutine(ShiftPlayerOut(startLocation, targetLocation, true));
		else
			StartCoroutine(ShiftPlayerOut(startLocation, targetLocation, false));
	}

	void SetupShadowShiftOut()
	{
		m_ShadowShiftOutPlatforms = GetTransferPlatforms();
		m_ShadowShiftOutLocations = GetTransferLocations ();

		if (m_ShadowShiftOutPlatforms.Count != 0)
		{
			m_ShadowShiftOutPlatforms.Sort(delegate (GameObject t1, GameObject t2) {
				return Vector3.Distance(t1.transform.position, PlayerController.m_Instance.m_PlayerCollision.transform.position).CompareTo(Vector3.Distance(t2.transform.position, PlayerController.m_Instance.m_PlayerCollision.transform.position));
			});
			m_ShadowShiftOutLocations.Sort (delegate(Vector3 v1, Vector3 v2) {
				return Vector3.Distance (v1, PlayerController.m_Instance.m_PlayerCollision.transform.position).CompareTo (Vector3.Distance (v2, PlayerController.m_Instance.m_PlayerCollision.transform.position));
			});
		}
	}

	List<GameObject> GetTransferPlatforms()
	{
		List<GameObject> transferPlatforms = new List<GameObject>();
		// Cast a ray down from the player shadow and store all shadow colliders hit in an array of RaycastHits
		RaycastHit firstPlatformHit;
		Debug.DrawRay(PlayerController.m_Instance.m_PlayerCollision.transform.position, Vector3.down, Color.red, 10f);
		if (Physics.SphereCast(PlayerController.m_Instance.m_PlayerCollision.transform.position + new Vector3(0, 1, 0), 0.25f, Vector3.down, out firstPlatformHit, PlayerController.m_Instance.m_PlayerCollision.transform.position.y, 1 << 11))
		{
			RaycastHit[] hits;
			hits = Physics.SphereCastAll(firstPlatformHit.point - new Vector3(0, 0.35f, 0), 0.25f, Vector3.down, PlayerController.m_Instance.m_PlayerCollision.GetComponent<CapsuleCollider>().height / 3, 1 << 11);
			// Then, create a list of gameobjects and for each RaycastHit in hits, add the hit collider's gameobject to the list of transferPlatforms
			foreach (RaycastHit hit in hits)
			{
				Debug.Log(hit.collider.gameObject);
				// Prevent killzone colliders from being added as shadow collider objects
				if (hit.collider.GetComponentInParent<ShadowCollider> ().m_TransformParent.GetComponent<ShadowCast> ().m_CastedShadowType != ShadowCast.CastedShadowType.Killzone_Shadow
					&& hit.collider.GetComponentInParent<ShadowCollider> ().m_TransformParent.GetComponent<ShadowmeldObjectControl> ().m_ShadowmeldObjectType 
					!= ShadowmeldObjectControl.ShadowMeldObjectType.Flat_Spikes) 
				{
					transferPlatforms.Add (hit.collider.gameObject.GetComponentInParent<ShadowCollider> ().m_TransformParent.gameObject);
				}
			}
		}
		return transferPlatforms;
	}

	List<Vector3> GetTransferLocations ()
	{
		List<Vector3> transferLocations = new List<Vector3> ();
		RaycastHit[] platformHit = new RaycastHit[3];
		List<Collider> mainPlatformsHit = new List<Collider>();
		List<Collider> auxPlatformsHit = new List<Collider>();

		bool rightHit = false;
		bool leftHit = false;

		RaycastHit firstPlatformHit;
		print("before");
		if (Physics.SphereCast(PlayerController.m_Instance.m_PlayerCollision.transform.position + new Vector3(0, 1, 0), 0.25f, Vector3.down, out firstPlatformHit, PlayerController.m_Instance.m_PlayerCollision.transform.position.y, 1 << 11, QueryTriggerInteraction.Ignore)) {
			var raycastOrigin = firstPlatformHit.point + new Vector3(0, 0.5f, 0);
			var leftRaycastOrigin = raycastOrigin;
			var rightRaycastOrigin = raycastOrigin;

			if (m_ZAxisTransition) {
				leftRaycastOrigin.x += -0.35f;
				rightRaycastOrigin.x += 0.35f;
			}
			else {
				leftRaycastOrigin.z += -0.35f;
				rightRaycastOrigin.z += 0.35f;
			}
			print("after");
			var maxDist = PlayerController.m_Instance.m_PlayerCollision.GetComponent<CapsuleCollider>().height / 3 + 0.5f;

			//while (Physics.Raycast(raycastOrigin, Vector3.down, out platformHit[0], maxDist, 1 << 11, QueryTriggerInteraction.Ignore)) { 
			//    mainPlatformsHit.Add(platformHit[0].collider);
			//    platformHit[0].collider.isTrigger = true;
			//    print(platformHit[0].collider.GetComponentInParent<ShadowCollider>().m_TransformParent.name);


			//}


			while (Physics.Raycast(raycastOrigin, Vector3.down, out platformHit[0], maxDist, 1 << 11, QueryTriggerInteraction.Ignore)) {
				print("mid");
				if (platformHit[0].collider.GetComponentInParent<GearPlatform>()) {
					var gearPoint = platformHit[0].collider.GetComponentInParent<ShadowCollider>().m_TransformParent.position;
					gearPoint.y = PlayerController.m_Instance.m_PlayerCollision.transform.position.y;

					if (m_ZAxisTransition) {
						gearPoint.x = platformHit[0].point.x;
					}
					else {
						gearPoint.z = platformHit[0].point.z;
					}

					transferLocations.Add(gearPoint);
					mainPlatformsHit.Add(platformHit[0].collider);
					platformHit[0].collider.GetComponent<MeshCollider>().convex = true;
					platformHit[0].collider.isTrigger = true;

				}
				else if (platformHit[0].collider.GetComponent<PropellorPlatformShadowCollider>() && !platformHit[0].collider.GetComponentInParent<ShadowCollider>().m_TransformParent.GetComponentInChildren<Killzone>()) {
					var propellorPoint = platformHit[0].collider.GetComponentInParent<ShadowCollider>().m_TransformParent.position;
					propellorPoint.y = PlayerController.m_Instance.m_PlayerCollision.transform.position.y;
					transferLocations.Add(propellorPoint);
					mainPlatformsHit.Add(platformHit[0].collider);
					platformHit[0].collider.isTrigger = true;

				}
				else {
					print("ELSE");
					while (Physics.Raycast(leftRaycastOrigin, Vector3.down, out platformHit[1], maxDist, 1 << 11, QueryTriggerInteraction.Ignore)) {
						print("left");
						if (platformHit[1].collider != platformHit[0].collider) {
							platformHit[1].collider.isTrigger = true;
							auxPlatformsHit.Add(platformHit[1].collider);
						}
						else {
							leftHit = true;
							break;
						}
					}

					foreach (Collider auxCollider in auxPlatformsHit) {
						auxCollider.isTrigger = false;
					}

					auxPlatformsHit.Clear();

					while (Physics.Raycast(rightRaycastOrigin, Vector3.down, out platformHit[2], maxDist, 1 << 11, QueryTriggerInteraction.Ignore)) {
						print("right");
						if (platformHit[2].collider != platformHit[0].collider) {
							platformHit[2].collider.isTrigger = true;
							auxPlatformsHit.Add(platformHit[2].collider);
						}
						else {
							rightHit = true;
							break;
						}
					}

					mainPlatformsHit.Add(platformHit[0].collider);
					platformHit[0].collider.isTrigger = true;

					foreach (Collider auxCollider in auxPlatformsHit) {
						auxCollider.isTrigger = false;
					}

					auxPlatformsHit.Clear();

					print(platformHit[0].collider.GetComponentInParent<ShadowCollider>().m_TransformParent.name);
					var platformPoint = platformHit[0].collider.GetComponentInParent<ShadowCollider>().m_TransformParent.position;
					platformPoint.y = platformHit[0].point.y;
					if (m_ZAxisTransition)
						platformPoint.x = platformHit[0].point.x;
					else
						platformPoint.z = platformHit[0].point.z;

					if (rightHit && leftHit) {
						transferLocations.Add(platformPoint);
					}
					else if (rightHit) {
						if (m_ZAxisTransition)
							transferLocations.Add(platformPoint + new Vector3(0.35f, 0, 0));
						else
							transferLocations.Add(platformPoint + new Vector3(0, 0, 0.35f));
					}
					else if (leftHit) {
						if (m_ZAxisTransition)
							transferLocations.Add(platformPoint + new Vector3(-0.35f, 0, 0));
						else
							transferLocations.Add(platformPoint + new Vector3(0, 0, -0.35f));
					}
				}
			}

			foreach (Collider mainCollider in mainPlatformsHit) {
				mainCollider.isTrigger = false;
				if (mainCollider.GetComponentInParent<GearPlatform>()) {
					mainCollider.isTrigger = false;

					mainCollider.GetComponent<MeshCollider>().convex = false;
				}
			}

			mainPlatformsHit.Clear();
		}

		return transferLocations;
	}


	IEnumerator ShiftPlayerIn(Vector3 start, Vector3 target, Vector3 cameraOffset)
	{
		m_CurrentPlayerState = PlayerState.Shifting;
		CameraControl.cameraIsPanning = true;

		if (m_ShadowShiftFollowObject == null)
			m_ShadowShiftFollowObject = Instantiate(m_ShadowShiftFollowPrefab, start, Quaternion.identity);

		cameraPanInStartPosition = Camera.main.transform.position;
		cameraRelativeDirectionOffset = (cameraPanInStartPosition - transform.position).normalized;

		float panStart = Time.time;

		while(Time.time < panStart + m_ShadowShiftDuration)
		{
			m_ShadowShiftFollowObject.transform.position = Vector3.Lerp(start, target, (Time.time - panStart) / m_ShadowShiftDuration);
			Camera.main.transform.position = Vector3.Lerp(cameraPanInStartPosition, target + cameraOffset, (Time.time - panStart) / m_ShadowShiftDuration);
			yield return null;
		}
		CameraControl.cameraIsPanning = false;
		FinishShiftIn();
	}

	IEnumerator ShiftPlayerOut(Vector3 start, Vector3 target, bool finish)
	{
		CameraControl.cameraIsPanning = true;
		if (m_ShadowShiftFollowObject == null)
			m_ShadowShiftFollowObject = Instantiate(m_ShadowShiftFollowPrefab, start, Quaternion.identity);

		Vector3 startPos = Camera.main.transform.position;
		float panStart = Time.time;
		if (!highlighted)
			m_PlatformMaterials = GetMaterials ();

		Vector3 targetLoc = PlayerController.m_Instance.m_PlayerCollision.transform.position;
		while (Time.time < panStart + m_ShadowShiftDuration)
		{
			targetLoc = PlayerController.m_Instance.m_PlayerCollision.transform.position;
			m_ShadowShiftFollowObject.transform.position = Vector3.Lerp (start, target, (Time.time - panStart) / m_ShadowShiftDuration);
			if (finish) {
				Camera.main.transform.position = Vector3.Lerp (startPos, target + cameraRelativeDirectionOffset * Camera.main.GetComponent<CameraControl> ().m_DistanceFollow, (Time.time - panStart) / m_ShadowShiftDuration);
			} 
			else 
			{
				if (!highlighted) 
				{
					HighlightPlatforms (m_PlatformMaterials);
					highlighted = true;
				}
				if (m_ZAxisTransition) 
				{
					targetLoc.x = m_ShadowShiftFollowObject.transform.position.x + (Vector3.Distance (m_ShadowShiftOutLocations [0], m_ShadowShiftOutLocations [m_ShadowShiftOutLocations.Count - 1]) / 4);
					targetLoc.y = m_ShadowShiftOutLocations [m_ShadowShiftOutLocations.Count - 1].y + .5f;
					targetLoc.z = m_ShadowShiftOutPlatforms [m_ShadowShiftOutPlatforms.Count - 1].transform.position.z;
				} 
				else 
				{
					targetLoc.x = m_ShadowShiftOutPlatforms [m_ShadowShiftOutPlatforms.Count - 1].transform.position.x;
					targetLoc.y = m_ShadowShiftOutLocations [m_ShadowShiftOutLocations.Count - 1].y + .5f;
					targetLoc.z = m_ShadowShiftOutLocations [m_ShadowShiftOutLocations.Count - 1].z + (Vector3.Distance (m_ShadowShiftOutLocations [0], m_ShadowShiftOutLocations [m_ShadowShiftOutLocations.Count - 1]) / 2); 
				}
				Camera.main.transform.position = Vector3.Lerp (startPos, targetLoc + cameraRelativeDirectionOffset * Camera.main.GetComponent<CameraControl> ().m_DistanceFollow, (Time.time - panStart) / m_ShadowShiftDuration);

			}
			yield return null;
		}

		Camera.main.transform.position = targetLoc + cameraRelativeDirectionOffset * Camera.main.GetComponent<CameraControl> ().m_DistanceFollow;

		//11.12.17 transparency logic updated to work with the new Solid_Mesh system
		if (!madeTransparent) 
		{
			Camera.main.transform.position = targetLoc + cameraRelativeDirectionOffset * Camera.main.GetComponent<CameraControl> ().m_DistanceFollow;
			Debug.Log ("Reached distance");

			Vector3 dir = m_ShadowShiftFollowObject.transform.position - Camera.main.transform.position;
			RaycastHit[] hits;
			List<Renderer> rend = new List<Renderer> ();

			Debug.DrawRay (Camera.main.transform.position, dir);
			hits = Physics.SphereCastAll(Camera.main.transform.position, 1f, dir, Vector3.Distance(Camera.main.transform.position, m_ShadowShiftFollowObject.transform.position), m_FormMask, QueryTriggerInteraction.Ignore);
			Debug.Log (hits.Length);

			for (int i = 0; i < hits.Length; i++) 
			{

				RaycastHit hit = hits [i];
				Debug.Log (hit.collider.transform.gameObject.name);
				Renderer checkRenders = null;
				if (hit.collider.transform.gameObject.tag == "Solid_Mesh")
					checkRenders = hit.transform.gameObject.GetComponent<Renderer> ();
				else 
				{
					//DRF 11.27.2017 added check to prevent soft locking
					if (hit.transform.parent.childCount != null) 
					{
						for (int j = 0; j < hit.transform.parent.childCount; j++) 
						{
							if (hit.transform.parent.GetChild (0).tag == "Solid_Mesh") 
							{
								checkRenders = hit.transform.parent.GetChild (0).GetComponent<Renderer> ();
							}
						}
					}
				}

				Debug.Log (checkRenders);


				if (checkRenders != null) 
				{
					rend.Add (checkRenders);
					CameraControl.transparentObjects.Add (checkRenders.gameObject);
					CameraControl.shad.Add (checkRenders.material.shader);

					checkRenders.material.shader = Shader.Find ("Transparent/Diffuse");
					Color tempColor = checkRenders.material.color;
					tempColor.a = 0.3F;
					checkRenders.material.color = tempColor;
				}
			}

			hits = Physics.SphereCastAll(Camera.main.transform.position, 1f, dir, Vector3.Distance(Camera.main.transform.position, m_ShadowShiftFollowObject.transform.position), m_DefaultMask, QueryTriggerInteraction.Ignore);

			for (int i = 0; i < hits.Length; i++) 
			{

				RaycastHit hit = hits [i];
				Debug.Log (hit.collider.transform.gameObject.name);
				Renderer checkRenders = null;
				if (hit.collider.transform.gameObject.tag == "Solid_Mesh")
					checkRenders = hit.transform.gameObject.GetComponent<Renderer> ();
				else 
				{
					if (hit.transform.parent.childCount != null) 
					{
						for (int j = 0; j < hit.transform.parent.childCount; j++) 
						{
							if (hit.transform.parent.GetChild (0).tag == "Solid_Mesh") 
							{
								checkRenders = hit.transform.parent.GetChild (0).GetComponent<Renderer> ();
							}
						}
					}
				}
				Debug.Log (checkRenders);


				if (checkRenders != null) 
				{
					rend.Add (checkRenders);
					CameraControl.transparentObjects.Add (checkRenders.gameObject);
					CameraControl.shad.Add (checkRenders.material.shader);
					checkRenders.material.shader = Shader.Find ("Transparent/Diffuse");
					Color tempColor = checkRenders.material.color;
					tempColor.a = 0.3F;
					checkRenders.material.color = tempColor;
				}
			}

			//DRF 11.12.17 Added logic to deal with PlayerCollisionOnly layer on exit shift. Inefficient way of writing code,
			//not inefficient performance wise. Will clean up later if higher priority fixes are implemented
			hits = Physics.SphereCastAll(Camera.main.transform.position, 1f, dir, Vector3.Distance(Camera.main.transform.position, m_ShadowShiftFollowObject.transform.position), m_PlayerCollisionOnlyMask, QueryTriggerInteraction.Ignore);

			for (int i = 0; i < hits.Length; i++) 
			{

				RaycastHit hit = hits [i];
				Debug.Log (hit.collider.transform.gameObject.name);
				Renderer checkRenders = null;
				if (hit.collider.transform.gameObject.tag == "Solid_Mesh")
					checkRenders = hit.transform.gameObject.GetComponent<Renderer> ();
				else 
				{
					if (hit.transform.parent.childCount != null) 
					{
						for (int j = 0; j < hit.transform.parent.childCount; j++) 
						{
							if (hit.transform.parent.GetChild (0).tag == "Solid_Mesh") 
							{
								checkRenders = hit.transform.parent.GetChild (0).GetComponent<Renderer> ();
							}
						}
					}
				}
				Debug.Log (checkRenders);


				if (checkRenders != null) 
				{
					rend.Add (checkRenders);
					CameraControl.transparentObjects.Add (checkRenders.gameObject);
					CameraControl.shad.Add (checkRenders.material.shader);
					checkRenders.material.shader = Shader.Find ("Transparent/Diffuse");
					Color tempColor = checkRenders.material.color;
					tempColor.a = 0.3F;
					checkRenders.material.color = tempColor;
				}
			}

			madeTransparent = true;
		}

		CameraControl.cameraIsPanning = false;

		if (finish)
			FinishShiftingOut();
	}

	void FinishShiftIn()
	{
		// After the transition is finished, perform final steps
		transform.position = m_ShadowShiftFollowObject.transform.position + -m_LightSourceAligned.GetComponent<LightSourceControl>().m_LightSourceForward * 10f;
		switch (m_LightSourceAligned.GetComponent<LightSourceControl>().m_CurrentFacingDirection)
		{
		case LightSourceControl.FacingDirection.North:
			PlayerController.m_Instance.m_PlayerCollision.transform.position = new Vector3(m_ShadowShiftFollowObject.transform.position.x, m_ShadowShiftFollowObject.transform.position.y, LightingMasterControl.m_NorthFloorTransform.position.z);
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
			break;
		case LightSourceControl.FacingDirection.East:
			PlayerController.m_Instance.m_PlayerCollision.transform.position = new Vector3(LightingMasterControl.m_EastFloorTransform.position.x, m_ShadowShiftFollowObject.transform.position.y, m_ShadowShiftFollowObject.transform.position.z);
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
			break;
		case LightSourceControl.FacingDirection.South:
			PlayerController.m_Instance.m_PlayerCollision.transform.position = new Vector3(m_ShadowShiftFollowObject.transform.position.x, m_ShadowShiftFollowObject.transform.position.y, LightingMasterControl.m_SouthFloorTransform.position.z);
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
			break;
		case LightSourceControl.FacingDirection.West:
			PlayerController.m_Instance.m_PlayerCollision.transform.position = new Vector3(LightingMasterControl.m_WestFloorTransform.position.x, m_ShadowShiftFollowObject.transform.position.y, m_ShadowShiftFollowObject.transform.position.z);
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
			break;
		}

		PlayerAnimator.m_Instance.SetShifting(false);
		PlayerAnimator.m_Instance.SetPlayerInShadow(true);
		TogglePlayerCollision(false);
		Destroy(m_ShadowShiftFollowObject);
		transform.parent = null;

		if (m_ShadowShiftOutPlatforms.Count > 0)
			DeHighlightPlatforms(m_PlatformMaterials);
		m_CurrentPlayerState = PlayerState.Shadow;
		if (GameObject.Find ("Loading_Camera") != null) 
		{
			shadowStart = false;
			Destroy (GameObject.Find ("Loading_Camera"));
		}
	}

	void FinishShiftingOut()
	{
		if (m_ShadowShiftOutLocations.Count > 0 && m_ShadowShiftFollowObject)
			m_ShadowShiftFollowObject.transform.position = m_ShadowShiftOutLocations [currentPlatformIndex];

		currentPlatformIndex = 0;

		if (m_ShadowShiftFollowObject)
		{
			PlayerController.m_Instance.m_PlayerCollision.transform.position = transform.position;
			transform.position = m_ShadowShiftFollowObject.transform.position;
			transform.Find("Player_Mesh_Master").localEulerAngles = Vector3.zero;
			Destroy(m_ShadowShiftFollowObject);
		}

		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
		TogglePlayerMeshVisibility(false);
		TogglePlayerCollision(false);
		PlayerAnimator.m_Instance.SetShifting(false);
		PlayerAnimator.m_Instance.SetPlayerInShadow(false);

		transform.parent = null;
		DeHighlightPlatforms (m_PlatformMaterials);
		if (CameraControl.shad.Count > 0) 
		{
			for (int i = 0; i < CameraControl.shad.Count; i++) 
			{
				CameraControl.transparentObjects [i].GetComponent<Renderer> ().material.shader = CameraControl.shad [i];
			}
			CameraControl.transparentObjects.Clear ();
			CameraControl.shad.Clear ();
			madeTransparent = false;
		}
		m_CurrentPlayerState = PlayerState.Form;
	}

	public void ShiftOutDeath()
	{
		Debug.Log("shifting out death");
		currentPlatformIndex = 0;

		PlayerController.m_Instance.m_PlayerCollision.transform.position = transform.position;
		transform.Find("Player_Mesh_Master").localEulerAngles = Vector3.zero;

		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

		TogglePlayerMeshVisibility(false);
		TogglePlayerCollision(false);
		//Restart the animation controller

		transform.parent = null;
		m_CurrentPlayerState = PlayerState.Form;
	}


	public GameObject CheckLightSourceAligned()
	{
		GameObject mostAlignedLightSource = null;
		foreach (Transform lightTransform in m_LightingMaster.transform)
		{
			if (lightTransform.GetComponent<Light>().enabled)
			{
				Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
				float tempAngle = Vector3.Angle(lightTransform.forward, cameraForward);

				if (Mathf.Abs(tempAngle) < 35)
				{
					m_LightSourceAligned = lightTransform.gameObject;
					mostAlignedLightSource = lightTransform.gameObject;
				}
			}
			else
				continue;
		}
		return mostAlignedLightSource;
	}

	List<Material> GetMaterials()
	{
		List<Material> materials = new List<Material> ();
		foreach (GameObject o in m_ShadowShiftOutPlatforms) 
		{
			materials.Add (o.GetComponentInChildren<Renderer>().material);
		}
		return materials;
	}

	void HighlightPlatforms (List<Material> materials)
	{
		m_ExitParticles = new List<GameObject> ();
		foreach (Vector3 v in m_ShadowShiftOutLocations)
		{
			m_ExitParticles.Add(Instantiate(m_ExitParticle, v, Quaternion.Euler(-90, 0, 0)));
		}
	}

	void DeHighlightPlatforms (List<Material> materials)
	{
		if (m_ExitParticles != null)
			foreach (GameObject o in m_ExitParticles) 
			{
				Destroy (o);
			}
		highlighted = false;
	}


	#endregion

	#region Utility Methods
	void TogglePlayerMeshVisibility(bool on)
	{
		foreach (SkinnedMeshRenderer meshRend in GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			if (on)
				meshRend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
			else
				meshRend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		}
	}

	void TogglePlayerCollision(bool turnOff)
	{
		PlayerController.m_Instance.m_PlayerCollision.GetComponent<CapsuleCollider>().enabled = !turnOff;
		GetComponent<Rigidbody>().detectCollisions = !turnOff;
		GetComponent<Rigidbody>().useGravity = !turnOff;
	}

	void TogglePlayerShadowmeldAppearance(bool on)
	{
		if (on)
		{
			m_PlayerMesh.GetComponent<SkinnedMeshRenderer>().material = m_ShadowmeldPlayerMaterial;
			m_CloakMesh.GetComponent<SkinnedMeshRenderer>().material = m_ShadowmeldCloakMaterial;
			m_HoodMesh.GetComponent<SkinnedMeshRenderer>().material = m_ShadowmeldCloakMaterial;
		}
		else
		{
			m_PlayerMesh.GetComponent<SkinnedMeshRenderer>().material = m_NormalPlayerMaterial;
			m_CloakMesh.GetComponent<SkinnedMeshRenderer>().material = m_NormalCloakMaterial;
			m_HoodMesh.GetComponent<SkinnedMeshRenderer>().material = m_NormalCloakMaterial;
		}
	}
	#endregion
}