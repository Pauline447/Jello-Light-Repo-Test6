using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{
    private float timeDuration = 8f;
    public float timer;
    private bool startTimer = false;

    public float pushBackSpeed = 2f;
    public float pushBackFriendSpeed = 5f;

    public GameObject player;
    private Transform playertrans;
    public float playerSpeed;

    public Transform startOfStreamTrans;

    public GameObject Friend1;
    public GameObject Friend2;

    public bool pushBackBool = false; //needed as public for SpeedManager

    public bool isCave= false;

    public void Awake()
    {
        if(isCave)
        {
            Friend1.GetComponent<Following>().isFollowing = true;
            Friend2.GetComponent<Following>().isFollowing = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       // playerSpeed = player.GetComponent<PlayerMovementNew>().GetDefaultDashSpeed();
        playertrans = player.transform;
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        playerSpeed = player.GetComponent<PlayerMovementNew>().GetDefaultDashSpeed();
        if (startTimer && timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer < 0)
        {
            //Player auf Anfangsposition zurück
            player.GetComponent<PlayerMovementNew>().enabled = false;
            playertrans.position = Vector3.Lerp(playertrans.position, startOfStreamTrans.position, pushBackSpeed * Time.deltaTime);
        }
    }
    private void ResetTimer()
    {
        timer = timeDuration;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            startTimer = true;
            pushBackBool = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pushBackBool = false;
            ResetTimer();
            startTimer = false;
            player.GetComponent<PlayerMovementNew>().enabled = true;
        }
    }
}
