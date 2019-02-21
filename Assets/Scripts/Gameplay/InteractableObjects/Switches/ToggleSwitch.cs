using UnityEngine;
using RootMotion.FinalIK;

[RequireComponent(typeof(InteractionObject))]
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
        anim.SetTrigger("Toggle");
    }
}
