using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [System.Flags]
    public enum PlayerState
    {
        None = 0,
        Grounded = 1 << 0,
        Airborne = 1 << 1,
        Dead = 1 << 2,
    }
    public PlayerState currentState;

    public void SetState(PlayerState state)
    {
        currentState |= state;
    }

    public void UnsetState(PlayerState state)
    {
        currentState &= state;
    } 

    public bool CheckState(PlayerState state)
    {
        return (currentState & state) == state;
    }

    private void Update()
    {
        
    }
}
