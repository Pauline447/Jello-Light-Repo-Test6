using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    private float speed = 5f;
    private bool isFacingRight = true;

    //for jump
    public Transform groundCheck;
    public LayerMask groundLayer;
    private float jumpingPower = 12f;
    // double jump
    private int extraJumps;
    public int extraJumpValue;



    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (!isFacingRight && horizontal >0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal <0f)
        { 
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (IsGrounded() && ctx.performed)
        {
            extraJumps = extraJumpValue;
        }
        if (ctx.performed && extraJumps >0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            extraJumps--;
        }

        if (ctx.canceled && extraJumps == 0f && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    public  void Move(InputAction.CallbackContext ctx)
    {
        horizontal = ctx.ReadValue<Vector2>().x;
    }
}
