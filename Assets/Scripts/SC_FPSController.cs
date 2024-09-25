using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{

    CharacterController characterController;

    private bool shouldCrouch => Input.GetKeyDown(crouchKey) && !duringCrouchAnimation && characterController.isGrounded;
    private bool shouldRun => Input.GetKey(runKey) && characterController.isGrounded;
    private bool isMoving => Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

    [Header("Functional Options")]
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canCrouch = true;
    [SerializeField] private bool canRun = true;
    [SerializeField] private bool canJump = false;
    [SerializeField] private bool useFootsteps = true;

    [Header("Camera Options")]
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    [Header("Movement Parameters")]
    [SerializeField] private float walkingSpeed = 7.5f;
    [SerializeField] private float runningSpeed = 11.5f;
    [SerializeField] private float crouchSpeed = 3.5f;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    [Header("Controls")]
    [SerializeField] private KeyCode crouchKey = KeyCode.LeftControl;
    [SerializeField] private KeyCode runKey = KeyCode.LeftShift;

    [Header("Run Parameters")]
    private bool isRunning;

    [Header("Crouch Parameters")]
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float timeToCrouch = 0.25f;
    [SerializeField] private Vector3 crouchingCenter = new Vector3(0, 0.5f, 0);
    [SerializeField] private Vector3 standingCenter = new Vector3(0, 0, 0);
    private bool isCrouching;
    private bool duringCrouchAnimation;


    [Header("Footstep Parameters")]
    [SerializeField] private float baseStepSpeed = 0.5f;
    [SerializeField] private float runStepSpeed = 0.6f;
    [SerializeField] private float crouchStepSpeed = 1.5f;
    [SerializeField] private AudioSource footstepAudioSource = default;
    [SerializeField] private AudioClip[] footstepClips = default;
    [SerializeField] private float footstepVolume = 1f;
    private float stepTimer = 0f;
    private float GetStepSpeed => isCrouching ? baseStepSpeed * crouchStepSpeed : isRunning ? baseStepSpeed * runStepSpeed : baseStepSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PauseFreeze();

        if (canMove)
        {
            CharacterMovement();
            CameraMotion();
        
            if (canCrouch)
            {
                HandleCrouch();
            }
            if (canRun)
            {
                HandleRun();
            }
            if (useFootsteps)
            {
                HandleFootsteps();
            }
        }
    }

    private void CameraMotion()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    private void CharacterMovement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? (isCrouching ? crouchSpeed : isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isCrouching ? crouchSpeed : isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded && canJump)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void PauseFreeze()
    {
        if (Time.deltaTime == 0)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }

    private void HandleCrouch()
    {
        if (shouldCrouch)
        {
            StartCoroutine(CrouchStand());
        }
    }

    private void HandleRun()
    {
        if (shouldRun)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    private IEnumerator CrouchStand()
    {
        if (isCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up, 1f))
        {
            yield break;
        }

        duringCrouchAnimation = true;

        float timeElapsed = 0;
        float targetHeight = isCrouching ? standingHeight : crouchHeight;
        float currentHeight = characterController.height;
        Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
        Vector3 currentCenter = characterController.center;

        while (timeElapsed < timeToCrouch)
        {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed / timeToCrouch);
            characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed / timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        characterController.height = targetHeight;
        characterController.center = targetCenter;

        isCrouching = !isCrouching;

        duringCrouchAnimation = false;
    }

    private void HandleFootsteps()
    {
        if (!characterController.isGrounded)
        {
            return;
        }
        if (!isMoving)
        {
            return;
        }

        stepTimer -= Time.deltaTime;

        if (stepTimer <= 0)
        {
            footstepAudioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)], footstepVolume);
            stepTimer = GetStepSpeed;
        }
    }
}
