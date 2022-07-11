using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class LightUpWithInteraction : MonoBehaviour
{
    public CheckForFriend checkFriend;
    public CheckForFriend checkFriend2;
    public CheckForFriend checkFriend3;
    public PlayerMovementScript player;
    public GameObject UIElement;
    private GameObject friend1;
    private GameObject friend2;
    private GameObject friend3;
    public LightUpSingleCoral coralLight;
    public bool coral1;
    public bool coral2;
    public LightUpArea _lightUpArea;

    public Animator animParticle;
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;
    public ParticleSystem particle4;

    private bool coral1On = false;
    private bool coral2On = false;



    public PlayerMovementScript playerScript;
    public GameObject playerObject;

    public float rotationSpeed = 400f;
    public Transform normalRotation;

    public CinemachineVirtualCamera vCam;
    public CameraZoom camZoom;
    public float endValueZoom;

    public Animator playerAnim;
   // private bool canZoom = true;
    private bool doneonce = false;

    public GameObject _particleSystem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (checkFriend.friend1there)
        {
            friend1 = GameObject.Find("Friend1");
            if (friend1.GetComponent<Following>().stopped == true)
                animParticle.SetBool("CompanionWaiting", true);
        }
        if (checkFriend.friend2there)
        {
            friend2 = GameObject.Find("Friend2");
            if (friend2.GetComponent<Following>().stopped == true)
                animParticle.SetBool("CompanionWaiting", true);
        }
        if (checkFriend.friend3there)
        {
            friend3 = GameObject.Find("Friend3");
            if (friend3.GetComponent<Following>().stopped == true)
                animParticle.SetBool("CompanionWaiting", true);
        }
        if (coral1)
        {
            if ((checkFriend.friend1there || checkFriend.playerthere || checkFriend.friend2there) && (checkFriend2.friend1there || checkFriend2.playerthere || checkFriend2.friend2there))
            {
                coral1On = true;
            }
        }
        if (coral2)
        {
            if ((checkFriend.friend1there || checkFriend.playerthere || checkFriend.friend2there) && (checkFriend2.friend1there || checkFriend2.playerthere || checkFriend2.friend2there) && (checkFriend3.friend1there || checkFriend3.playerthere || checkFriend3.friend2there))
            {
                coral2On = true;
            }
        }
        //if ((checkFriend.friend1there||checkFriend.playerthere||checkFriend.friend2there)&&(checkFriend2.friend1there||checkFriend2.playerthere || checkFriend2.friend2there))
        //{
        if (coral1 && coral1On)
        {
            if (UIElement != null)
            {
                UIElement.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (player.hugs)
            {
                //GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                coralLight.startFade = true;
                Destroy(UIElement);
                animParticle.SetBool("CompanionWaiting", false);

                if (particle1 != null)
                {
                    Destroy(particle1);
                }
                if (particle2 != null)
                {
                    Destroy(particle2);
                }
                if (particle3 != null)
                {
                    Destroy(particle3);
                }
                if (particle4 != null)
                {
                    Destroy(particle4);
                }
                //if (friend1 != null)
                //{
                //    friend1.GetComponent<Following>().isFollowing = true;
                //}
                //if (friend2 != null)
                //{
                //    friend2.GetComponent<Following>().isFollowing = true;
                //}
                //if (friend3 != null)
                //{
                //    friend3.GetComponent<Following>().isFollowing = true;
                //}
                StartCoroutine(StartLightUp());
            }
        }
        if (coral2 && coral2On)
        {
            if (UIElement != null)
            {
                UIElement.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (player.hugs)
            {
                //GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                _lightUpArea.startFade = true;

                Destroy(UIElement);
                animParticle.SetBool("CompanionWaiting", false);

                if (particle1 != null)
                {
                    Destroy(particle1);
                }
                if (particle2 != null)
                {
                    Destroy(particle2);
                }
                if (particle3 != null)
                {
                    Destroy(particle3);
                }
                if (particle4 != null)
                {
                    Destroy(particle4);
                }


                //if (friend1 != null)
                //{
                //    friend1.GetComponent<Following>().isFollowing = true;
                //}
                //if (friend2 != null)
                //{
                //    friend2.GetComponent<Following>().isFollowing = true;
                //}
                //if (friend3 != null)
                //{
                //    friend3.GetComponent<Following>().isFollowing = true;
                //}
                StartCoroutine(StartLightUp());
            }
        }
    }

    private IEnumerator StartLightUp()
    {
        if (!doneonce)
        {    
            doneonce = true;

            //player deaktivirern
            //startHugSound = true;
            playerScript.speed = 0f;
            playerScript.dir = new Vector2(0f, 0f);
            playerScript.enabled = true;
            playerObject.GetComponent<PlayerInput>().enabled = false;
            playerObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            playerObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, normalRotation.rotation, rotationSpeed * Time.deltaTime);

            //camZoom
            //canZoom = false;
            camZoom.SetZoomValues(endValueZoom);
            camZoom.hugZoom = true;

            //player animation
            playerAnim.SetBool("smallHug", true);
            yield return new WaitForSeconds(1f);
            playerAnim.SetBool("smallHug", false);

            if (_particleSystem !=null)
            _particleSystem.SetActive(true);

            yield return new WaitForSeconds(1f);
            camZoom.hugZoom = false;
            camZoom.ResetTimer();
            yield return new WaitForSeconds(0.5f);

            //camera zoom back
            camZoom.SetZoomValues(12f);
            camZoom.hugZoom = true;

            yield return new WaitForSeconds(1f);
            camZoom.hugZoom = false;
            camZoom.ResetTimer();
           // canZoom = true;

            //player aktivieren
            playerScript.enabled = true;
            playerObject.GetComponent<PlayerInput>().enabled = true;
            //startHugSound = false;
            if (friend1 != null)
            {
                friend1.GetComponent<Following>().isFollowing = true;
            }
            if (friend2 != null)
            {
                friend2.GetComponent<Following>().isFollowing = true;
            }
            if (friend3 != null)
            {
                friend3.GetComponent<Following>().isFollowing = true;
            }
        }
    }
}
