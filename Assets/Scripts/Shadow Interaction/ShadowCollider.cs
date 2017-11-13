using UnityEngine;

public class ShadowCollider : MonoBehaviour
{
    public Transform m_TransformParent;
    [HideInInspector] public bool m_ZAxisCast;
	
    void Start()
    {
        // DJC 11/12/2017 Made ShadowCollider objects strip out any non-collider children; this specifically
        // deals with the new SM_ prefabs that have complex meshes due to the dual-mesh rendering system, 
        // so multiple gameobjects as children is just unnecessary
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject currentMasterChild = transform.GetChild(i).gameObject;
            currentMasterChild.layer = LayerMask.NameToLayer("Shadow");
            if (currentMasterChild.GetComponent<MeshRenderer>())
                Destroy(currentMasterChild.GetComponent<MeshRenderer>());
            if (currentMasterChild.GetComponent<Animator>())
                Destroy(currentMasterChild.GetComponent<Animator>());
            for(int j = 0; j < transform.GetChild(i).childCount; j++)
            {
                GameObject currentMeshMasterChild = transform.GetChild(i).transform.GetChild(j).gameObject;
                if(currentMeshMasterChild.GetComponent<Collider>())
                {
                    currentMeshMasterChild.layer = LayerMask.NameToLayer("Shadow");
                    if (currentMeshMasterChild.GetComponent<MeshRenderer>())
                        Destroy(currentMeshMasterChild.GetComponent<MeshRenderer>());
                    if (currentMeshMasterChild.GetComponent<Animator>())
                        Destroy(currentMeshMasterChild.GetComponent<Animator>());
                }
                else
                {
                    Destroy(currentMeshMasterChild);
                }
            }
        }
    }

	void Update () 
	{
        FollowTransformParent();
	}

    public void FollowTransformParent()
    {
		if (m_TransformParent != null)
		{
        	if (m_ZAxisCast)
        	{
            	transform.position = new Vector3(m_TransformParent.position.x, m_TransformParent.position.y, transform.position.z);
        	}
       	 	else
        	{
            	transform.position = new Vector3(transform.position.x, m_TransformParent.position.y, m_TransformParent.position.z);
        	}
		}
		else 
			Destroy(this.gameObject);
    }
}
