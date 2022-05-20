using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    private float speed = 0.5f;

    private bool isFacingRight = true;

    //for dashing
    public float dashspeed;
    public float defaultDashSpeed = 5f;

    private bool isDashing = false;
    private bool finishedDashing = true;
    public int counter = 0;
    private bool buttondown = false;
   
    public float slowdown = 3f;
    public int StopValue = 50;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if the player is not dashing he is moving with the normal speed
        if (!isDashing)
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        if (buttondown)
        {
            counter++;
            //direction for dashing from the Move() function
            Vector2 dir = new Vector2(horizontal, vertical);
            rb.velocity = new Vector2(dir.x * dashspeed, dir.y * dashspeed);
            //movement starts fast and slows down over time
            dashspeed = dashspeed - slowdown * Time.deltaTime;
        }
        else
        {
            dashspeed = defaultDashSpeed;
        }
        //dashing stops after a while
        if (counter > StopValue)
        {
            rb.gravityScale = 1f;
            isDashing = false;
            //dashParticle.Stop();
            finishedDashing = true;
            counter = 0;
            buttondown = false;
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        horizontal = ctx.ReadValue<Vector2>().x;
        vertical = ctx.ReadValue<Vector2>().y;
    }
    public void Dash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && finishedDashing)
        {
            rb.gravityScale = 0;
            //bool variable for the update function -> direction and speed can be adjusted every frame
            buttondown = true;
        }
         if (ctx.canceled)
        {
                rb.gravityScale = 1f;
                isDashing = false;
                finishedDashing = true;
                counter = 0;
                buttondown = false;
        }
    }
}
