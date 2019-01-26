using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour, IInteractableObject
{
    public UnityEvent<bool> OnSwitchChanged;

    private bool bIsSwitched;

    public void HandlePlayerInteract()
    {
        bIsSwitched = !bIsSwitched;
        OnSwitchChanged.Invoke(bIsSwitched);
    }
}
