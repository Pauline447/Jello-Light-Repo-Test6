using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement1 : MonoBehaviour
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

    //dashing
    public float dashSpeed = 5f;
    public bool isDashing = false;
    private bool hasDashed = false;

    private float xRaw;
    private float yRaw;

    // Update is called once per frame
    void Update()
    {
        if (!isDashing)
        {
           rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
 
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
        xRaw = ctx.ReadValue<Vector2>().x;
        yRaw = ctx.ReadValue<Vector2>().y;

    }

    public void Dash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Dashing(xRaw, yRaw);
            isDashing = true;
        }
    }

    private void Dashing(float x, float y)
    {
        hasDashed = true;
        Vector2 dir = new Vector2(x, y);
        rb.velocity += dir.normalized * dashSpeed;
        StartCoroutine(DashWait());
    }
    IEnumerator DashWait()
    {
        rb.gravityScale = 0;
        isDashing = true;

        yield return new WaitForSeconds(.3f);

        rb.gravityScale = 3;

        isDashing = false;
    }
}
