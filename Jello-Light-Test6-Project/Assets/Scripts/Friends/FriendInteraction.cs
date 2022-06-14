using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendInteraction : MonoBehaviour
{
    public bool lightUp = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Friend1")
        {
            lightUp = true;
        }
        //else
        //{
        //    lightUp = false;
        //}
    }
}
