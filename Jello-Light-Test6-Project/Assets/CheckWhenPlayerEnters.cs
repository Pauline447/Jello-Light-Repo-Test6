using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWhenPlayerEnters : MonoBehaviour
{
    public CheckForFriend _checkForFriend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_checkForFriend.friend1there || _checkForFriend.friend2there || _checkForFriend.friend3there||_checkForFriend.playerthere)
        {
            //Wurm kann folgen
        }
        else
        {
            //Wurm geht an Anfang zurück
        }
    }
}
