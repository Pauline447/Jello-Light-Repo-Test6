using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpBackground : MonoBehaviour
{
    private float timeDuration = 0.5f;
    private float timer;
    private bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
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
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            startTimer = false;
            ResetTimer();
            //GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            startTimer = true;
        }
    }
    private void ResetTimer()
    {
        timer = timeDuration;
    }
}
