using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementNew : MonoBehaviour
{
    public Animator animator;

    public Rigidbody2D rb;
    private float horizontal;
  
    public float speed = 1.5f;
    private bool isFacingRight = true;

    //dashing
    public float dashSpeed = 1f;
    private bool isDashing = false;
    private bool finishedDashing = true;

    private float xRaw;
    private float yRaw;

    private int dashNumber;
    public int defaultDashNumber = 2;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public ParticleSystem dashParticle;
    public float defaultGravity = 0.03f;

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

    //Jump
    private float jumpTimerCounter;
    private float jumpTime = 5f;
    private bool isJumping;

    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //normal movement with the slower speed when you arent dashing (if you havent pressed the button)
        //if (!isDashing)
        //{
        //    rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        //}

        if (!isFacingRight && horizontal >0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal <0f)
        {
            Flip();
        }
        //if (up)
        //{
        //    UpMovement();
        //}
    }

    //for Movement

    //private bool OnGround()
    //{
    //    return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    //}

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
        //animator.SetBool("isWalking", true);
        walking = true;
        // direction for dashing
        xRaw = ctx.ReadValue<Vector2>().x;
        yRaw = ctx.ReadValue<Vector2>().y;
        //if (horizontal == 0)
        //{
        //    animator.SetBool("isWalking", false);
        //}
    }

    public void Dash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //animator.SetBool("isJumping", true);
            animator.SetBool("animateDashing", true);
            animator.SetBool("isWalking", false);
        }
        //if (ctx.performed && finishedDashing) // && OnGround())
        //{
        //    speed = 1.5f;
        //    dashNumber = defaultDashNumber;
        //    finishedDashing = false;
        //    isDashing = true;
        //    Vector2 dir = new Vector2(xRaw, yRaw);
        //    rb.velocity = new Vector2(dir.x * dashSpeed, dir.y * dashSpeed);
        //    StartCoroutine(DashWait());
        //}
        if (ctx.performed && finishedDashing) // && !OnGround() && dashNumber > 0)
        {
            isJumping = true;
            jumpTimerCounter = jumpTime;
            speed = 0.5f;
            finishedDashing = false;
            isDashing = true;
            Vector2 dir = new Vector2(xRaw, yRaw);
            rb.velocity = new Vector2(dir.x * dashSpeed, dir.y * dashSpeed);
            // dashNumber--;
            //if (jumpTimerCounter < 0)
            //{
            //    rb.velocity = new Vector2(dir.x * dashSpeed, dir.y * dashSpeed);
            //    jumpTimerCounter -= Time.deltaTime;
            //}
            StartCoroutine(DashWait());
        }
    }

    IEnumerator DashWait()
    {
        //0.3f --> how long the dash lasts
        dashParticle.Play();
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
        yield return new WaitForSeconds(0.1f);
        dashParticle.Stop();
        finishedDashing = true;
        rb.gravityScale = 0.2f;
        //animator.SetBool("isJumping", false);
        animator.SetBool("animateDashing", false);
        isJumping = false;
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
