using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private Player player;
    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    public int direction { get; private set; }                       

    public bool Attack;
    public bool DownAttack;
    public bool UpAttack;

    public bool Dashing;
    public bool Jumping;
    public bool Blocking;
    //private bool modifierPressed;

    [SerializeField]
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [SerializeField]
    private float jumpBufferTime = 0.2f;
    private float jumpBuferCounter;

    public void Start()
    {
        player = GetComponent<Player>();
        direction = 1;
    }
    public void Update()
    {
        if (player.isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && !(Time.time >= jumpBuferCounter + jumpBufferTime))
        {
            Jumping = true;
            jumpBuferCounter = 0f;
            if (player.isGrounded)
            {
                Invoke("JumpStop", 0.5f);
            }
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);

        if (!PauseMenu.GameIsPaused)
        {
            Flip();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (RawMovementInput.y < -0.7)
            {
                DownAttack = true;
            }
            else if (RawMovementInput.y > 0.7)
            {
                UpAttack = true;
            }
            else
            {
                Attack = true;
            }
        }
        else if (context.canceled)
        {
            Attack = false;
            DownAttack = false;
            UpAttack = false;
        }
    }

    #region Jump/Fall
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpBuferCounter = Time.time;
        }
        else if (context.canceled)
        {
            JumpStop();
        }
    }

    public void JumpStop()
    {
        Jumping = false;
        coyoteTimeCounter = 0f;
        CancelInvoke();
    }
    #endregion

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Dashing = true;
        }
        else if (context.canceled)
        {
            Dashing = false;
        }
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Blocking = true;
        }
        else if (context.canceled)
        {
            Blocking = false;
        }
    }

    //UI Selection

    //public void OnModifyInput(InputAction.CallbackContext context)  //this was for controller on switching weapons with same button in older game
    //{
    //    if (context.started)
    //    {
    //        modifierPressed = true;
    //        Debug.Log("modifying");
    //    }
    //    else if (context.canceled) 
    //    {
    //        modifierPressed = false;
    //    }
    //}

    public void Flip()
    {
        if (NormInputX != 0 && NormInputX != direction)
        {
            //player.AnimCombat.SetLayerWeight(currentLayerNumber, 0);
            //currentLayerNumber += weaponNumberAdd;                        //DO NOT DELETE THIS, only for MC in newer game
            //player.AnimCombat.SetLayerWeight(currentLayerNumber, 1);
            player.Core.Movement.FacingDirection *= -1;
            direction *= -1;
            player.RB2D.transform.Rotate(0.0f, 180.0f, 0.0f);       //Temproary for main chacater not being symmetrical
        }
    }
}