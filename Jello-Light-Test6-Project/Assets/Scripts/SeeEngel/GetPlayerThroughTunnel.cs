using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerThroughTunnel : MonoBehaviour
{
    public PlayerMovementScript player;
    public GameObject playerObject;
    public Transform startPos;
    public Transform endPos;
    public bool move = false;
    // Start is called before the first frame update
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    public int waypointIndex = 0;

    public int numberOfPoints;

    // Use this for initialization
    private void Start()
    {
        // Set position of Enemy as position of the first waypoint
    }

    // Update is called once per frame
    private void Update()
    {
       if(move)
        {
            // Move Enemy
            Move();
        }
    }

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= numberOfPoints)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            playerObject.transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (playerObject.transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
           // move = true;
            player.enabled = false;
            playerObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            player.animator.SetBool("isWalking", true);
            player.animator.SetBool("animateDashing", false);
            move = true;
        }
    }
}
