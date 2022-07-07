using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeWormPosition : MonoBehaviour
{
    public CheckForFriend[] _checkForFriend;
    public Transform worm;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;

    public float followSpeed = 3f;
    public int numberOfTargets;

    public WormFollowsPlayer wormFollows;
    public Transform _target1;
    //public Transform _target3;
    public bool wormBack = false;

    public bool friendAtTarget1 = false;
    public bool friendAtTarget2 = false;
    public bool friendAtTarget3 = false;

    public bool changePosToTarget1 = false;
    public bool changePosToTarget2 = false;
    public bool changePosToTarget3 = false;
    public bool changePosToTarget4 = false;
    public bool changePosToTarget5 = false;

    public PlayerMovementScript player;
    public GameObject playerObject;
    private Transform pos;

    public CinemachineVirtualCamera vCam;
    public Transform wormBone;

    public Animator animWorm;
    public Animator animIgel;
    public Animator animHead;

    public bool doneonce = false;

    //delete
    public bool toTarget = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (_checkForFriend[0].friend1there || _checkForFriend[0].friend2there || _checkForFriend[0].playerthere)
        {
            friendAtTarget1 = true;
         }
        else if (!_checkForFriend[0].friend1there && !_checkForFriend[0].friend2there && !_checkForFriend[0].playerthere)
        {
            friendAtTarget1 = false;
        }
        if (_checkForFriend[1].friend1there || _checkForFriend[1].friend2there || _checkForFriend[1].playerthere)
        {
            friendAtTarget2 = true;
        }
        else if (!_checkForFriend[1].friend1there && !_checkForFriend[1].friend2there && !_checkForFriend[1].playerthere)
        {
            friendAtTarget2 = false;
        }
        if ((_checkForFriend[0].friend1there || _checkForFriend[0].friend2there || _checkForFriend[0].playerthere) && (_checkForFriend[1].friend1there || _checkForFriend[1].friend2there || _checkForFriend[1].playerthere) && (_checkForFriend[2].friend1there || _checkForFriend[2].friend2there || _checkForFriend[2].playerthere))
        {
            friendAtTarget3 = true;
            friendAtTarget2 = true;
            friendAtTarget1 = true;
        }

        /////////////////////////////////////////////////////////////////////////////////////

        if(friendAtTarget1&& !friendAtTarget2 && !friendAtTarget3 && !wormFollows.playerInZone)
        {
            changePosToTarget1 = true;
            changePosToTarget2 = false;
        }
        else  if (friendAtTarget1 && friendAtTarget2 && !friendAtTarget3 && !wormFollows.playerInZone)
        {
            changePosToTarget1 = false;
            changePosToTarget2 = true;
          }
        else if (friendAtTarget1 && friendAtTarget2 && friendAtTarget3 && !wormFollows.playerInZone)
        {
            changePosToTarget1 = false;
            changePosToTarget2 = false;
            vCam.Follow = wormBone;
            playerObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            pos = player.transform;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(pos.position.x * 0, pos.position.y * 0);
            player.GetComponent<PlayerMovementScript>().enabled = false;
            StartCoroutine(Eat());
        }
        else if (!wormFollows.playerInZone)
        {
            changePosToTarget1 = false;
            changePosToTarget2 = false;
            worm.transform.position = Vector3.Lerp(worm.transform.position, _target1.position, followSpeed * Time.deltaTime);
            worm.transform.rotation = _target1.rotation;
        }
        else if (wormFollows.playerInZone)
        {
            worm.transform.rotation = _target1.rotation;
            changePosToTarget1 = false;
            changePosToTarget2 = false;
            wormFollows.chageWormPosition = true;
            wormFollows.followingAllowed = true;
        }

        /////////////////////////////////////////////////////////////////////////////

        if (changePosToTarget1)
        {
            worm.transform.position = Vector3.Lerp(worm.transform.position, target1.position, followSpeed * Time.deltaTime);
            worm.transform.rotation = target1.rotation;
        }
        else if (changePosToTarget2)
        {
            worm.transform.position = Vector3.Lerp(worm.transform.position, target2.position, followSpeed * Time.deltaTime);
            worm.transform.rotation = target2.rotation;
        }
        if (changePosToTarget3 && !changePosToTarget4 && !changePosToTarget5)
        {
            worm.transform.position = Vector3.Lerp(worm.transform.position, target3.position, followSpeed * Time.deltaTime);
            worm.transform.rotation = target3.rotation;
        }
       if (changePosToTarget3 && changePosToTarget4 && !changePosToTarget5)
        {
            worm.transform.position = Vector3.Lerp(worm.transform.position, target4.position, followSpeed * Time.deltaTime);
            worm.transform.rotation = target4.rotation;
        }
       else  if (changePosToTarget3 && changePosToTarget4 && changePosToTarget5)
        {
            worm.transform.position = Vector3.Lerp(worm.transform.position, target5.position, followSpeed * Time.deltaTime);
            worm.transform.rotation = target5.rotation;
        }
    }

    private IEnumerator Eat()
    {
        if(!doneonce)
        {
        doneonce = true;
        changePosToTarget1 = false;
        changePosToTarget2 = false;
        changePosToTarget3 = true;
        //worm.transform.position = Vector3.Lerp(worm.transform.position, target3.position, followSpeed * Time.deltaTime);
        //worm.transform.rotation = target3.rotation;
        yield return new WaitForSeconds(1.5f);
        animIgel.SetBool("Snatch", true);
        animWorm.SetBool("lightThere", true);
        animHead.SetBool("Bite", true);
        changePosToTarget4 = true;
        //worm.transform.position = Vector3.Lerp(worm.transform.position, target4.position, followSpeed * Time.deltaTime);
        //worm.transform.rotation = target4.rotation;
        yield return new WaitForSeconds(2f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
        animWorm.SetBool("lightThere", false);
        changePosToTarget5 = true;
        yield return new WaitForSeconds(2f);
        //worm.transform.position = Vector3.Lerp(worm.transform.position, target5.position, followSpeed * Time.deltaTime);
        //worm.transform.rotation = target5.rotation;
        vCam.Follow = playerObject.transform;
        player.GetComponent<PlayerMovementScript>().enabled = true;
        Destroy(this);
        }

    }
}
