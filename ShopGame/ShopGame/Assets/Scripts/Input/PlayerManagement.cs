using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator animator;
    private Vector2 moveDirection = Vector2.zero;
    
    public bool Move;

    private IInteractable interactable;

    [Header("Movement")]
    [SerializeField] private float walkSpeed = 5; //Walkspeed
    [SerializeField] private float sprintSpeed = 7; //SprintSpeed
    private Vector3 playerVelocity;
    private Vector2 RawMovementInput;
    private bool isSprinting;

    [Header("Footstep Noise Parameters")]
    [SerializeField] private Transform raycastTransform;
    [SerializeField] private float baseStepSpeed = 0.5f;        //This is how often a footstep sound occurs
    [SerializeField] private float crouchStepMultiplier = 1.5f;
    [SerializeField] private float sprintStepMultiplier = 6.0f;
    [SerializeField] private AudioSource footStepAudioSource;
    [SerializeField] private AudioClip[] grassSteps;
    [SerializeField] private AudioClip[] dirtSteps;
    [SerializeField] private AudioClip[] rockSteps;
    private float footStepTimer = 0;
    //private float GetCurrentOffSet => isCrouching ? baseStepSpeed * crouchStepMultiplier :
    //    isSprinting ? baseStepSpeed * sprintStepMultiplier : baseStepSpeed;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Vertical", RawMovementInput.y);
        animator.SetFloat("Horizontal", Mathf.Abs(RawMovementInput.x));
        animator.SetBool("Move", Move);

        Mathf.Abs(RawMovementInput.x);

        ManageFootstepSounds();
    }

    private void FixedUpdate()
    {
        ManageHorizontalMovement();
    }

    private void ManageHorizontalMovement()
    {
        rb2d.MovePosition(rb2d.position + moveDirection * (isSprinting ? sprintSpeed : walkSpeed) * Time.deltaTime);
    }

    private void ManageFootstepSounds()
    {
        if (Mathf.Abs(RawMovementInput.x) < 0.0001 && Mathf.Abs(RawMovementInput.y) < 0.0001) return;  //If not moving then return

        //if (Physics.Raycast(raycastTransform.position, Vector3.down, out RaycastHit hit, 20))
        //{
        //    switch (hit.collider.tag)
        //    {
        //        case "Footsteps/Grass":
        //            Debug.Log("Grassy");
        //            //footStepAudioSource.PlayOneShot(grassSteps[Random.Range(0, grassSteps.Length - 1)]);
        //            break;
        //        case "Footsteps/Dirt":
        //            Debug.Log("Dirty");
        //            //footStepAudioSource.PlayOneShot(dirtSteps[Random.Range(0, dirtSteps.Length - 1)]);
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }   

    #region InputManager 
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Move = true;
        }   
        else if (context.canceled)
        {
            Move = false;
        }

        RawMovementInput = context.ReadValue<Vector2>();

        moveDirection.x = RawMovementInput.x;
        moveDirection.y = RawMovementInput.y;

        //Temporary Flip Manager  https://www.youtube.com/watch?v=Cr-j7EoM8bg go here for better flip 

        if (RawMovementInput.x > 0.6) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (RawMovementInput.x < -0.6) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void OnRunningInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isSprinting = true;
        }
        else if (context.canceled)
        {
            isSprinting = false;
        }
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {

    }
    #endregion
}
