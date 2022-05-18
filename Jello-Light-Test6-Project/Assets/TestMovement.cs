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
    public float dashspeed = 5f;
    private bool isDashing = false;
    private bool finishedDashing = true;
    public int counter=0;
    private bool buttondown = false;
    private float acc = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        }
        if (counter > 100)
        {
            while (speed > 0)
            {
                speed = dashspeed - acc;
                acc--;
            }
            isDashing = false;
            //dashParticle.Stop();
            finishedDashing = true;
            counter = 0;
            buttondown = false;
        }
        Debug.Log(counter);
        Debug.Log(isDashing);
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
        // direction for dashing
        //xRaw = ctx.ReadValue<Vector2>().x;
        //yRaw = ctx.ReadValue<Vector2>().y;
    }
    public void Dash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && finishedDashing)
        {
            buttondown = true;
            if ( counter < 2)
            {
                finishedDashing = false;
                isDashing = true;
                Vector2 dir = new Vector2(horizontal, vertical);
                rb.velocity = new Vector2(dir.x * dashspeed, dir.y * dashspeed);
                //StartCoroutine(DashWait());
            }
        }
         if (ctx.canceled)
        {
                isDashing = false;
                //dashParticle.Stop();
                finishedDashing = true;
                counter = 0;
                buttondown = false;
        }
    }

    //IEnumerator DashWait()
    //{
    //    //0.3f --> how long the dash lasts
    //    //dashParticle.Play();
    //    //rb.gravityScale = 0;
    //    yield return new WaitForSeconds(0.2f);
    //    isDashing = false;
    //    //dashParticle.Stop();
    //    finishedDashing = true;
    //    //rb.gravityScale = 1;
    //    //animator.SetBool("isJumping", false);
    //}
}
