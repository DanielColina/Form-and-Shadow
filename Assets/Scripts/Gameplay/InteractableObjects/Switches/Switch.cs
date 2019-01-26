using UnityEngine;
using UnityEngine.Events;

public abstract class Switch : MonoBehaviour, IInteractableObject
{
    [System.Serializable]
    public class SwitchChangeEvent : UnityEvent<bool> { }

    public SwitchChangeEvent OnSwitchChanged;

    protected bool isSwitched;
    public bool IsSwitched
    {
        get
        {
            return isSwitched;
        }
        set
        {
            if (value != isSwitched)
            {
                OnSwitchChanged.Invoke(value);
            }
            isSwitched = value;
        }
    }

    [EasyButtons.Button("Flip switch")]
    public virtual void HandleInteract()
    {
        IsSwitched = !IsSwitched;
    }
}
