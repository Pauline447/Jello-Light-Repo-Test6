using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public Following Friend1;
    public Following Friend2;
    public Following Friend3;

    public float playerDefaultSpeed;

    public PushBack pushBack;

    public PlayerMovementNew player;

    //löschen
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerDefaultSpeed = player.GetComponent<PlayerMovementNew>().GetDefaultDashSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        //if (pushBack.pushBackBool)
        //{
        //    player.GetComponent<PlayerMovementNew>().SetDashSpeed(speeeeeed / 2);
        //}
        //else
        if (Friend1.isFollowing && Friend2.isFollowing && Friend3.isFollowing)
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed + 4);
        }
        else if ((Friend1.isFollowing && Friend2.isFollowing) || (Friend3.isFollowing && Friend2.isFollowing) || (Friend3.isFollowing && Friend1.isFollowing))
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed + 2);
        }
        else if ((Friend1.isFollowing && !Friend2.isFollowing && !Friend3.isFollowing) || (!Friend1.isFollowing && Friend2.isFollowing && !Friend3.isFollowing) || (!Friend1.isFollowing && !Friend2.isFollowing && Friend3.isFollowing))
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed + 1);
        }
        else if (!Friend1.isFollowing && !Friend2.isFollowing && !Friend3.isFollowing)
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed);
        }
        speed = player.GetComponent<PlayerMovementNew>().defaultDashSpeed;
        if (pushBack.pushBackBool)
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(speed / 2);
        }
    }
}
