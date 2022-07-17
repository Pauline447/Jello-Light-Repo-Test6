using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using MoreMountains.Feedbacks;

public class ObserveSeaEngels : MonoBehaviour
{
    private bool observe = false;

    public PlayerMovementScript playerScript;
    public GameObject playerObject;
    public Animator playerAnim;
    public Animator twoSeeEngelAnim;

    public CinemachineVirtualCamera vCam;
    public Transform seeEngelTransform;

    public float rotationSpeed = 400f;
    public Transform normalRotation;

    public FollowThePath _followThePath;
    public bool playerthere = false;

    private bool doneonce = false;

    public MMFeedbacks playSoundFeedback;
    public MMFeedbacks freeSoundFeedback;

    public MMFeedbacks _FeedbackmusicLaut1;
    public MMFeedbacks _FeedbackmusicLaut2;
    public MMFeedbacks _FeedbackmusicLaut3;
    //public MMFeedbacks _FeedbackmusicLaut4;

    public MMFeedbacks _FeedbackmusicLeise1;
    public MMFeedbacks _FeedbackmusicLeise2;
    public MMFeedbacks _FeedbackmusicLeise3;
    //public MMFeedbacks _FeedbackmusicLeise4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(observe)
        {
            StartCoroutine(ObserveDancing());
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            observe = true;
        }
    }
    private IEnumerator ObserveDancing()
    {
        if(!doneonce)
        {
            doneonce = true;
  //player deaktivirern
        playerScript.speed = 0f;
        playerScript.dir = new Vector2(0f, 0f);
        playerScript.enabled = true;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        playerObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, normalRotation.rotation, rotationSpeed * Time.deltaTime);
        //Camera auf position SeeEngels
        vCam.Follow = seeEngelTransform;

        playSoundFeedback.PlayFeedbacks();

            _FeedbackmusicLeise1.PlayFeedbacks();
            _FeedbackmusicLeise2.PlayFeedbacks();
            _FeedbackmusicLeise3.PlayFeedbacks();



            yield return new WaitForSeconds(1f);
        //SeeEngel Animation starten
        twoSeeEngelAnim.SetBool("startDancing", true);
        yield return new WaitForSeconds(4f);

        //SeeEngel Anmation beenden
        twoSeeEngelAnim.SetBool("startDancing", false);
        yield return new WaitForSeconds(4f);

        //rausschwimmen lassen
         _followThePath.enabled = true;
        playerthere = true;
        yield return new WaitForSeconds(6f);

        //player aktivieren und camera wieder auf player
        playerScript.enabled = true;
        playerObject.GetComponent<PlayerInput>().enabled = true;
        vCam.Follow = playerObject.transform;
        yield return new WaitForSeconds(0f);

        freeSoundFeedback.PlayFeedbacks();
            _FeedbackmusicLaut1.PlayFeedbacks();
            _FeedbackmusicLaut2.PlayFeedbacks();
            _FeedbackmusicLaut3.PlayFeedbacks();
        }
      
    }
}
