using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class CheckpointControl : MonoBehaviour {

    public GameObject[] checkpoints;

    private PlayerShadowInteraction shadowInteraction;
    private PlayerController controller;

    private bool allowCheckpointTransfer = true;

    void Update() {
        if (CrossPlatformInputManager.GetButton("Checkpoint Control") && allowCheckpointTransfer)
        {
            switch (Input.inputString)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    travelToCheckpoint(int.Parse(Input.inputString) - 1);
                    break;
                case "0":
                    travelToCheckpoint(9);
                    break;
            }
        }
    }

	public void travelToCheckpoint(int index) {
        if(checkpoints.Length > 0 && index < checkpoints.Length) {
            allowCheckpointTransfer = false;
            transform.position = checkpoints[index].transform.position;
            foreach (GameObject check in checkpoints)
                check.GetComponentInChildren<Checkpoint>().resetTrigger();
            StartCoroutine(delayNextInput());
        }
            
    }

    IEnumerator delayNextInput() {
        yield return new WaitForSeconds(0.1f);
        allowCheckpointTransfer = true;
    }
}
