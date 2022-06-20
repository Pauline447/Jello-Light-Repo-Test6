using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormFollowsPlayer : MonoBehaviour
{
    public GameObject worm;
    public GameObject player;
    public float positionX;
    private bool chageWormPosition;
    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chageWormPosition)
        {
            positionX = player.transform.position.x;
            worm.transform.position = new Vector3(positionX - 15f, worm.transform.position.y, worm.transform.position.z);
            lastPosition = worm.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
        {
            chageWormPosition = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            chageWormPosition = false;
           // worm.transform.position = new Vector3(lastPosition.x, lastPosition.y, lastPosition.z);
        }
    }
}
