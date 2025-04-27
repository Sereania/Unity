using UnityEngine;
using UnityEngine.InputSystem;

public class Charactercontrol : MonoBehaviour
{
    // Start Is called once before the first execution of Update after the MonoBehaviour Is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    public float walkSpeed = 3;
    public float splintSpeed = 6;
    Vector3 inputDirection = Vector3.zero;
    public int jumpPower = 10;
    Animator ani;
    Rigidbody2D rb;
    public bool IsGrounded;
    public Transform Grounded;
    public float checkRadius = 0.5f;
    public LayerMask groundLayer;
    public bool IsMoving;
    // Update Is called once per frame
    void Update()
    {
        float currentSpeed = IsSplint ? splintSpeed : walkSpeed;
        rb.linearVelocity = new Vector2(inputDirection.x * currentSpeed, rb.linearVelocity.y);
        IsGrounded = Physics2D.OverlapCircle(Grounded.position, checkRadius, groundLayer);
        // ani.SetBool("IsJump", !IsGrounded);

    }

    
    
    
    
    
    public void OnMoveInput(InputAction.CallbackContext callback)
    {
        inputDirection = callback.ReadValue<Vector2>();
        OnSetDirection();
        if (callback.started)
        {
            IsMoving = true;
            ani.SetBool(AnimationStrings.IsMoving, true);
        }
        else if (callback.canceled)
        {
            IsMoving = false;
            ani.SetBool(AnimationStrings.IsMoving, false);
        }
    }
    public void OnJumpInput(InputAction.CallbackContext callback)
    {
        // if(callback.started && IsGrounded == true)
        if (callback.started)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x , jumpPower);
            
        }
        else if (callback.canceled)
        {

        }

    }
    private bool IsSplint = false;
    public void OnSplintInput(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            IsSplint = true;
            ani.SetBool(AnimationStrings.IsSplint, true);
        }
        else if(callback.canceled)
        {
            IsSplint = false;
            ani.SetBool(AnimationStrings.IsSplint, false);
        }

    }
    private void OnSetDirection()
    {
        if (transform.localScale.x > 0 && inputDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(transform.localScale.x < 0 && inputDirection.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }


    }
}
