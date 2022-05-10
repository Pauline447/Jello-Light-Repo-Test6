using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public Rigidbody2D rb;
    private float horizontal;
  
    public float speed = 5f;
    private bool isFacingRight = true;

    //dashing
    public float dashSpeed = 5f;
    private bool isDashing = false;
    private bool finishedDashing = true;

    private float xRaw;
    private float yRaw;

    private int dashNumber;
    public int defaultDashNumber = 2;

    public Transform groundCheck;
    public LayerMask groundLayer;

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
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //normal movement with the slower speed when you arent dashing (if you havent pressed the button)
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
        if (up)
        {
            UpMovement();
        }
    }

    private bool OnGround()
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
        animator.SetBool("isWalking", true);
        walking = true;
        // direction for dashing
        xRaw = ctx.ReadValue<Vector2>().x;
        yRaw = ctx.ReadValue<Vector2>().y;
        if(horizontal == 0)
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void Dash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //animator.SetBool("isJumping", true);
            animator.SetBool("animateDashing", true);
            animator.SetBool("isWalking", false);
        }
        if (ctx.performed && finishedDashing && OnGround())
        {
            speed = 2f;
            dashNumber = defaultDashNumber;
            finishedDashing = false;
            isDashing = true;
            Vector2 dir = new Vector2(xRaw, yRaw);
            rb.velocity = new Vector2(dir.x * dashSpeed, dir.y * dashSpeed);
            StartCoroutine(DashWait());
        }
        if (ctx.performed && finishedDashing && !OnGround() && dashNumber > 0)
        {
            speed = 5f;
            finishedDashing = false;
            isDashing = true;
            Vector2 dir = new Vector2(xRaw, yRaw);
            rb.velocity = new Vector2(dir.x * dashSpeed, dir.y * dashSpeed);
            dashNumber--;
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
        rb.gravityScale = 1;
        //animator.SetBool("isJumping", false);
        animator.SetBool("animateDashing", false);
    }
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
    public void UpMovement()
    {
           rb.velocity = new Vector2(rb.velocity.x, upPower);
    }
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
