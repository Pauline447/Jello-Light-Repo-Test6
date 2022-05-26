using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForFriend : MonoBehaviour
{
    public bool friend1there = false;
    public bool friend2there = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Friend1")
        {
            friend1there = true;
        }
        if (other.tag == "Friend2")
        {
            friend2there = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Friend1")
        {
            friend1there = false;
        }
        if (other.tag == "Friend2")
        {
            friend2there = false;
        }
    }
}
