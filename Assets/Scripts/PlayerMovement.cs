using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float inputx;
    private float inputy;

    bool isGrounded;

    //Movement
    public float speed = 5f;
    public float jumpForce = 6f;

    public Rigidbody2D _rb;
    public Transform _trans;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(inputx * speed, _rb.velocity.y);

        if (inputx > 0)
        {
            _trans.rotation = Quaternion.Euler(_trans.rotation.x, 0, 0);
        }

        if (inputx < 0)
        {
            _trans.rotation = Quaternion.Euler(_trans.rotation.x, 180, 0);
        }
        if (inputx == 0)
        {
            animator.SetBool("IsRunning", false);
        }
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            inputx = context.ReadValue<Vector2>().x;
            animator.SetBool("IsRunning", true);
        }
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            if (Keyboard.current[Key.W].isPressed)
            {
                inputx = 0;
                _rb.gravityScale = -_rb.gravityScale;

                if (_rb.gravityScale == 1)
                {
                    _trans.rotation = Quaternion.Euler(0, _trans.rotation.y, 0);
                }
                else
                {
                    _trans.rotation = Quaternion.Euler(180, _trans.rotation.y, 0);
                }

                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
            inputx = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
