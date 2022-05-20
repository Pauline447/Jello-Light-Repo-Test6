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


    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
    }
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
            dashParticle.Play();
            animator.SetBool("animateDashing", true);
            counter++;
            //direction for dashing from the Move() function
            Vector2 dir = new Vector2(horizontal, vertical);
            rb.velocity = new Vector2(dir.x * dashspeed, dir.y * dashspeed);
            //movement starts fast and slows down over time
            dashspeed = dashspeed - slowdown * Time.deltaTime;
        }
        else
        {
            dashParticle.Stop();
            animator.SetBool("animateDashing", false);
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
        if (up)
        {
            UpMovement();
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
