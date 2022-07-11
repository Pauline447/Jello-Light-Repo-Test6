using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Dancing : MonoBehaviour
{
    private bool startDance = false;
    public PlayerMovementScript playerScript;
    public GameObject playerObject;
    public Animator playerAnim;
    public Animator seeEngelAnim;

    public float rotationSpeed = 400f;
    public Transform normalRotation;

    public GameObject seeEngel;
    public Transform danceTarget;
    private bool changeToDanceTarget = false;
    public float followSpeed = 3f;

    public CinemachineVirtualCamera vCam;
    public CameraZoom camZoom;
    public float endValueZoom;

    public Light2D caveLight1;
    public Light2D caveLight2;
    public float maxLuminosity; // max intensity
    public float luminositySteps = 0.001f; // factor when increasing / decreasing
    public float endValueLight1;
    public float endValueLight2;

    public GameObject _UIElement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startDance)
        {
            StartCoroutine(StartDancing());
        }
        if(changeToDanceTarget)
        {
            seeEngel.transform.position = Vector3.Lerp(transform.position, danceTarget.position, followSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            startDance = true;
        }
    }
    private IEnumerator StartDancing()
    {
        //Player locken, rotation etc., rauszoomen

        //player deaktivirern
        playerScript.speed = 0f;
        playerScript.dir = new Vector2(0f, 0f);
        playerScript.enabled = true;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        playerObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, normalRotation.rotation, rotationSpeed * Time.deltaTime);

        //change SeeEngel position to danceTarget
        changeToDanceTarget = true;
        yield return new WaitForSeconds(1f);

        //animation starten
        //  playerAnim.SetBool("", true);
        //seeEngelAnim.SetBool("", true);

        //zoom out
        camZoom.SetZoomValues(endValueZoom);
        camZoom.hugZoom = true;

        //lightUp Cave
        StartCoroutine(ChangeIntensityDown(caveLight1, endValueLight1));
        StartCoroutine(ChangeIntensity(caveLight2, endValueLight2));

        yield return new WaitForSeconds(1f);
        camZoom.hugZoom = false;
        camZoom.ResetTimer();

        yield return new WaitForSeconds(4f); //so lange (-1) dauert die Tanz Animation

        //animation 
        //playerAnim.SetBool("", false);
        //seeEngelAnim.SetBool("", false);

        //zoom in
        camZoom.SetZoomValues(10f);
        camZoom.hugZoom = true;

        yield return new WaitForSeconds(1f);
        camZoom.hugZoom = false;
        camZoom.ResetTimer();

        //maybe wait for seconds however long the zoom takes?

        //activate UI
        _UIElement.SetActive(true);

        //player aktivieren
        playerScript.enabled = true;
        playerObject.GetComponent<PlayerInput>().enabled = true;

        //yield return new WaitForSeconds(0f);
    }
    private IEnumerator ChangeIntensity(Light2D l, float maxLumi)
    {
        while (l.intensity <= maxLumi)
        {
            l.intensity += luminositySteps; // increase the firefly intensity / fade in
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0f); // wait 3 seconds
    }
    private IEnumerator ChangeIntensityDown(Light2D l, float minLumi)
    {
        while (l.intensity >= minLumi)
        {
            l.intensity += luminositySteps; // increase the firefly intensity / fade in
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0f); // wait 3 seconds
    }
}
