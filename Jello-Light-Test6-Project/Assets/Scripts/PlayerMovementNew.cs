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

    public float currDashSpeed;
    public float slowdown = 3f;
    public bool slowDownBool = false;
    public int StopValue = 50;

    public bool speedUpBool = false;
    public float speedUp = 5f;

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
    public bool friend3stopped = false;

    public bool walking = false;

    public float rotationSpeed;

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
        currDashSpeed = dashspeed;
        Vector2 dir = new Vector2(horizontal, vertical);
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        //if the player is not dashing he is moving with the normal speed
        if (!isDashing && !slowDownBool)
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
            speedUpBool = true;
            if (isDashing)
            {
                animator.SetBool("animateDashing", true);
                dashParticle.Play();
            }
            counter++;
            //direction for dashing from the Move() function
            //dashspeed = defaultDashSpeed;
            //rb.velocity = new Vector2(dir.x * dashspeed, dir.y * dashspeed);
            ////movement starts fast and slows down over time
            //dashspeed = dashspeed - slowdown * Time.deltaTime;
        }

        //dashing stops after a while
        if (counter > StopValue)
        {
            slowDownBool = true;
            isDashing = false;
            dashParticle.Stop();
            finishedDashing = true;
           counter = 0;
            //playerStopped = true;
            buttondown = false;
        }

        if (up)
        {
            UpMovement();
        }
        if(slowDownBool)// && currDashSpeed > 0) //&& !playerStopped)
        {
           dashspeed = currDashSpeed - slowdown * Time.deltaTime;
            rb.velocity = new Vector2(horizontal * dashspeed, vertical * dashspeed);
            if(dashspeed<0.5f)
            {
                slowDownBool = false;
                inwhile = false;
                isDashing = false;
            }
        }
        if (speedUpBool)// && currDashSpeed > 0) //&& !playerStopped)
        {
            //dashspeed = currDashSpeed + speedUp * Time.deltaTime;
            rb.velocity = new Vector2(horizontal * dashspeed, vertical * dashspeed);
            if (dashspeed > defaultDashSpeed)
            {
                speedUpBool = false;
                slowDownBool = true;
            }
            else dashspeed = currDashSpeed + speedUp * Time.deltaTime;
        }
        if (!isDashing)
        {
            animator.SetBool("animateDashing", false);
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
            //dashspeed = defaultDashSpeed;
            isDashing = true;
            buttonup = false;
            rb.gravityScale = 0;
            //bool variable for the update function -> direction and speed can be adjusted every frame
            buttondown = true;
        }
        if (ctx.canceled)
        {
            speedUpBool = false;
            slowDownBool = true;
            //if (currDashSpeed > 0)
            //{
            //    slowDownBool = true;
            //}
            rb.gravityScale = 3f;
            finishedDashing = true;
            counter = 0;
            buttondown = false;
            buttonup = true;
            dashParticle.Stop();
            animator.SetBool("animateDashing", false);
                //dashspeed = defaultDashSpeed;
        }
    }
    //for hugging
    private void OnTriggerEnter2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Friend1" || other.tag == "Friend2"|| other.tag == "Friend3" )
        {
            ableToHug = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Friend1" || other.tag == "Friend2" || other.tag == "Friend3")
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
    public void StopFriend3(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            friend3stopped = true;
        }
    }
}
