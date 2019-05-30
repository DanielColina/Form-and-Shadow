using UnityEngine;

using KinematicCharacterController;

public interface IPlayer
{
    ICharacterCamera CharacterCamera { get; set; }

    ICharacterController CharacterController { get; set; }

    void UpdateCharacterCameraInput(ICharacterCamera characterCamera);

    void UpdateCharacterControllerInput(ICharacterController characterController);
}
