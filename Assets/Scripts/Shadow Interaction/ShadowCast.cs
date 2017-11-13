using System;
using UnityEngine;

public class ShadowCast : MonoBehaviour {
    public enum CastedShadowType { Basic_Shadow, Killzone_Shadow, Move_Platform, Propellor_Platform, Gear_Platform };
    public CastedShadowType m_CastedShadowType;
    private GameObject m_LightingMasterControl;

    [System.Serializable] public struct ShadowColliders
    {
        public GameObject m_NorthShadowCollider;
        public GameObject m_EastShadowCollider;
        public GameObject m_SouthShadowCollider;
        public GameObject m_WestShadowCollider;
    }
    public ShadowColliders m_ShadowColliders;

    void Start()
	{
        m_LightingMasterControl = GameObject.Find("Lighting_Master_Control");
        foreach (Transform lightTransform in m_LightingMasterControl.GetComponentInChildren<Transform>())
        {
            switch (m_CastedShadowType)
            {
                case CastedShadowType.Basic_Shadow:
                    if (lightTransform.GetComponent<Light>().enabled)
                        CastShadowCollider(lightTransform.GetComponent<LightSourceControl>());
                    break;
                case CastedShadowType.Killzone_Shadow:
                    if (lightTransform.GetComponent<Light>().enabled)
                        CastShadowCollider(lightTransform.GetComponent<LightSourceControl>());
                    break;
                case CastedShadowType.Move_Platform:
                    if (lightTransform.GetComponent<Light>().enabled)
                        CastShadowCollider(lightTransform.GetComponent<LightSourceControl>());
                    break;
                case CastedShadowType.Propellor_Platform:
                    CastShadowCollider(lightTransform.GetComponent<LightSourceControl>());
                    break;
                case CastedShadowType.Gear_Platform:
                    if (lightTransform.GetComponent<Light>().enabled)
                        CastShadowCollider(lightTransform.GetComponent<LightSourceControl>());
                    break;
            }
        }
    }

