using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LockCamera : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public Transform playerTransform;
    public Transform lookAt;
    public Following friend;
    public BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        vCam.Follow = lookAt;
    }

    // Update is called once per frame
    void Update()
    {
        if(friend.hugged == true)
        {
            vCam.Follow = playerTransform;
            Destroy(coll);
        }
    }
}
