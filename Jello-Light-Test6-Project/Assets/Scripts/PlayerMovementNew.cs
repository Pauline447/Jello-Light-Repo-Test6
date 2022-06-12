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

    public float speed; //has to be for PushBack 
    public float defaultSpeed = 0.5f;

    private bool isFacingRight = true;

    //for dashing
    public float dashspeed;     
    public float defaultDashSpeed = 5f;

    public int counter = 0;
    private bool buttondown = false;
    private bool buttonup = false;

    public float minSpeed = 0.5f;
    public bool doDash = false;

    public float slowdown = 3f;
    public int StopValue = 50;

    //private bool speedUpBool = false;
    //public float speedUp = 5f;

    public ParticleSystem dashParticle;

    //hugging
    public bool ableToHug = false;
    public bool hugs = false;

    //UpMovement
    public bool up = false;
    private float upPower = 15f;

    //StopFriends
    public bool friend1called = false;
    public bool friend2called = false;
    public bool friend3called = false;


    public float rotationSpeed;

    public FriendManager friendManager;

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
        
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        //if the player is not dashing he is moving with the normal speed

        if (!buttondown)
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
        else if (buttonup)
        {
            speed = defaultSpeed;
        }

        //dashing stops after a while
        if (counter > StopValue)
        {
            dashParticle.Stop();
            counter = 0;
            buttondown = false;
        }

        if (doDash)
        {
            animator.SetBool("animateDashing", true);
            if (speed > minSpeed)
            {
                speed = speed - slowdown * Time.deltaTime;
            }
            else
            {
                animator.SetBool("animateDashing", false);
                speed = defaultDashSpeed;
            }
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
        if (ctx.performed)
        {
            speed = defaultDashSpeed;
            rb.gravityScale = 0;
            //bool variable for the update function -> direction and speed can be adjusted every frame
            buttondown = true;

            buttonup = false;
        }
        if (ctx.canceled)
        {
            StopCoroutine("MyCoroutine");
            counter = 0;
            buttondown = false;
            speed = defaultSpeed;
           
            rb.gravityScale = 1f;
            buttonup = true;
            dashParticle.Stop();
            animator.SetBool("animateDashing", false);
        }
    }

    private IEnumerator MyCoroutine()
    {
        while (buttondown)
        {
            doDash = true;
            yield return new WaitForSeconds(0.5f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgef�hrt
        }
    }


    //for hugging
    private void OnTriggerEnter2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Friend1" || other.tag == "Friend2"|| other.tag == "Friend3" )
        {
            //friendManager.SetSpeedofPlayer();
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

    public float GetDefaultDashSpeed()
    {
        return defaultDashSpeed;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public void SetDashSpeed(float _newDashSpeed)
    {
        defaultDashSpeed = _newDashSpeed;
    }

    // for stopping friends
    public void Friend1Called(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            friend1called = true;
        }
        if (ctx.canceled)
        {
            friend1called = false;
        }
    }
    public void Friend2Called(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            friend2called = true;
        }
        if (ctx.canceled)
        {
            friend2called = false;
        }
    }
    public void Friend3Called(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            friend3called = true;
        }
        if (ctx.canceled)
        {
            friend3called = false;
        }
    }
}
