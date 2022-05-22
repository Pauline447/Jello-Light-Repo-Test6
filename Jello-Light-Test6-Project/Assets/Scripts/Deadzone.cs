using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private float timeDuration = 5f;
    private float timer;
    private bool startTimer = false;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();   
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer && timer >0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer < 0)
        {
            Death();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            startTimer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            startTimer = false;
            ResetTimer();
        }
    }
    private void ResetTimer()
    {
        timer = timeDuration;
    }
    private void Death()
    {
        //zoom in
        //Player Animation --> Attack by sea monster
        //Player Movement ausschalten
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<PlayerMovementNew>().defaultDashSpeed = 0f;
        player.GetComponent<PlayerMovementNew>().speed = 0f;
        player.GetComponent<PlayerMovementNew>().enabled = false;
        Debug.Log("U dead");
    }
}
