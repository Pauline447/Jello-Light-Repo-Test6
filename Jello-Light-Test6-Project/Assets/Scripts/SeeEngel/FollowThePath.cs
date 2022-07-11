using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    public int waypointIndex = 0; //private setzen
    private int currWaypointIndex;

    public int stopIndex;
    public int stopIndex1;
    public int stopIndex2;
    public int stopIndex3;
    public int stopIndex4;

    public float numberOfSeconds = 0f;

    private bool doneonce = false;
    private bool doneonce1 = false;
    private bool doneonce2 = false;
    private bool doneonce3 = false;
    private bool doneonce4 = false;

    public ObserveSeaEngels _observeSeaEngels;
    //public CheckForPlayer _checkForPlayer;
    public CheckForPlayer _checkForPlayer1;
    public CheckForPlayer _checkForPlayer2;
    public CheckForPlayer _checkForPlayer3;
    public CheckForPlayer _checkForPlayer4;

    // Use this for initialization
    private void Start()
    {

        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        // Move Enemy
        Move();
    }

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {
            if (waypointIndex == stopIndex )
            {   
               if (_observeSeaEngels.playerthere)
                {
                    this.enabled = true;
                    Debug.Log("starts");
                    if (waypointIndex == stopIndex)
                        doneonce = true;
                }
               else if (!doneonce)
                {
                    Debug.Log("stops");
                    this.enabled = false;
                }
                
            }
            if (waypointIndex == stopIndex1)
            {
                if (_checkForPlayer1.playerthere)
                {
                    this.enabled = true;
                    Debug.Log("starts");
                    if (waypointIndex == stopIndex1)
                        doneonce1 = true;
                }
                else if (!doneonce1)
                {
                    Debug.Log("stops");
                    this.enabled = false;
                }

            }
            if (waypointIndex == stopIndex2)
            {
                if (_checkForPlayer2.playerthere)
                {
                    this.enabled = true;
                    Debug.Log("starts");
                    if (waypointIndex == stopIndex2)
                    doneonce2 = true;
                }
                else if (!doneonce2)
                {
                    Debug.Log("stops");
                    this.enabled = false;
                }
            }
            if (waypointIndex == stopIndex3 )
            {
                if (_checkForPlayer3.playerthere)
                {
                    this.enabled = true;
                    Debug.Log("starts");
                    if (waypointIndex == stopIndex2)
                    doneonce3 = true;
                }
                else if (!doneonce3)
                {
                    Debug.Log("stops");
                    this.enabled = false;
                }
            }
            if (waypointIndex == stopIndex4)
            {
                if (_checkForPlayer4.playerthere)
                {
                    this.enabled = true;
                    Debug.Log("starts");
                    if (waypointIndex == stopIndex2)
                        doneonce4 = true;
                }
                else if (!doneonce4)
                {
                    Debug.Log("stops");
                    this.enabled = false;
                }
            }

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                currWaypointIndex = waypointIndex;
                waypointIndex += 1;
            }
        }
    }

    //private IEnumerator Stop()
    //{
    //    Debug.Log("stops");
    //    this.enabled = false;
    //    if(_checkForPlayer1.playerthere || _checkForPlayer2.playerthere)
    //    {
    //        yield return new WaitForSeconds(numberOfSeconds);
    //        this.enabled = true;
    //        Debug.Log("starts");
    //        if (waypointIndex == stopIndex)
    //            doneonce = true;
    //        if (waypointIndex == stopIndex2)
    //            doneonce2 = true;
    //        // StopCoroutine(Stop());
    //    }
    //}
}
