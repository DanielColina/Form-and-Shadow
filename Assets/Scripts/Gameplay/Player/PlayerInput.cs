using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMotor motor;
    private Vector3 inputVector;

    private void Awake()
    {
        motor = GetComponent<PlayerMotor>();    
    }

    private void Update()
    {
        inputVector = Vector3.zero;
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = Input.GetAxis("Vertical");
    }
}
