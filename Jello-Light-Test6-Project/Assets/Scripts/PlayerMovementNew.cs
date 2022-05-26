using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementNew : MonoBehaviour
{
    public Animator animator;

    public Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    public float speed = 0.5f;

    private bool isFacingRight = true;

    //for dashing
    public float dashspeed;
    public float defaultDashSpeed = 5f;

    public bool isDashing = false;
    private bool finishedDashing = true;
    public int counter = 0;
    private bool buttondown = false;
    public bool buttonup = false;

    public float currSpeed;
    public float slowdown = 3f;
    public bool slowDownBool = false;
    public int StopValue = 50;

    public ParticleSystem dashParticle;

    //hugging
    public bool ableToHug = false;
    public bool hugs = false;

    //UpMovement
    public bool up = false;
    public float upPower = 15f;

    //StopFriends
    public bool friend1stopped = false;
    public bool friend2stopped = false;

    public bool walking = false;


    //delete
    public bool inwhile = false;

    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
    }
    void FixedUpdate()
    {
        Vector2 dir = new Vector2(horizontal, vertical);
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
            dashParticle.Play();
            animator.SetBool("animateDashing", true);
            counter++;
            //direction for dashing from the Move() function
            dashspeed = defaultDashSpeed;
            rb.velocity = new Vector2(dir.x * dashspeed, dir.y * dashspeed);
            //movement starts fast and slows down over time
            dashspeed = dashspeed - slowdown * Time.deltaTime;
        }
        if (buttonup)
        {
            dashParticle.Stop();
            animator.SetBool("animateDashing", false);
            slowDownBool = true;
            //dashspeed = defaultDashSpeed;
        }
        //dashing stops after a while
        //if (counter > StopValue)
        //{
        //    rb.gravityScale = 1f;
        //    isDashing = false;
        //    //dashParticle.Stop();
        //    finishedDashing = true;
        //    counter = 0;
        //    buttondown = false;
        //    //slowDownBool = true;
        //}
        if (up)
        {
            UpMovement();
        }
        while(slowDownBool && dashspeed>0)
        {
            inwhile = true;
            dashspeed = dashspeed - slowdown * Time.deltaTime;
            rb.velocity = new Vector2(dir.x * dashspeed, dir.y * dashspeed);
        }
        isDashing = false;
        dashspeed = defaultDashSpeed;
        slowDownBool = false;
        inwhile = false;
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
        if (ctx.performed || finishedDashing)
        {
            rb.gravityScale = 0;
            //bool variable for the update function -> direction and speed can be adjusted every frame
            buttondown = true;
        }
        if (ctx.canceled)
        {
            //slowDownBool = true;
            rb.gravityScale = 1f;
            isDashing = false;
            finishedDashing = true;
            counter = 0;
            buttondown = false;
            buttonup = true;
        }
    }

    //for hugging
    private void OnTriggerEnter2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Friend")
        {
            ableToHug = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Friend")
        {
            ableToHug = false;
        }
    }
    public void Hugging(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && ableToHug)
        {
            hugs = true;
        }
        if (ctx.canceled)
        {
            hugs = false;
        }
    }
    // for Hot Spring
    public void UpMovement()
    {
           rb.velocity = new Vector2(rb.velocity.x, upPower);
    }

    // for stopping friends
    public void StopFriend1(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            friend1stopped = true;
        }
    }
    public void StopFriend2(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            friend2stopped = true;
        }
    }
}
