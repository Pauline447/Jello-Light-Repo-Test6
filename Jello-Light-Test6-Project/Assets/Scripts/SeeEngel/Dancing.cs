using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using MoreMountains.Feedbacks;

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
    public float endValueZoom1;
    public float endValueZoom2;

    public Light2D caveLight1;
    public Light2D caveLight2;
    //public float maxLuminosity; // max intensity
    public float luminositySteps = 0.001f; // factor when increasing / decreasing
    public float endValueLight1;
    public float endValueLight2;

    public GameObject _UIElement;

    public MMFeedbacks _startSoundFeedback;
    public MMFeedbacks _freeSoundFeedbacks;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startDance && playerScript.hugs)
        {
            _UIElement.SetActive(false);
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

        _startSoundFeedback.PlayFeedbacks();

        //change SeeEngel position to danceTarget
        changeToDanceTarget = true;
        yield return new WaitForSeconds(1f);

        //animation starten
        playerAnim.SetBool("isDancing", true);
        seeEngelAnim.SetBool("isDancing", true);

        //zoom out
        camZoom.lerpDuration = 60f;
        camZoom.SetZoomValues(endValueZoom1);
        camZoom.hugZoom = true;

        //lightUp Cave
        //StartCoroutine(ChangeIntensityDown(caveLight1, endValueLight1));
        //StartCoroutine(ChangeIntensity(caveLight2, endValueLight2));


        yield return new WaitForSeconds(10f);
        //lightUp Cave
        //StartCoroutine(ChangeIntensityDown(caveLight1, endValueLight1));
        //StartCoroutine(ChangeIntensity(caveLight2, endValueLight2));

        yield return new WaitForSeconds(1f);
        camZoom.hugZoom = false;
        camZoom.ResetTimer();

        //yield return new WaitForSeconds(5f); //so lange (-1) dauert die Tanz Animation

        //animation 
        playerAnim.SetBool("isDancing", false);
        seeEngelAnim.SetBool("isDancing", false);
        yield return new WaitForSeconds(3f);

        playerAnim.SetBool("isDoneDancing", true);
        seeEngelAnim.SetBool("isDoneDancing", true);

        //zoom in
        camZoom.SetZoomValues(10f);
        camZoom.hugZoom = true;

        yield return new WaitForSeconds(1f);
        camZoom.hugZoom = false;
        camZoom.ResetTimer();

        //maybe wait for seconds however long the zoom takes?

        //activate UI
        //_UIElement.SetActive(true);

        //player aktivieren
        playerScript.enabled = true;
        playerObject.GetComponent<PlayerInput>().enabled = true;
        seeEngel.GetComponent<Following>().hugged = true;
        Destroy(this);
        //yield return new WaitForSeconds(0f);

        _freeSoundFeedbacks.PlayFeedbacks();
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
