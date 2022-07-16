using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using MoreMountains.Feedbacks;


public class Following : MonoBehaviour
{
    public
        bool isFollowing = false;
    public
        float followSpeed = 3f;
    public
        Transform followTarget; //Empty

    public GameObject Target; //Player
    private bool facingRight = false;

    public bool doneonce=false;

    public bool hugged = false;
    public bool inRange = false;

    public Animator playerAnim;
    public Transform hugTarget1;
    public Transform hugTarget2;
    public Transform hugTarget3;

    public int whichfriend;

    public bool changeToHugTarget = false;

    public PlayerMovementScript playerScript;
    public GameObject playerObject;

    public float rotationSpeed = 400f;
    public Transform normalRotation;

    public CinemachineVirtualCamera vCam;
    public CameraZoom camZoom;
    public float endValueZoom;

    public bool startHugSound = false;

    //Sound
    public AudioSource audioSource0;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    public bool stopped = false;

    public bool atTentecal = false;

    public MMFeedbacks _loudSound1;
    public MMFeedbacks _silentFeedback1;
    public MMFeedbacks _loudSound2;
    public MMFeedbacks _silentFeedback2;

    // public float defaultValueZoom;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime); //actual following
        }
        if (Target.transform.position.x < gameObject.transform.position.x && facingRight)
        { //gameobject.transform.position = fish
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
            facingRight = false;
        }

        if (Target.transform.position.x > gameObject.transform.position.x && !facingRight)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
            facingRight = true;
        }
        if(changeToHugTarget)
        {
            switch(whichfriend)
            {
                 case 1:
                    transform.position = Vector3.Lerp(transform.position, hugTarget1.position, followSpeed * Time.deltaTime);
                    break;
                case 2:
                    transform.position = Vector3.Lerp(transform.position, hugTarget2.position, followSpeed * Time.deltaTime);
                    break;
                case 3:
                    transform.position = Vector3.Lerp(transform.position, hugTarget3.position, followSpeed * Time.deltaTime);
                    break;
            }
        }
        //Sound
        if(startHugSound)
        {
            if (!audioSource0.isPlaying)
                audioSource0.Play();
            switch (whichfriend)
            {
                case 1:
                    if (!audioSource1.isPlaying)
                        audioSource1.Play();
                    break;
                case 2:
                    if (!audioSource2.isPlaying)
                        audioSource2.Play();
                    break;
                case 3:
                    if (!audioSource3.isPlaying)
                        audioSource3.Play();
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }
    public void SetDoneOnce()
    {
        doneonce = true;
    }

    public void SetHugged()
    {
        hugged = true;
        if(!doneonce)
        {
            isFollowing = true;
            StartCoroutine(HugFriend());
        }
        //playerAnim.SetBool("smallHug", true);
    }

    private IEnumerator HugFriend()
    {
        //player deavtivieren
        startHugSound = true;
        playerScript.speed = 0f;
        playerScript.dir = new Vector2(0f, 0f);
        playerScript.enabled = true;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        playerObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, normalRotation.rotation, rotationSpeed * Time.deltaTime);
        //cameraZoom?
       // vCam.m_Lens.OrthographicSize = defaultValueZoom;
        camZoom.SetZoomValues(endValueZoom);
        camZoom.hugZoom = true;

        yield return new WaitForSeconds(1.5f);

        camZoom.hugZoom = false;
        camZoom.ResetTimer();

        playerAnim.SetBool("smallHug", true);
        changeToHugTarget = true;
        yield return new WaitForSeconds(1.5f);
       
        playerAnim.SetBool("smallHug", false);
        changeToHugTarget = false;
        isFollowing = true;

        //player aktivieren
        playerScript.enabled = true;
        playerObject.GetComponent<PlayerInput>().enabled = true;
        startHugSound = false;

        //camera zoom back
        camZoom.SetZoomValues(12f);
        camZoom.hugZoom = true;
        yield return new WaitForSeconds(2f);
        camZoom.hugZoom = false;
        camZoom.ResetTimer();

        if(whichfriend == 2)
        {
            _silentFeedback1.StopFeedbacks();
            _loudSound1.PlayFeedbacks();
        }
        if (whichfriend == 3)
        {
            _silentFeedback2.StopFeedbacks();
            _loudSound2.PlayFeedbacks();
        }
    }
}
