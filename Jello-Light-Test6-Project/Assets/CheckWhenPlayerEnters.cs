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
    private bool wormBack = false;
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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_checkForFriend.friend1there || _checkForFriend.friend2there || _checkForFriend.friend3there || _checkForFriend.playerthere)
        {
            worm.transform.position = Vector3.Lerp(worm.transform.position, _target2.position, followSpeed * Time.deltaTime);
        }
        else
        {
            wormFollows.chageWormPosition = false;
            wormBack = true;
            //Wurm geht an Anfang zurück
        }
    }
}
