using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Charactercontrol : MonoBehaviour
{
    // property
    [SerializeField]














    // Start Is called once before the first execution of Update after the MonoBehaviour Is created
    public float walkSpeed = 3;
    public float splintSpeed = 6;
    Vector3 _inputDirection = Vector3.zero;
    public int jumpPower = 10;
    Animator _ani;
    Rigidbody2D _rb;
    public bool IsGrounded;
    public Transform Grounded;
    public float checkRadius = 1f;
    public LayerMask ground;
    public bool IsMoving;
    public bool isJump = false;
    [SerializeField] private int jumpCount = 1;
    [SerializeField] private int leftJumpCount = 1;

    
    TouchingDirection _TouchingDirections;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
        _TouchingDirections = GetComponent<TouchingDirection>();
    }

    // Update Is called once per frame
    void Update()
    {
        float currentSpeed = IsSplint ? splintSpeed : walkSpeed;
        currentSpeed = _TouchingDirections._isWalled ? 0 : currentSpeed;
        CheckGround();
        _rb.linearVelocity = new Vector2(_inputDirection.x * currentSpeed, _rb.linearVelocity.y);
    }
    public void CheckGround()
    {
        Debug.Log($"grounding checked");
        if (_TouchingDirections._isGrounded == true && isJump == true)
        {
            leftJumpCount = jumpCount;
            _ani.SetBool(AnimationStrings.IsJump, false);
            isJump = false;            
        }
    }
    
    
    public void OnMoveInput(InputAction.CallbackContext callback)
    {
        _inputDirection = callback.ReadValue<Vector2>();
        OnSetDirection();
        if (callback.started)
        {
            IsMoving = true;
            _ani.SetBool(AnimationStrings.IsMoving, true);
        }
        else if (callback.canceled)
        {
            IsMoving = false;
            _ani.SetBool(AnimationStrings.IsMoving, false);            
        }
    }



    public void OnJumpInput(InputAction.CallbackContext callback)
    {
        // if(callback.started && IsGrounded == true)
        if (callback.started && leftJumpCount > 0)
        {
            _ani.SetBool(AnimationStrings.IsJump, true);
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpPower);
            leftJumpCount = leftJumpCount - 1;
            isJump = true;
            
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
            _ani.SetBool(AnimationStrings.IsSplint, true);
        }
        else if(callback.canceled)
        {
            IsSplint = false;
            _ani.SetBool(AnimationStrings.IsSplint, false);
        }

    }
    private void OnSetDirection()
    {
        if (transform.localScale.x > 0 && _inputDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(transform.localScale.x < 0 && _inputDirection.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }


    }
}
