using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormFollowsPlayer : MonoBehaviour
{
    public GameObject worm;
    public Transform target;
    public float positionX;
    public float positionXWorm;
    public bool chageWormPosition; //für Worm Kick
    private Vector3 lastPosition;
    public float lerpSpeed = 5f;
    public Transform wormTarget;
    public bool followingAllowed = false;
    public Vector3 newWormPosition;
    public bool playerInZone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        positionX = target.transform.position.x;
        positionXWorm = worm.transform.position.x;
        newWormPosition = new Vector3(target.transform.position.x - 15f, worm.transform.position.y, worm.transform.position.z);
        if (chageWormPosition && followingAllowed)
        {
            worm.transform.position = newWormPosition;
            //positionXWorm = Mathf.Lerp(worm.transform.position.x, target.transform.position.x, lerpSpeed * Time.deltaTime * 1);
            //worm.transform.position = new Vector3(positionXWorm - 2f, worm.transform.position.y, worm.transform.position.z);
            lastPosition = worm.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
        {
            playerInZone = true;
            chageWormPosition = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInZone = false;
            followingAllowed = false;
            chageWormPosition = false;
        }
    }
}
