using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShadowmeldObjectControl : MonoBehaviour
{
    public enum ShadowMeldObjectType { Level_Geometry, Static, Glass, Water, Flat_Spikes, Spikes, Conveyor_Belt, Conveyor_Cube, Lotus };
    public ShadowMeldObjectType m_ShadowmeldObjectType;

    public struct ShadowmeldObjectChildData
    {
        public bool childIsMeshed;
        public GameObject childObject;
        public LayerMask childStartingLayer;
        public Material childStartingMaterial;
        public Material[] childMaterialReferences;
    }

    List<ShadowmeldObjectChildData> childData;
    Object collideMaterial;
    Object ignoreMaterial;
    Object geometryMaterial;
    Object deathMaterial;
    bool layerCollisionTurnedOn;

    void Awake()
    {
        collideMaterial = Resources.Load("Shadowmeld_Collide_Material");
        geometryMaterial = Resources.Load("Shadowmeld_Geometry_Material");
        ignoreMaterial = Resources.Load("Shadowmeld_Ignore_Material");
        deathMaterial = Resources.Load("Shadowmeld_Death_Material");

        childData = new List<ShadowmeldObjectChildData>();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).GetComponent<ShadowmeldObjectControl>())
            {
                foreach (Transform transformChild in transform.GetChild(i).GetComponentsInChildren<Transform>())
                {
                    if (transformChild.gameObject.GetComponent<MeshRenderer>())
                    {
                        ShadowmeldObjectChildData currentChildData = new ShadowmeldObjectChildData();
                        currentChildData.childIsMeshed = true;
                        currentChildData.childObject = transformChild.gameObject;
                        currentChildData.childStartingLayer = transformChild.gameObject.layer;
                        currentChildData.childStartingMaterial = transformChild.GetComponent<MeshRenderer>().material;
                        currentChildData.childMaterialReferences = transformChild.GetComponent<MeshRenderer>().materials;
                        childData.Add(currentChildData);
                    }
                    else
                    {
                        ShadowmeldObjectChildData currentChildData = new ShadowmeldObjectChildData();
                        currentChildData.childIsMeshed = false;
                        currentChildData.childObject = transformChild.gameObject;
                        currentChildData.childStartingLayer = transformChild.gameObject.layer;
                        childData.Add(currentChildData);
                    }
                }
            }
        }
		if(m_ShadowmeldObjectType == ShadowMeldObjectType.Lotus)
			layerCollisionTurnedOn = true;
    }

    void Update()
    {
        switch (PlayerShadowInteraction.m_CurrentPlayerState)
        {
            case PlayerShadowInteraction.PlayerState.Shadowmelded:
                if (!layerCollisionTurnedOn)
                {
                    TurnOnShadowmeldLayerandCollision();
                    layerCollisionTurnedOn = true;
                }
                break;
            default:
                if (layerCollisionTurnedOn)
                {
                    TurnOffShadowmeldLayerandCollision();
                    layerCollisionTurnedOn = false;
                }
                break;
        }
    }

    void TurnOnShadowmeldLayerandCollision()
    {
        switch (m_ShadowmeldObjectType)
        {
            case ShadowMeldObjectType.Level_Geometry:
                TurnOnShadowmeldGeometry();
                break;
            case ShadowMeldObjectType.Static:
                TurnOnShadowmeldCollide();
                break;
            case ShadowMeldObjectType.Glass:
                TurnOnShadowmeldIgnore();
                break;
            case ShadowMeldObjectType.Water:
                TurnOnShadowmeldIgnore();
                break;
            case ShadowMeldObjectType.Conveyor_Belt:
                TurnOnShadowmeldCollide();
                break;
            case ShadowMeldObjectType.Flat_Spikes:
                TurnOnShadowmeldCollide();
                GetComponentInChildren<Killzone>().GetComponent<BoxCollider>().isTrigger = false; //JSM 11.5.17 - Specified Logic
                break;
            case ShadowMeldObjectType.Spikes:
                TurnOnShadowmeldDeath();
                break;
            case ShadowMeldObjectType.Conveyor_Cube:
                TurnOnShadowmeldCollide();
                GetComponentInChildren<Killzone>().GetComponent<BoxCollider>().enabled = false;
                break;
            case ShadowMeldObjectType.Lotus:
                TurnOnShadowmeldDeath();
                GetComponentInChildren<Killzone>().GetComponent<BoxCollider>().enabled = true;
                break;
        }
    }

    void TurnOffShadowmeldLayerandCollision()
    {
        foreach (ShadowmeldObjectChildData child in childData)
        {
            child.childObject.layer = child.childStartingLayer;
            if (child.childIsMeshed && m_ShadowmeldObjectType != ShadowMeldObjectType.Water)
            {
                int i = 0;
                foreach (Material rendererMaterial in child.childMaterialReferences)
                {
                    child.childMaterialReferences[i] = child.childStartingMaterial as Material;
                    i++;
                }
                child.childObject.GetComponent<MeshRenderer>().materials = child.childMaterialReferences;
            }
        }

        switch (m_ShadowmeldObjectType)
        {
            case ShadowMeldObjectType.Flat_Spikes:
                GetComponentInChildren<Killzone>().GetComponent<BoxCollider>().isTrigger = true;
                break;
            case ShadowMeldObjectType.Conveyor_Cube:
                GetComponentInChildren<Killzone>().GetComponent<BoxCollider>().enabled = true;
                break;
            case ShadowMeldObjectType.Lotus:
                GetComponentInChildren<Killzone>().GetComponent<BoxCollider>().enabled = false;
                break;
            default:
                break;
        }
    }

    void TurnOnShadowmeldCollide()
    {
        foreach (ShadowmeldObjectChildData child in childData)
        {
            child.childObject.layer = LayerMask.NameToLayer("Shadowmeld Collide");
            if (child.childIsMeshed)
            {
                int i = 0;
                foreach (Material mat in child.childMaterialReferences)
                {
                    child.childMaterialReferences[i] = collideMaterial as Material;
                    i++;
                }
                child.childObject.GetComponent<MeshRenderer>().materials = child.childMaterialReferences;
            }
        }
    }

    void TurnOnShadowmeldGeometry()
    {
        foreach (ShadowmeldObjectChildData child in childData)
        {
            child.childObject.layer = LayerMask.NameToLayer("Shadowmeld Collide");
            if (child.childIsMeshed)
            {
                int i = 0;
                foreach (Material mat in child.childMaterialReferences)
                {
                    child.childMaterialReferences[i] = geometryMaterial as Material;
                    i++;
                }
                child.childObject.GetComponent<MeshRenderer>().materials = child.childMaterialReferences;
            }
        }
    }

    void TurnOnShadowmeldIgnore()
    {
        foreach (ShadowmeldObjectChildData child in childData)
        {
            child.childObject.layer = LayerMask.NameToLayer("Shadowmeld Ignore");
            if (m_ShadowmeldObjectType != ShadowMeldObjectType.Water && child.childIsMeshed)
            {
                int i = 0;
                foreach (Material mat in child.childMaterialReferences)
                {
                    child.childMaterialReferences[i] = ignoreMaterial as Material;
                    i++;
                }
                child.childObject.GetComponent<MeshRenderer>().materials = child.childMaterialReferences;
            }
        }
    }

    void TurnOnShadowmeldDeath()
    {
        foreach (ShadowmeldObjectChildData child in childData)
        {
            child.childObject.layer = LayerMask.NameToLayer("Shadowmeld Death");
            if (child.childIsMeshed)
            {
                int i = 0;
                foreach (Material mat in child.childMaterialReferences)
                {
                    child.childMaterialReferences[i] = deathMaterial as Material;
                    i++;
                }
                child.childObject.GetComponent<MeshRenderer>().materials = child.childMaterialReferences;
            }
        }
    }
}