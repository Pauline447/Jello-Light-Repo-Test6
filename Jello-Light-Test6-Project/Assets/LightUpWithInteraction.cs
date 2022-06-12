using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpWithInteraction : MonoBehaviour
{
    public FriendInteraction _friendInteraction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_friendInteraction.lightUp)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }

    }
}
