using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{
    private float timeDuration = 8f;
    public float timer;
    private bool startTimer = false;

    public float pushBackSpeed = 2f;

    public GameObject player;
    private Transform playertrans;
    private float playerSpeed;

    public Transform startOfStreamTrans;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = player.GetComponent<PlayerMovementNew>().GetDefaultDashSpeed();
        playertrans = player.transform;
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer && timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer < 0)
        {
            //Player auf Anfangsposition zur�ck
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
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerSpeed / 3);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerSpeed);
            ResetTimer();
            startTimer = false;
            player.GetComponent<PlayerMovementNew>().enabled = true;
        }
    }
}
