
using UnityEngine;

public abstract class Switch : MonoBehaviour
{
    public bool m_PressedByPlayer = false;

    protected Animator switchAnimator;

    protected void Start ()
    {
        switchAnimator = GetComponentInChildren<Animator>();
    }

    protected void Update ()
    {
        UpdateSwitchAnimator();	
	}

    protected void UpdateSwitchAnimator()
    {
        switchAnimator.SetBool("Pressed", m_PressedByPlayer);
    }
}
