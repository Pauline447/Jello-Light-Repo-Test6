using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    private float vertical;

    public float speed;
    private float defaultSpeed = 0.5f;

    private bool isFacingRight = true;

    //for dashing
    private float defaultDashSpeed = 5f;

    public int counter = 0;
    private bool buttondown = false;
   
    public float slowdown = 3f;
    public int StopValue = 50;

    public float minSpeed = 0.5f;

    public bool doDash = false;
    public bool isDashing = false;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isDashing)
        {
            speed = defaultSpeed;
        }
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

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
            StartCoroutine("MyCoroutine");
        }
        else
        {
            speed = defaultSpeed;
        }

        //dashing stops after a while
        if (counter > StopValue)
        {
            rb.gravityScale = 1f;
            //dashParticle.Stop();
            counter = 0;
            buttondown = false;
        }
        if (doDash)
        { 
            if (speed > minSpeed)
            {

                speed = speed - slowdown * Time.deltaTime;
            }
            else
            {
                speed = defaultDashSpeed;
                //doDash = false;
            }
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
        if (ctx.performed)
        {
            isDashing = true;
            speed = defaultDashSpeed; 
            rb.gravityScale = 0;
            //bool variable for the update function -> direction and speed can be adjusted every frame
            buttondown = true;
        }
         if (ctx.canceled)
        {
            isDashing = false;
            StopCoroutine("MyCoroutine");
            rb.gravityScale = 1f;
                counter = 0;
                buttondown = false;
            speed = defaultSpeed;
        }
    }
    //So startest du eine Coroutine:
    //StartCoroutine(MyCoroutine);


    //Beispiel Coroutine
    private IEnumerator MyCoroutine()
    {
        while (buttondown)
        {
            doDash = true;
            yield return new WaitForSeconds(0.5f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
        }
    }

    //So stoppst du eine Coroutine:
    // StopCoroutine(MyCoroutine);
}
