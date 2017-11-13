using UnityEngine;

public class ConveyorCubeEater : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Conveyor Cube"))
            other.gameObject.GetComponentInParent<ConveyorCube>().m_AtEndOfRoute = true;
    }
}
