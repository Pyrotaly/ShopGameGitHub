using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator animator;
    private bool Move;
    private Vector2 moveDirection = Vector2.zero;

    private Vector2 facingDirection = Vector2.down; //Temporarily, player will be always facing down in terms of code
    private float facingDirectionLength = 0.75f;

    private List<IInteractable> interactable;

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

        Debug.Log(InteractCheck());
        Mathf.Abs(RawMovementInput.x);

        ManageFootstepSounds();

        Debug.DrawRay(this.transform.position, facingDirection, Color.red);
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
    }   

    private bool InteractCheck()
    {
        RaycastHit2D interactHit = Physics2D.Raycast(this.transform.position, facingDirection, facingDirectionLength);

        if (interactHit.collider.GetComponent<IInteractable>() != null)
        {
            interactable = interactHit.collider.GetComponent<IInteractable>();
            Debug.Log("yay");
            return true;
        }
        else
        {
            interactable = null;
            Debug.Log("boo");
            return false;
        }
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