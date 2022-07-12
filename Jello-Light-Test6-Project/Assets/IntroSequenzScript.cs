using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.Rendering.Universal;

public class IntroSequenzScript : MonoBehaviour
{
    public PlayerMovementScript playerScript;
    public GameObject playerObject;

    public float rotationSpeed = 400f;
    public Transform normalRotation;

    public CinemachineVirtualCamera vCam;
    public CameraZoom camZoom;
    public float endValueZoom;
    public float endValueZoom2;
    public float endValueZoom3;

    public GameObject friend;
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    public int waypointIndex = 0; //private setzen
    private int currWaypointIndex;

    public bool startMove = false; //set private
    public Animator _PlayerLightAnim;

    public Light2D playerLight;

    public GameObject _UI;
    public bool _test;

    //dunkel zu hell - kleine Fisch pfad man kann den einsammeln, player color = 255 und umgebungslichter(Light 2D und Light 2D (1)) aus bis fisch umarmt
    void Start()
    {
        StartCoroutine(StartIntro());
        //transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(startMove)
        {
             Move();
        }

    }
    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            friend.transform.position = Vector2.MoveTowards(friend.transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (friend.transform.position == waypoints[waypointIndex].transform.position)
            {
                currWaypointIndex = waypointIndex;
                waypointIndex += 1;
            }
        }
        if (friend.GetComponent<Following>().hugged)
        {
            StartCoroutine(LightUpPlayer());
        }
    }
        private IEnumerator StartIntro()
    {
        //Player dektiviren, leicht aufschimmern lassen
        playerScript.speed = 0f;
        playerScript.dir = new Vector2(0f, 0f);
        playerScript.enabled = true;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        playerObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, normalRotation.rotation, rotationSpeed * Time.deltaTime);
        //cam zoom out
        camZoom.lerpDuration = 30f;
        camZoom.SetZoomValues(endValueZoom);
        camZoom.hugZoom = true;

        yield return new WaitForSeconds(3f);

        camZoom.hugZoom = false;
        camZoom.ResetTimer();

        //Kleinen Freund auf Pfad schicken
        startMove = true;

        yield return new WaitForSeconds(3f);

        //Kamera zoom in
        camZoom.SetZoomValues(endValueZoom2);
        camZoom.hugZoom = true;

        yield return new WaitForSeconds(1f);

        camZoom.hugZoom = false;
        camZoom.ResetTimer();

        //Player aktivieren
        playerScript.enabled = true;
        playerObject.GetComponent<PlayerInput>().enabled = true;

        // if hug - UI gets activated, light gets turned up to 1
    }
    private IEnumerator LightUpPlayer()
    {
        yield return new WaitForSeconds(2f);
        _PlayerLightAnim.SetBool("stops", true);
        yield return new WaitForSeconds(1f);
        playerLight.enabled = true;
        yield return new WaitForSeconds(2f);
        //cam zoom out

        _UI.SetActive(true);

        camZoom.SetZoomValues(endValueZoom3);
        camZoom.hugZoom = true;

        yield return new WaitForSeconds(1f);

        camZoom.hugZoom = false;
        camZoom.ResetTimer();
        //Script löschen
        Destroy(this);
    }
}
