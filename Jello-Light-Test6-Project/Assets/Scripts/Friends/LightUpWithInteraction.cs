using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpWithInteraction : MonoBehaviour
{
    public CheckForFriend checkFriend;
    public CheckForFriend checkFriend2;
    public PlayerMovementNew player;
    public GameObject UIElement;
    public Following friend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((checkFriend.friend1there||checkFriend.playerthere)&&(checkFriend2.friend1there||checkFriend2.playerthere))
        {
            if (UIElement != null)
            {
                UIElement.GetComponent<SpriteRenderer>().enabled = true;
            }
            if(player.hugs)
            {
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                Destroy(UIElement);
                friend.isFollowing = true;
            }
        }
    }
}
