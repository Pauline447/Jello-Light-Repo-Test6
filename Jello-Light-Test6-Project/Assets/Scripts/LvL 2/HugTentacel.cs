using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class HugTentacel : MonoBehaviour
{
    public CheckForFriend checkFriend;
 //   public CheckForFriend checkFriend2;
  //  public PlayerMovementScript player;
   // public GameObject UIElement;
    private GameObject friend1;
    private GameObject friend2;
    private GameObject friend3;
    public LightUpTentacel _lightUpTentacel;


    public PlayerMovementScript playerScript;
    public GameObject playerObject;

    public float rotationSpeed = 400f;
    public Transform normalRotation;

    public CinemachineVirtualCamera vCam;
    public CameraZoom camZoom;
    public float endValueZoom;

    public Animator playerAnim;
    private bool canZoom = true;
    private bool doneonce = false;

    public bool friend1down = false;
    public bool friend2down = false;
    public bool friend3down = false;

    // Start is called before the first frame update
    void Start()
    {
        friend1 = GameObject.Find("Friend1");
        friend2 = GameObject.Find("Friend2");
        friend3 = GameObject.Find("Friend3");
    }

    // Update is called once per frame
    void Update()
    {
        if(!friend1down && !friend2down && !friend3down)
        {
                if (checkFriend.friend1there)
                {
                   // friend1 = GameObject.Find("Friend1");
                    if(friend1.GetComponent<Following>().stopped == true)
                    {
                        friend1.GetComponent<Following>().atTentecal = true;
                        if (canZoom)
                        {
                            friend1down = true;
                            StartCoroutine(FriendDown());
                        }
                       
                    }
                }
                if (checkFriend.friend2there)
                {
                   // friend2 = GameObject.Find("Friend2");
                    if (friend2.GetComponent<Following>().stopped == true)
                    {
                        friend2.GetComponent<Following>().atTentecal = true;
                        if (canZoom)
                        {
                            friend2down = true;
                            StartCoroutine(FriendDown());
                        }
                }
                }
                if (checkFriend.friend3there)
                {
                   // friend3 = GameObject.Find("Friend3");
                    if (friend3.GetComponent<Following>().stopped == true)
                    {
                        friend3.GetComponent<Following>().atTentecal = true;
                        if (canZoom)
                        {
                            friend3down = true;
                            StartCoroutine(FriendDown());
                        }
                }
                }
        }
      
    }
    private IEnumerator FriendDown()
    {
        if(!doneonce)
        {
            doneonce = true;
            canZoom = false;
            camZoom.SetZoomValues(endValueZoom);
            camZoom.hugZoom = true;

            _lightUpTentacel.startFade = true;

            yield return new WaitForSeconds(3f);
            camZoom.hugZoom = false;
            camZoom.ResetTimer();
            yield return new WaitForSeconds(0.5f);

            //camera zoom back
            camZoom.SetZoomValues(12f);
            camZoom.hugZoom = true;

            yield return new WaitForSeconds(4f);
            camZoom.hugZoom = false;
            camZoom.ResetTimer();
            canZoom = true;
        }
    }
}
