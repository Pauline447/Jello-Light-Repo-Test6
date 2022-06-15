using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public Following[] Friends;

    private float playerDefaultSpeed; //wird vielleicht wo anders genutzt?

    public int NumberOfPushbacks; //muss von Player eingestellt werden
    public PushBack[] pushBack;

    public PlayerMovementNew player;

    public float AddToPlayerSpeedWhen3 = 4f;
    public float AddToPlayerSpeedWhen2 = 2f;
    public float AddToPlayerSpeedWhen1 = 1f;

    public float speed; 


    // Start is called before the first frame update
    void Start()
    {
        playerDefaultSpeed = player.GetComponent<PlayerMovementNew>().GetDefaultDashSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        //Player wird schneller jenachdem, wieviele Freunde er hat
        if (Friends[0].isFollowing && Friends[1].isFollowing && Friends[2].isFollowing)
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed + AddToPlayerSpeedWhen3);
        }
        else if ((Friends[0].isFollowing && Friends[1].isFollowing) || (Friends[2].isFollowing && Friends[1].isFollowing) || (Friends[2].isFollowing && Friends[0].isFollowing))
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed + AddToPlayerSpeedWhen2);
        }
        else if ((Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && !Friends[1].isFollowing && Friends[2].isFollowing))
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed + AddToPlayerSpeedWhen1);
        }
        else if (!Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing)
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed);
        }

        speed = player.GetComponent<PlayerMovementNew>().defaultDashSpeed;

        
        //verlangsamt Player, wenn er in der Strömung is

        for (int i =0; i < NumberOfPushbacks; i++)
        {
            if (pushBack[i].pushBackBool)
            {
                player.GetComponent<PlayerMovementNew>().SetDashSpeed(speed / 2);
            }
        }
    }
}
