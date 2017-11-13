using UnityEngine;

public class GearPlatform : MonoBehaviour
{
    public enum GearType { Horizontal, Vertical };
    public GearType gearType;
	[Range(30, 60)] public float rotationSpeed = 30;
    public bool rotateClockwise = true;

    Vector3 rotationAxisVector;

    void Start()
    {
        if (gearType == GearType.Horizontal)
            rotationAxisVector = transform.GetChild(0).transform.up;
        else
            rotationAxisVector = -transform.GetChild(0).transform.forward;
    }

	void FixedUpdate() 
	{
		if(PlayerShadowInteraction.m_CurrentPlayerState != PlayerShadowInteraction.PlayerState.Shifting && !GameController.m_Resetting && !GameController.m_Paused)
        {
            if(rotateClockwise)
            {
                transform.Rotate(rotationAxisVector, Time.deltaTime * rotationSpeed);
            }
            else
            {
                transform.Rotate(rotationAxisVector, Time.deltaTime * -rotationSpeed);
            }
        }
    }
}