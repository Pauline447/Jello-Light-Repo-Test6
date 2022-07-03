using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GetPlayerThroughTunnel : MonoBehaviour
{
    public PlayerMovementScript player;
    public GameObject playerObject;
    public Transform endPos;
    public bool move = false;
    public Vector3 dir;
    // Start is called before the first frame update
    // Array of waypoints to walk from one to the next one

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one

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
        dir = (endPos.position - playerObject.transform.position).normalized * moveSpeed;
        playerObject.GetComponent<Rigidbody2D>().velocity = dir;
        //playerObject.GetComponent<Rigidbody2D>().velocity = new Vector2(endPos.position.x* moveSpeed * Time.deltaTime, endPos.position.y * moveSpeed * Time.deltaTime);
        //playerObject.transform.position = Vector2.MoveTowards(transform.position, endPos.position, moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
           // move = true;
            player.enabled = false;
            playerObject.GetComponent<PlayerInput>().enabled = false;
            playerObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
           // playerObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
            player.animator.SetBool("isWalking", true);
            player.animator.SetBool("animateDashing", false);
            move = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // move = true;
            player.enabled = true;
            playerObject.GetComponent<PlayerInput>().enabled = true;
            //playerObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            // playerObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
            //player.animator.SetBool("isWalking", true);
            //player.animator.SetBool("animateDashing", false);
            move = false;
            Destroy(this);
        }
    }
}
