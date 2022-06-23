using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWormPosition : MonoBehaviour
{
    public CheckForFriend _checkForFriend;
    public Transform worm;
    public Transform target;
    public float followSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_checkForFriend.friend1there || _checkForFriend.friend2there || _checkForFriend.friend3there || _checkForFriend.playerthere)
        {
            if(target != null)
            {
                worm.transform.position = Vector3.Lerp(worm.transform.position, target.position, followSpeed * Time.deltaTime);
                worm.transform.rotation = target.rotation;
            }
        }
    }
}
