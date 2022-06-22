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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chageWormPosition && followingAllowed)
        {
            positionX = target.transform.position.x;
            positionXWorm = worm.transform.position.x;
            worm.transform.position = new Vector3(positionX - 15f, worm.transform.position.y, worm.transform.position.z);
            //positionXWorm = Mathf.Lerp(worm.transform.position.x, target.transform.position.x, lerpSpeed * Time.deltaTime * 1);
            //worm.transform.position = new Vector3(positionXWorm - 2f, worm.transform.position.y, worm.transform.position.z);
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
            followingAllowed = false;
            chageWormPosition = false;
        }
    }
}
