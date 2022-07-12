using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Following Friend;
    public Image _ImageFriend;

    public int whichFriendUI =0;

    private int FriendCase;
    //private int FriendCase2 = 0;
    //private int FriendCase3 = 0;

    public bool interactionPossible; //has to be set to true in the Interaction possible script
    public Sprite zero;
    public Sprite friendAway;
    public Sprite friendFollowing;
    public Sprite friendhuggeble;
    public Sprite friendPlacable;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (whichFriendUI)
        {
            case 1:
                Friend = GameObject.Find("Friend1").GetComponent<Following>();
                break;
            case 2:
                Friend = GameObject.Find("Friend2").GetComponent<Following>();
                break;
            case 3:
                Friend = GameObject.Find("Friend3").GetComponent<Following>();
                break;
        }

        if (Friend.isFollowing && interactionPossible)
            {
                FriendCase = 1; //abstellbar
            }
            else if (Friend.isFollowing && !interactionPossible)
            {
                FriendCase = 2; //bei Player
            }
            else if (!Friend.isFollowing && Friend.inRange)
            {
                FriendCase = 3; //freund aufsammelbar
            }
            else if (!Friend.isFollowing && !Friend.inRange)
            {
                FriendCase = 4; //freund nicht in der Nähe
            }
            else
            {
                FriendCase = 0;
            }

            switch (FriendCase)
            {
            case 0:
                _ImageFriend.sprite = zero;
                break;
            case 1:
                _ImageFriend.sprite = friendPlacable;
                    break;
            case 2:
                _ImageFriend.sprite = friendFollowing;
                    break;
            case 3:
                _ImageFriend.sprite = friendhuggeble;
                    break;
            case 4:
                _ImageFriend.sprite = friendAway;
                break;
            }
    }
}
