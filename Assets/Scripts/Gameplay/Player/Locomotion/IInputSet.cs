using UnityEngine;

public interface IInputSet
{
    float HorizontalAxis { get; set; }

    float VerticalAxis { get; set; }

    Quaternion CameraRotation { get; set; }
}
