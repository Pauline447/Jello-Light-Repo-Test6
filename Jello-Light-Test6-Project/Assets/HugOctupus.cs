using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HugOctupus : MonoBehaviour
{
    public Following friend1;
    public Following friend2;
    public Following friend3;

    public GameObject lastParticle;

    public CinemachineVirtualCamera vCam;
    public CameraZoom camZoom;
    public float endValueZoom;

    public GameObject _UI;
    public PlayerMovementScript _playerScript;
    public Animator playerAnim;

    public bool playerthere = false;
    public GameObject fadeToWhite;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (friend1.atTentecal && friend2.atTentecal && friend3.atTentecal)
        {
            if(playerthere)
            {
                _UI.SetActive(true);
            }
            lastParticle.SetActive(true);
            if (_playerScript.hugs && playerthere)
            {
                //UI
                StartCoroutine(EndOfGame());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerthere = true;
            //if player hugs, StartCoroutine --> End of Game --> zoom in again, hug animation --> fade to white, load next scene
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //zoom out
            StartCoroutine(ZoomOut());

        }
    }
    private IEnumerator EndOfGame()
    {
        //zoom in, hug animation
        camZoom.SetZoomValues(endValueZoom);
        camZoom.hugZoom = true;

        yield return new WaitForSeconds(1.5f);

        camZoom.hugZoom = false;
        camZoom.ResetTimer();

        playerAnim.SetBool("smallHug", true);
        yield return new WaitForSeconds(1.5f);

        playerAnim.SetBool("smallHug", false);
        yield return new WaitForSeconds(0f);

        //Fade to white
        fadeToWhite.GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(2);

    }
    private IEnumerator ZoomOut()
    {
        //camera zoom back
        camZoom.lerpDuration = 30f;
        camZoom.SetZoomValues(12f);
        camZoom.hugZoom = true;
        yield return new WaitForSeconds(2f);
        camZoom.hugZoom = false;
        camZoom.ResetTimer();
    }
}
