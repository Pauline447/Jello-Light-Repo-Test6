using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWhenPlayerEnters : MonoBehaviour
{
    public CheckForFriend _checkForFriend;
    public GameObject worm;
    public WormFollowsPlayer wormFollows;
    public Transform _target1;
    public Transform _target2;
    //public Transform _target3;
    public float followSpeed = 5f;
    public bool wormBack = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wormBack)
        {
            worm.transform.position = Vector3.Lerp(worm.transform.position, _target1.position, followSpeed * Time.deltaTime);
            worm.transform.rotation = _target1.rotation;
        }

         if (wormFollows.playerInZone)
         {
            wormBack = false;
           // wormFollows.chageWormPosition = false;
         }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_checkForFriend.friend1there || _checkForFriend.friend2there || _checkForFriend.friend3there || _checkForFriend.playerthere)
        {
             wormFollows.chageWormPosition = false;
        }
        else  if (!wormFollows.playerInZone)
        {
            //wormFollows.chageWormPosition = false;
            wormBack = true;
            //Wurm geht an Anfang zurück
        }
        //else if(!wormFollows.playerInZone)
        //{
        //    wormFollows.chageWormPosition = false;
        //    wormBack = true;
        //    //Wurm geht an Anfang zurück
        //}
        //else if (wormFollows.playerInZone)
        //{
        //    wormBack = false;
        //    wormFollows.chageWormPosition = false;
        //}
    }
}
