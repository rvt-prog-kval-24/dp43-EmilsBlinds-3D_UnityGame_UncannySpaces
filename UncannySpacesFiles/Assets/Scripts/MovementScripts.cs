using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScripts : MonoBehaviour
{
    public GameObject PauseMenu;

    public GameObject footstep;
    public GameObject runningFootstep;
    private bool FootstepActive = false;
    private bool RunningFootstepActive = false;

    public Transform cameraTransform;

    private Vector3 initialCameraPosition;

    private StaminaController staminaController;

    public float walkingBobbingSpeed = 10f;
    public float walkingBobbingAmount = 0.05f;
    public float runningBobbingSpeed = 15f;
    public float runningBobbingAmount = 0.1f;

    void Start()
    {

        footstep.SetActive(false);
        runningFootstep.SetActive(false);
        staminaController = GetComponent<StaminaController>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
        initialCameraPosition = cameraTransform.localPosition;
    }

    void Update()
    {
        bool walkingKeyPressed = Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"); //Determines if player is moving or sprinting
        bool shiftKeyPressed = Input.GetKey(KeyCode.LeftShift);

        if (walkingKeyPressed) //If walking, then make footstep sounds and do walking camera bobbing
        {
            footsteps();
            WalkingCameraBobbing();
        }
        else if (FootstepActive)
        {
            StopFootsteps();
            ResetCameraPosition();
        }

        if (staminaController.playerStamina > 0f)
        {
            if (walkingKeyPressed && shiftKeyPressed) //If running, then make running sounds and do running camera bobbing
            {
                StopFootsteps();
                runningFootsteps();
                RunningCameraBobbing();
            }
            else if (RunningFootstepActive)
            {
                StopRunningFootsteps();
                ResetCameraPosition();
            }
        }
        else
        {
            StopRunningFootsteps();
            ResetCameraPosition();
        }

        if (staminaController.playerStamina == 0f)
        {
            StopRunningFootsteps();
            ResetCameraPosition();
        }
    }

    void footsteps()
    {
        footstep.SetActive(true);
        FootstepActive = true;
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
        FootstepActive = false;
    }

    void runningFootsteps()
    {
        runningFootstep.SetActive(true);
        RunningFootstepActive = true;
    }

    void StopRunningFootsteps()
    {
        runningFootstep.SetActive(false);
        RunningFootstepActive = false;
    }

    void WalkingCameraBobbing() //Formula for walking camera movement
    {
        float bobbingOffset = Mathf.Sin(Time.time * walkingBobbingSpeed) * walkingBobbingAmount;
        Vector3 bobbingPosition = initialCameraPosition;
        bobbingPosition.y += bobbingOffset;
        cameraTransform.localPosition = bobbingPosition;
    }

    void RunningCameraBobbing() //Formula for running camera movement
    {
        float bobbingOffset = Mathf.Sin(Time.time * runningBobbingSpeed) * runningBobbingAmount;
        Vector3 bobbingPosition = initialCameraPosition;
        bobbingPosition.y += bobbingOffset;
        cameraTransform.localPosition = bobbingPosition;
    }

    void ResetCameraPosition()
    {
        cameraTransform.localPosition = initialCameraPosition; //Puts camera back in original place
    }
}
