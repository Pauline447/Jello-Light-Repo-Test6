using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //delete
    public bool toTarget = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //for(int i = 0; i<numberOfTargets; i++)
        //{
        //    if (_checkForFriend[i].friend1there || _checkForFriend[i].friend2there || _checkForFriend[i].friend3there || _checkForFriend[i].playerthere)
        //    {
        //        if (target != null)
        //        {
        //            worm.transform.position = Vector3.Lerp(worm.transform.position, target.position, followSpeed * Time.deltaTime);
        //            worm.transform.rotation = target.rotation;
        //            toTarget = true;
        //        }
        //        else
        //        {
        //            //do nothing
        //        }
        //    }
        //    else if (!wormFollows.playerInZone)
        //    {
        //        wormBack = true;
        //        toTarget = false;
        //    }
        //    if (wormFollows.playerInZone)
        //    {
        //        wormBack = false;
        //        // wormFollows.chageWormPosition = false;
        //    }
        //}
       
        if (wormFollows.playerInZone)
        {
            wormBack = false;
            // wormFollows.chageWormPosition = false;
        }


        if (_checkForFriend[0].friend1there || _checkForFriend[0].friend2there || _checkForFriend[0].playerthere)
        {
            friendAtTarget1 = true;
            //worm.transform.position = Vector3.Lerp(worm.transform.position, target1.position, followSpeed * Time.deltaTime);
            //worm.transform.rotation = target1.rotation;
        }
        else if (!_checkForFriend[0].friend1there && !_checkForFriend[0].friend2there && !_checkForFriend[0].playerthere)
        {
            friendAtTarget1 = false;
            //if (!wormFollows.playerInZone)
            //{
            //worm.transform.position = Vector3.Lerp(worm.transform.position, _target1.position, followSpeed * Time.deltaTime);
            //worm.transform.rotation = _target1.rotation;
            //}
        }
        if (_checkForFriend[1].friend1there || _checkForFriend[1].friend2there || _checkForFriend[1].playerthere)
        {
            friendAtTarget2 = true;
            //worm.transform.position = Vector3.Lerp(worm.transform.position, target2.position, followSpeed * Time.deltaTime);
            //worm.transform.rotation = target2.rotation;
        }
        else if (!_checkForFriend[1].friend1there && !_checkForFriend[1].friend2there && !_checkForFriend[1].playerthere)
        {
            //animatorWorm.SetBool("FishAtTarget2", false);
            friendAtTarget2 = false;
        }
        if ((_checkForFriend[0].friend1there || _checkForFriend[0].friend2there || _checkForFriend[0].playerthere) && (_checkForFriend[1].friend1there || _checkForFriend[1].friend2there || _checkForFriend[1].playerthere) && (_checkForFriend[2].friend1there || _checkForFriend[2].friend2there || _checkForFriend[2].playerthere))
        {
            friendAtTarget3 = true;
            friendAtTarget2 = true;
            friendAtTarget1 = true;
            //Destroy(gameObject);
            // animatorWorm.SetBool("FishAtTarget3", true);
            //animatorIgel.SetBool("Snatch", true);
            //anim.SetBool("IsLit", true);
            //worm.transform.position = Vector3.Lerp(worm.transform.position, target3.position, followSpeed * Time.deltaTime);
            //worm.transform.rotation = target3.rotation;

        }

        if(friendAtTarget1&& !friendAtTarget2 && !friendAtTarget3)
        {
            changePosToTarget1 = true;
            //worm.transform.position = Vector3.Lerp(worm.transform.position, target1.position, followSpeed * Time.deltaTime);
            //worm.transform.rotation = target1.rotation;
        }
        else  if (friendAtTarget1 && friendAtTarget2 && !friendAtTarget3)
        {
            changePosToTarget1 = false;
            changePosToTarget2 = true;
            //worm.transform.position = Vector3.Lerp(worm.transform.position, target2.position, followSpeed * Time.deltaTime);
            //worm.transform.rotation = target2.rotation;
        }
        else if (friendAtTarget1 && friendAtTarget2 && friendAtTarget3)
        {
            changePosToTarget1 = false;
            changePosToTarget2 = false;
            StartCoroutine(Eat());
        }
        else if (!wormFollows.playerInZone)
        {
            changePosToTarget1 = false;
            changePosToTarget2 = false;
            worm.transform.position = Vector3.Lerp(worm.transform.position, _target1.position, followSpeed * Time.deltaTime);
            worm.transform.rotation = _target1.rotation;
        }

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
        //if (wormBack)
        //{
        //    worm.transform.position = Vector3.Lerp(worm.transform.position, _target1.position, followSpeed * Time.deltaTime);
        //    worm.transform.rotation = _target1.rotation;
        //}

        //if(friendAtTarget1)
        //{
        //    worm.transform.position = Vector3.Lerp(worm.transform.position, target1.position, followSpeed * Time.deltaTime);
        //    worm.transform.rotation = target1.rotation;
        //}
        //if (friendAtTarget2)
        //{
        //    worm.transform.position = Vector3.Lerp(worm.transform.position, target2.position, followSpeed * Time.deltaTime);
        //    worm.transform.rotation = target2.rotation;
        //}
        //if (friendAtTarget3)
        //{
        //    worm.transform.position = Vector3.Lerp(worm.transform.position, target3.position, followSpeed * Time.deltaTime);
        //    worm.transform.rotation = target3.rotation;
        //}
    }
    private IEnumerator Eat()
    {
        changePosToTarget3 = true;
        //worm.transform.position = Vector3.Lerp(worm.transform.position, target3.position, followSpeed * Time.deltaTime);
        //worm.transform.rotation = target3.rotation;
        yield return new WaitForSeconds(1f);
        changePosToTarget4 = true;
        //worm.transform.position = Vector3.Lerp(worm.transform.position, target4.position, followSpeed * Time.deltaTime);
        //worm.transform.rotation = target4.rotation;
        yield return new WaitForSeconds(3f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
        changePosToTarget5 = true;
        yield return new WaitForSeconds(2f);
        //worm.transform.position = Vector3.Lerp(worm.transform.position, target5.position, followSpeed * Time.deltaTime);
        //worm.transform.rotation = target5.rotation;
        Destroy(this);
    }
}
