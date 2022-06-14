using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpWithInteraction : MonoBehaviour
{
    public CheckForFriend checkFriend;
    public CheckForFriend checkFriend2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((checkFriend.friend1there||checkFriend.playerthere)&&(checkFriend2.friend1there||checkFriend2.playerthere))
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }

    }
}
