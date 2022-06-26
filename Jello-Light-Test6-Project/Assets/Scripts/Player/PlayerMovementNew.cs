using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementNew : MonoBehaviour
{
    public bool startDash = false;

    public Animator animator;

    public Rigidbody2D rb;
    private float horizontal;
    private float vertical;

    public float speed; //has to be for PushBack 
    public float defaultSpeed; //kann gesetzt werden

    private bool isFacingRight = true;

    //for dashing
   //public float dashspeed;     //im Speed Manager gebraucht
    public float defaultDashSpeed = 5f;

    //private int counter = 0;
    private bool buttondown = false;

    public float defaultMinSpeed = 0.5f; //einstellbar
    public float minSpeed; //für speedManager 
    public bool doDash = false;

    public bool dashing = false;

    public float slowdownValue = 3f; //einstellbar
    public float slowdownAfterDashValue = 7f; //einstellbar
    public bool slowdownBool = false; //umstellen auf priv
    public int StopValue = 50;

    //private bool speedUpBool = false;
    //public float speedUp = 5f;

    //public ParticleSystem dashParticle;
    public GameObject dashParticleMia;
    public int ParticleEmissionDefault;
    public int ParticleEmissionDash;
    //public AnimationCurve EmissionProgression;

    public Transform dashPosition;

    //hugging
    public bool ableToHug = false; //needed by interactionsUI
    public bool hugs = false; //gebraucht von FriendManager

    //UpMovement
    public bool up = false; //needed by UpMovement
    private float upPower = 15f;

    //StopFriends
    public bool[] friendcalled; //needs to be assigned in Unity


    public float rotationSpeed; //einstellbar

    public FriendManager friendManager;

    //UI
    public bool dashUIDashDone = false; //wird von UI gebraucht

    // Sound Stuff
    public string EventName = "default";
    public string StopEvent = "default";
    private bool IsInColloder = false;
    public bool playDashSound = false; //private setzten

    // Update is called once per frame
    void Start()
    {
       // AkSoundEngine.RegisterGameObj(gameObject);                                        ////////////////////////////////////////////////
    }
    void Update()
    {
        if (playDashSound)
        {
            //AkSoundEngine.PostEvent(EventName, gameObject);                               ////////////////////////////////////////////////
        }
        else
        {
            //AkSoundEngine.PostEvent(StopEvent, gameObject);                               ////////////////////////////////////////////////
        }

    }
    void FixedUpdate()
    {
        Vector2 dir = new Vector2(horizontal, vertical);
        
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);


        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        //if the player is not dashing he is moving with the normal speed

        if (!buttondown && slowdownBool == false)
        {
            speed = defaultSpeed;
        }

        if (!buttondown && slowdownBool)
        {
            if (speed > 0)
            {
                speed = speed - slowdownAfterDashValue * Time.deltaTime;
            }
            else if (speed < 0)
            {
                slowdownBool = false;
            }
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
            StartCoroutine("MyCoroutine");
        }

        if (doDash)
        {
           // animator.SetBool("animateDashing", true);
            /*StartCoroutine(ParticleTrail());*/  //eigene variable um das nur  mal zu triggern???
            //dashing = true;
            
            if (speed > minSpeed)
            {
                speed = speed - slowdownValue * Time.deltaTime;
            }
            else
            {
                //animator.SetBool("animateDashing", false);
                speed = defaultDashSpeed;
            }
        }

        if (up)
        {
            UpMovement();
        }

        if(speed < defaultDashSpeed && speed > minSpeed + 1)
        {
            animator.SetBool("animateDashing", true);
            // dashing = true;
            playDashSound = true;
        }
        else
        {
            playDashSound = false;
        }

        if (speed < defaultDashSpeed && speed > defaultDashSpeed - 0.5f)
        {
            startDash = true;
        }
        else
        {
            startDash = false;
        }

        if (startDash == true){
            StartCoroutine(ParticleTrail());
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
            dashUIDashDone = true;
            speed = defaultDashSpeed;
            rb.gravityScale = 0;
            //bool variable for the update function -> direction and speed can be adjusted every frame
            buttondown = true;
            GameObject currentParticles = Instantiate(dashParticleMia);
            currentParticles.transform.position = dashPosition.position;

        }
        if (ctx.canceled)
        {
            doDash = false;
            slowdownBool = true;

            StopCoroutine("MyCoroutine");
           // counter = 0;
            buttondown = false;
            //speed = defaultSpeed;
           
            rb.gravityScale = 1f;
            //dashParticle.Stop();
            animator.SetBool("animateDashing", false);
        }
    }

    private IEnumerator MyCoroutine()
    {
        while (buttondown)
        {
            doDash = true;
            yield return new WaitForSeconds(0f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
        }
    }

    public void Hugging(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
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
    public float GetDefaultMinSpeed()
    {
        return defaultMinSpeed;
    }
    public void SetMinSpeed(float _newMinSpeed)
    {
        minSpeed = _newMinSpeed;
    }
    public void SetParticleEmissionDash(int _ParticleEmissionDash)
    {
        ParticleEmissionDash = _ParticleEmissionDash;
    }
    public int GetDefaultParticleEmissionDash()
    {
        return ParticleEmissionDefault;
    }
    // for stopping friends
    public void Friend1Called(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            StartCoroutine(Button1Clicked());
            //friendcalled[0] = true;
        }
        //if (ctx.canceled)
        //{
        //    friendcalled[0] = false;
        //}
    }
    public void Friend2Called(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //friendcalled[1] = true;
            StartCoroutine(Button2Clicked());
        }
        //if (ctx.canceled)
        //{
        //    friendcalled[1] = false;
        //}
    }
    public void Friend3Called(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            StartCoroutine(Button3Clicked());
            //friendcalled[2] = true;
        }
        //if (ctx.canceled)
        //{
        //    friendcalled[2] = false;
        //}
    }
    private IEnumerator Button1Clicked()
    {
        friendcalled[0] = true;
        yield return new WaitForSeconds(0.2f);
        friendcalled[0] = false;
    }
    private IEnumerator Button2Clicked()
    {
        friendcalled[1] = true;
        yield return new WaitForSeconds(0.2f);
        friendcalled[1] = false;
    }
    private IEnumerator Button3Clicked()
    {
        friendcalled[2] = true;
        yield return new WaitForSeconds(0.2f);
        friendcalled[2] = false;
    }

    private IEnumerator ParticleTrail()
    {
        Debug.Log("hello");

        ParticleSystem ps = dashParticleMia.GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;
        em.rateOverDistance = ParticleEmissionDash;
        for (int i = 0; i <= ParticleEmissionDash - ParticleEmissionDefault; i++)
        {
            em.rateOverDistance = ParticleEmissionDash - 1 * i;
            Debug.Log(em.rateOverDistance);
            yield return new WaitForSeconds(0.00001f);


        }

        //very cool stuff!!! :

        //float counter = 0;

        //while (counter < dashDuration)
        //{
        //    counter += Time.deltaTime;


        //    float counterpercentage = counter / dashDuration;
        //    m_dashDistance = dashDistance * DashProgression.Evaluate(counterpercentage);
        //    yield return new WaitForSeconds(0.001f);
        //}



        //em.rateOverDistance = ParticleEmissionDefault;

    }
}

