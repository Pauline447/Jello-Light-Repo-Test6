using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForFriend : MonoBehaviour
{
    public bool friendthere = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Friend")
        {
            friendthere = true;
        }
    }
}
