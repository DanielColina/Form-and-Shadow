using UnityEngine;

public class ToggleSwitch : Switch
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();    
    }

    public override void HandleInteract()
    {
        base.HandleInteract();
        anim.SetBool("Toggled", isSwitched);
    }
}
