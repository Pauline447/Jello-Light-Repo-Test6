using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
  
    public float speed = 5f;
    private bool isFacingRight = true;

    //dashing
    public float dashSpeed = 5f;
    public bool isDashing = false;
    private bool finishedDashing = true;

    private float xRaw;
    private float yRaw;

    private int dashNumber;
    public int defaultDashNumber = 2;

    public Transform groundCheck;
    public LayerMask groundLayer;

    //public ParticleSystem dashParticle;

    // Update is called once per frame
    void Start()
    {
 
    }
    void Update()
    {
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
        // direction for dashing
        xRaw = ctx.ReadValue<Vector2>().x;
        yRaw = ctx.ReadValue<Vector2>().y;

    }

    public void Dash(InputAction.CallbackContext ctx)
    {

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
        //dashParticle.Play();
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
        yield return new WaitForSeconds(0.1f);
        //dashParticle.Stop();
        finishedDashing = true;
        rb.gravityScale = 1;
    }
}
