using UnityEngine;

[System.Serializable]
public class AInputSet : IInputSet
{
    private float horizontalAxis;

    private float verticalAxis;

    private Quaternion cameraRotation;

    public float HorizontalAxis { get => horizontalAxis; set => horizontalAxis = value; }
    public float VerticalAxis { get => verticalAxis; set => verticalAxis = value; }
    public Quaternion CameraRotation { get => cameraRotation; set => cameraRotation = value; }
}
