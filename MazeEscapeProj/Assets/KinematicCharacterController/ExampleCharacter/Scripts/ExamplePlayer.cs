using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;
using UnityEngine.Rendering.HighDefinition;

namespace KinematicCharacterController.Examples
{
    public class ExamplePlayer : MonoBehaviour
    {
        public ExampleCharacterController Character;
        public ExampleCharacterCamera CharacterCamera;
        public Camera cam;
        // public CameraManager cameraManager;

        private const string MouseXInput = "Mouse X";
        private const string MouseYInput = "Mouse Y";
        private const string MouseScrollInput = "Mouse ScrollWheel";
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        public Interactable focus;
        private void Start()
        {
            // Cursor.lockState = CursorLockMode.Locked;
            if(cam == null)
            {
                cam = Camera.main;
            }
            // Tell camera to follow transform
            CharacterCamera.SetFollowTransform(Character.CameraFollowPoint);

            // Ignore the character's collider(s) for camera obstruction checks
            CharacterCamera.IgnoredColliders.Clear();
            CharacterCamera.IgnoredColliders.AddRange(Character.GetComponentsInChildren<Collider>());
        }

        private void Update()
        {

            MouseBtnInputing();

            
            HandleCharacterInput();
        }



        #region Taking Input for Wepon Fire
        
        void MouseBtnInputing() 
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Cursor.lockState = CursorLockMode.Locked;
                // created a ray
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // if ray hits
                if(Physics.Raycast(ray, out hit, 100))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if(interactable != null)
                    {
                        SetFocus(interactable);
                    }
                    Debug.Log(hit);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                RemoveFocus();
            }
            
        }

        void SetFocus(Interactable newFocus)
        {
            focus = newFocus;
        }

        void RemoveFocus()
        {
            if (focus != null)
                focus = null;
        }
        #endregion


        private void LateUpdate()
        {
            // Handle rotating the camera along with physics movers
            if (CharacterCamera.RotateWithPhysicsMover && Character.Motor.AttachedRigidbody != null)
            {
                CharacterCamera.PlanarDirection = Character.Motor.AttachedRigidbody.GetComponent<PhysicsMover>().RotationDeltaFromInterpolation * CharacterCamera.PlanarDirection;
                CharacterCamera.PlanarDirection = Vector3.ProjectOnPlane(CharacterCamera.PlanarDirection, Character.Motor.CharacterUp).normalized;
            }
            HandleCameraInput();
        }

        private void HandleCameraInput()
        {
            // Create the look input vector for the camera
            float mouseLookAxisUp = Input.GetAxisRaw(MouseYInput);
            float mouseLookAxisRight = Input.GetAxisRaw(MouseXInput);
            Vector3 lookInputVector = new Vector3(mouseLookAxisRight, mouseLookAxisUp, 0f);

            // Input for zooming the camera (disabled in WebGL because it can cause problems)
            //float scrollInput = -Input.GetAxis(MouseScrollInput);
            float scrollInput = 0;
#if UNITY_WEBGL
        scrollInput = 0f;
#endif

            // Apply inputs to the camera
            CharacterCamera.UpdateWithInput(Time.deltaTime, scrollInput, lookInputVector);

            // Handle toggling zoom level
            /*if (Input.GetMouseButtonDown(1))
            {
                CharacterCamera.TargetDistance = (CharacterCamera.TargetDistance == 0f) ? CharacterCamera.DefaultDistance : 0f;
            }*/
        }

        private void HandleCharacterInput()
        {
            PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

            // Build the CharacterInputs struct
            characterInputs.MoveAxisForward = Input.GetAxisRaw(VerticalInput);
            characterInputs.MoveAxisRight = Input.GetAxisRaw(HorizontalInput);
            characterInputs.CameraRotation = CharacterCamera.Transform.rotation;
            characterInputs.JumpDown = Input.GetKeyDown(KeyCode.Space);
            characterInputs.SprintDown = Input.GetKeyDown(KeyCode.LeftShift);
            characterInputs.SprintUp = Input.GetKeyUp(KeyCode.LeftShift);
            characterInputs.MapDown = Input.GetKeyDown(KeyCode.CapsLock);
            characterInputs.MapUp = Input.GetKeyUp(KeyCode.CapsLock);
            characterInputs.CrouchDown = Input.GetKeyDown(KeyCode.LeftControl);
            characterInputs.CrouchUp = Input.GetKeyUp(KeyCode.LeftControl);

            // hudUiManag.openMajorMap(Input.GetKeyDown(KeyCode.M));
            // hudUiManag.closeMajorMap(Input.GetKeyUp(KeyCode.M));

            // Apply inputs to character
            Character.SetInputs(ref characterInputs);
        }

    }
}