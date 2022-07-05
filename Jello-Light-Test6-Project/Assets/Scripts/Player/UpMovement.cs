using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMovement : MonoBehaviour
{
    public PlayerMovementScript player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Player")
        {
            player.up = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Player")
        {
            player.up = false;
        }
    }
}
