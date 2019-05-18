using UnityEngine;

namespace FormandShadow
{
    /// <summary>
    /// Class that handles catching player input from any source (camera, keyboard, mouse)
    /// and passes it through to a CharacterController for motion processing.
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private bool lockAndHideCursor;
        [SerializeField] private PlayerCamera playerCamera;
        [SerializeField] private CharacterController character;
        [SerializeField] private Transform cameraFollowTransform;

        private const string horizontalInput = "Horizontal";
        private const string verticalInput = "Vertical";

        private void Start()
        {
            if (lockAndHideCursor)
            {
                // Lock and hide the cursor
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            // Give our player camera its respective follow transform
            playerCamera.SetFollowTransform(cameraFollowTransform);

            // Add all player collision objects to be ignored by the camera's occlusion behaviour
            playerCamera.AddIgnoredColliders(character.GetComponentsInChildren<Collider>());
        }

        private void Update()
        {
            HandleCharacterInput();
        }

        /// <summary>
        /// Updates the current input structure and sends them off to the
        /// character to be processed.
        /// </summary>
        private void HandleCharacterInput()
        {
            // Create a new input struct value
            PlayerInputSet input = new PlayerInputSet();

            // Update input struct with current values
            input.moveAxisRight = Input.GetAxisRaw(horizontalInput);
            input.moveAxisForward = Input.GetAxisRaw(verticalInput);
            input.cameraRotation = playerCamera.transform.rotation;
            input.jumpDown = Input.GetKeyDown(KeyCode.Space);
            input.crouchDown = Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl);
            input.crouchUp = Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl);

            // Apply input values to target character
            character.SetInput(ref input);
        }
    }
}