    public void CastShadowCollider(LightSourceControl lightSourceControl)
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, lightSourceControl.m_LightSourceForward, Color.red, 10f);

        if (Physics.Raycast(transform.position, lightSourceControl.m_LightSourceForward, out hit, Mathf.Infinity, 1 << 10))
        {
            switch (lightSourceControl.m_CurrentFacingDirection)
            {
                case LightSourceControl.FacingDirection.North:
                    if(!m_ShadowColliders.m_NorthShadowCollider)
                        CreateShadowCollider(lightSourceControl);
                    break;
                case LightSourceControl.FacingDirection.East:
                    if(!m_ShadowColliders.m_EastShadowCollider)
                        CreateShadowCollider(lightSourceControl);
                    break;
                case LightSourceControl.FacingDirection.South:
                    if (!m_ShadowColliders.m_SouthShadowCollider)
                        CreateShadowCollider(lightSourceControl);
                    break;
                case LightSourceControl.FacingDirection.West:
                    if (!m_ShadowColliders.m_WestShadowCollider)
                        CreateShadowCollider(lightSourceControl);
                    break;
            }
        }
	}

    void CreateShadowCollider(LightSourceControl lightSourceControl)
    {
        GameObject shadowColliderMaster = new GameObject();
        GameObject shadowColliderMesh = Instantiate(transform.GetChild(0).gameObject, shadowColliderMaster.transform);

        Vector3 tempShadowColliderMeshScale = shadowColliderMesh.transform.lossyScale;
        Vector3 tempShadowCollideMasterPosition = transform.position;
        Vector3 tempShadowColliderMasterRotation = Vector3.zero;

        bool zAxisCast = false;
        bool perpendicularCast = (lightSourceControl.m_LightSourceForward == transform.GetChild(0).transform.forward || transform.forward == -transform.GetChild(0).transform.forward);


        switch (lightSourceControl.m_CurrentFacingDirection)
        {
            case LightSourceControl.FacingDirection.North:
                m_ShadowColliders.m_NorthShadowCollider = shadowColliderMaster;

                //Set the scale of the shadow collider. This differs for vertical gear platforms, and such they have a special case
                if (m_CastedShadowType == CastedShadowType.Gear_Platform && GetComponent<GearPlatform>().gearType == GearPlatform.GearType.Vertical)
                {
                    if (perpendicularCast)
                        tempShadowColliderMeshScale.z = 1f;
                    else
                        tempShadowColliderMeshScale.x = 1f;
                }
                else
                    tempShadowColliderMeshScale.z = 1f;

                //Set the position for the shadow collider
                tempShadowCollideMasterPosition.z = LightingMasterControl.m_NorthFloorTransform.position.z;

                //Set the rotation for the shadow collider. This differs for propellor platforms, and such they have a special case
                if (m_CastedShadowType == CastedShadowType.Propellor_Platform)
                    tempShadowColliderMasterRotation.y = 90f;
                else
                    tempShadowColliderMasterRotation.z = transform.eulerAngles.z;
                zAxisCast = true;
                break;
            case LightSourceControl.FacingDirection.East:
                m_ShadowColliders.m_EastShadowCollider = shadowColliderMaster;

                //Set the scale of the shadow collider. This differs for vertical gear platforms, and such they have a special case
                if (m_CastedShadowType == CastedShadowType.Gear_Platform && GetComponent<GearPlatform>().gearType == GearPlatform.GearType.Vertical)
                {
                    if (perpendicularCast)
                        tempShadowColliderMeshScale.z = 1f;
                    else
                        tempShadowColliderMeshScale.x = 1f;
                }
                else
                    tempShadowColliderMeshScale.x = 1f;

                //Set the position for the shadow collider
                tempShadowCollideMasterPosition.x = LightingMasterControl.m_EastFloorTransform.position.x;

                //Set the rotation for the shadow collider. This differs for propellor platforms, and such they have a special case
                if (m_CastedShadowType == CastedShadowType.Propellor_Platform)
                    tempShadowColliderMasterRotation.y = 0f;
                else
                    tempShadowColliderMasterRotation.x = transform.eulerAngles.x;
                zAxisCast = false;
                break;
            case LightSourceControl.FacingDirection.South:
                m_ShadowColliders.m_SouthShadowCollider = shadowColliderMaster;

                //Set the scale of the shadow collider. This differs for vertical gear platforms, and such they have a special case
                if (m_CastedShadowType == CastedShadowType.Gear_Platform && GetComponent<GearPlatform>().gearType == GearPlatform.GearType.Vertical)
                {
                    if (perpendicularCast)
                        tempShadowColliderMeshScale.z = 1f;
                    else
                        tempShadowColliderMeshScale.x = 1f;
                }
                else
                    tempShadowColliderMeshScale.z = 1f;

                //Set the position for the shadow collider
                tempShadowCollideMasterPosition.z = LightingMasterControl.m_SouthFloorTransform.position.z;

                //Set the rotation for the shadow collider. This differs for propellor platforms, and such they have a special case
                if (m_CastedShadowType == CastedShadowType.Propellor_Platform)
                    tempShadowColliderMasterRotation.y = 90f;
                else
                    tempShadowColliderMasterRotation.z = transform.eulerAngles.z;
                zAxisCast = true;
                break;
            case LightSourceControl.FacingDirection.West:
                m_ShadowColliders.m_WestShadowCollider = shadowColliderMaster;

                //Set the scale of the shadow collider. This differs for vertical gear platforms, and such they have a special case
                if (m_CastedShadowType == CastedShadowType.Gear_Platform && GetComponent<GearPlatform>().gearType == GearPlatform.GearType.Vertical)
                {
                    if (perpendicularCast)
                        tempShadowColliderMeshScale.z = 1f;
                    else
                        tempShadowColliderMeshScale.x = 1f;
                }
                else
                    tempShadowColliderMeshScale.x = 1f;

                //Set the position for the shadow collider
                tempShadowCollideMasterPosition.x = LightingMasterControl.m_WestFloorTransform.position.x;

                //Set the rotation for the shadow collider. This differs for propellor platforms, and such they have a special case
                if (m_CastedShadowType == CastedShadowType.Propellor_Platform)
                    tempShadowColliderMasterRotation.y = 0;
                else
                    tempShadowColliderMasterRotation.x = transform.eulerAngles.x;
                zAxisCast = false;
                break;
        }

        switch (m_CastedShadowType)
        {
            case CastedShadowType.Basic_Shadow:
                shadowColliderMesh.transform.localScale = tempShadowColliderMeshScale;
                shadowColliderMaster.transform.position = tempShadowCollideMasterPosition;
                shadowColliderMaster.transform.eulerAngles = tempShadowColliderMasterRotation;
                SetUpBasicShadowCollider(shadowColliderMaster, shadowColliderMesh);
                break;
            case CastedShadowType.Move_Platform:
                shadowColliderMesh.transform.localScale = tempShadowColliderMeshScale;
                shadowColliderMaster.transform.position = tempShadowCollideMasterPosition;
                SetUpMovePlatformShadowCollider(shadowColliderMaster, shadowColliderMesh, zAxisCast);
                break;
            case CastedShadowType.Propellor_Platform:
                shadowColliderMaster.transform.position = tempShadowCollideMasterPosition;
                shadowColliderMaster.transform.eulerAngles = tempShadowColliderMasterRotation;
                SetUpPropellorPlatformShadowCollider(shadowColliderMaster, shadowColliderMesh, zAxisCast);
                break;
            case CastedShadowType.Gear_Platform:
                shadowColliderMaster.transform.position = tempShadowCollideMasterPosition;
                SetUpGearPlatformShadowCollider(shadowColliderMaster, shadowColliderMesh, tempShadowColliderMeshScale, perpendicularCast);
                break;
            case CastedShadowType.Killzone_Shadow:
                shadowColliderMesh.transform.localScale = tempShadowColliderMeshScale;
                shadowColliderMaster.transform.position = tempShadowCollideMasterPosition;
                shadowColliderMaster.transform.eulerAngles = tempShadowColliderMasterRotation;
                SetUpKillZoneShadowCollider(shadowColliderMaster, shadowColliderMesh, zAxisCast);
                break;
        }

        shadowColliderMaster.AddComponent<ShadowCollider>();
        shadowColliderMaster.GetComponent<ShadowCollider>().m_TransformParent = gameObject.transform;
        shadowColliderMaster.GetComponent<ShadowCollider>().m_ZAxisCast = zAxisCast;
    }


    void SetUpBasicShadowCollider(GameObject shadowColliderMaster, GameObject shadowColliderMesh)
    {
        shadowColliderMaster.name = "Basic_Shadow_Collider_Master";
        shadowColliderMesh.name = "Basic_Shadow_Collider_Mesh_Master";
        if (gameObject.GetComponent<Rigidbody>())
        {
            Rigidbody body = shadowColliderMaster.AddComponent<Rigidbody>();
            body.useGravity = false;
            body.isKinematic = true;
            body.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
    }

    void SetUpMovePlatformShadowCollider(GameObject shadowColliderMaster, GameObject shadowColliderMesh, bool zAxisCast)
    {
        shadowColliderMaster.name = "Move_Platform_Shadow_Collider_Master";
        shadowColliderMesh.name = "Platform_Shadow_Collider_Mesh_Master";
        Rigidbody body = shadowColliderMaster.AddComponent<Rigidbody>();
        body.useGravity = false;
        body.isKinematic = true;

        GameObject platformShadowColliderTriggerZone = Instantiate(transform.GetChild(1).gameObject, shadowColliderMaster.transform.position, shadowColliderMaster.transform.rotation, shadowColliderMaster.transform);
        if (zAxisCast)
            platformShadowColliderTriggerZone.GetComponent<BoxCollider>().size = new Vector3(platformShadowColliderTriggerZone.GetComponent<BoxCollider>().size.x, platformShadowColliderTriggerZone.GetComponent<BoxCollider>().size.y, 1);
        else
            platformShadowColliderTriggerZone.GetComponent<BoxCollider>().size = new Vector3(1, platformShadowColliderTriggerZone.GetComponent<BoxCollider>().size.y, platformShadowColliderTriggerZone.GetComponent<BoxCollider>().size.z);

    }

    void SetUpPropellorPlatformShadowCollider(GameObject shadowColliderMaster, GameObject shadowColliderMesh, bool zAxisCast)
    {
        shadowColliderMaster.name = "Propellor_Platform_Shadow_Collider_Master";
        shadowColliderMesh.name = "Propellor_Shadow_Collider_Mesh_Master";
        Rigidbody body = shadowColliderMaster.AddComponent<Rigidbody>();
        body.useGravity = false;
        body.isKinematic = true;

        PropellorPlatformShadowCollider propellorShadowCollider = shadowColliderMesh.transform.GetChild(0).gameObject.AddComponent<PropellorPlatformShadowCollider>();
        propellorShadowCollider.m_ZAxisCast = zAxisCast;
        propellorShadowCollider.m_PropellorRotationSpeed = GetComponentInParent<PropellorPlatform>().m_RotationSpeed;

        GameObject propellorShadowColliderTriggerZone = Instantiate(transform.GetChild(0).gameObject, shadowColliderMaster.transform.position, shadowColliderMaster.transform.rotation, shadowColliderMaster.transform);
        propellorShadowColliderTriggerZone.name = "Propellor_Shadow_Collider_Trigger_Zone";
        foreach (BoxCollider boxCollider in propellorShadowColliderTriggerZone.GetComponentsInChildren<BoxCollider>())
            boxCollider.isTrigger = true;
    }

    void SetUpKillZoneShadowCollider(GameObject shadowColliderMaster, GameObject shadowColliderMesh, bool zAxisCast)
    {
        shadowColliderMaster.name = "Killzone_Shadow_Collider_Master";
        shadowColliderMesh.name = "Killzone_Shadow_Collider_Mesh_Master";
        GameObject spikesShadowColliderKillZone = null;

        if (transform.childCount > 1)
        {
            spikesShadowColliderKillZone = Instantiate(transform.GetChild(1).gameObject, shadowColliderMaster.transform.position, shadowColliderMaster.transform.rotation, shadowColliderMaster.transform);
        }
        else
            return;

        spikesShadowColliderKillZone.name = "Killzone_Shadow_Collider_Killzone";
        if (zAxisCast)
            spikesShadowColliderKillZone.transform.localScale = new Vector3(spikesShadowColliderKillZone.transform.lossyScale.x, spikesShadowColliderKillZone.transform.lossyScale.y, 1);
        else
            spikesShadowColliderKillZone.transform.localScale = new Vector3(1, spikesShadowColliderKillZone.transform.lossyScale.y, spikesShadowColliderKillZone.transform.lossyScale.z);
    }

    void SetUpGearPlatformShadowCollider(GameObject shadowColliderMaster, GameObject shadowColliderMesh, Vector3 meshScale, bool perpendicularCast)
    {
        shadowColliderMaster.name = "Gear_Platform_Shadow_Collider_Master";
        shadowColliderMesh.name = "Gear_Platform_Shadow_Collider_Mesh_Master";


        // Is the gear vertical?
        if (GetComponent<GearPlatform>().gearType == GearPlatform.GearType.Vertical)
        {
            // Is the gear casting a shadow perpendicular to its current facing?
            if (perpendicularCast)
            {
                Rigidbody body = shadowColliderMaster.AddComponent<Rigidbody>();
                body.useGravity = false;
                body.isKinematic = true;
                shadowColliderMesh.transform.localScale = meshScale;
                GearPlatform shadowColliderGearPlatform = shadowColliderMaster.AddComponent<GearPlatform>();
                shadowColliderGearPlatform.gearType = GearPlatform.GearType.Vertical;
                shadowColliderGearPlatform.rotateClockwise = GetComponent<GearPlatform>().rotateClockwise;
            }
            // Or is it casting parallel to its facing?
            else
            {
                shadowColliderMesh.transform.localScale = meshScale;
                foreach (MeshCollider meshCollider in shadowColliderMesh.GetComponentsInChildren<MeshCollider>())
                    meshCollider.convex = true;
            }
        }
        else
        {
            shadowColliderMesh.transform.localScale = meshScale;
            foreach (MeshCollider meshCollider in shadowColliderMesh.GetComponentsInChildren<MeshCollider>())
                meshCollider.convex = true;
        }      
    }

}
