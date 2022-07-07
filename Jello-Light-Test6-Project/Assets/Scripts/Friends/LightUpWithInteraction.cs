using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpWithInteraction : MonoBehaviour
{
    public CheckForFriend checkFriend;
    public CheckForFriend checkFriend2;
    public PlayerMovementScript player;
    public GameObject UIElement;
    private GameObject friend1;
    private GameObject friend2;
    private GameObject friend3;
    public LightUpSingleCoral coralLight;
    public bool coral1;
    public bool coral2;
    public LightUpArea _lightUpArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(checkFriend.friend1there)
        {
            friend1 = GameObject.Find("Friend1");
        }
        if (checkFriend.friend2there)
        {
            friend2 = GameObject.Find("Friend2");
        }
        if (checkFriend.friend3there)
        {
            friend3 = GameObject.Find("Friend3");
        }
        if ((checkFriend.friend1there||checkFriend.playerthere||checkFriend.friend2there)&&(checkFriend2.friend1there||checkFriend2.playerthere || checkFriend2.friend2there))
        {
            if (UIElement != null)
            {
                UIElement.GetComponent<SpriteRenderer>().enabled = true;
            }
            if(player.hugs)
            {
                //GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                if(coral1)
                {
                    coralLight.startFade = true;
                }
                if(coral2)
                {
                    _lightUpArea.startFade = true;
                }
                Destroy(UIElement);
                if(friend1 !=null)
                {
                 friend1.GetComponent<Following>().isFollowing = true;
                }
                if (friend2 != null)
                {
                    friend2.GetComponent<Following>().isFollowing = true;
                }
                if (friend3 != null)
                {
                    friend3.GetComponent<Following>().isFollowing = true;
                }
            }
        }
    }
}
