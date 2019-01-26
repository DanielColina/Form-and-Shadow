using UnityEngine;

using DG.Tweening;

public class LightToggleSwitch : ToggleSwitch
{
    [SerializeField] private GameObject targetLightSource;
    [SerializeField] private GameObject lightObject;

    public override void HandleInteract()
    {
        base.HandleInteract();
        lightObject.transform.DORotate(new Vector3(0.0f, -90.0f, 0.0f), 0.5f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutBack);
    }
}
