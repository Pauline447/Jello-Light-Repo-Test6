using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public Following Friend1;
    public Following Friend2;
    public Following Friend3;

    public float playerSpeed;

    public PushBack pushBack;

    public PlayerMovementNew player;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = player.GetComponent<PlayerMovementNew>().GetDefaultDashSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (pushBack.pushBackBool)
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerSpeed / 3);
        }
        else if (Friend1.isFollowing && Friend2.isFollowing && Friend3.isFollowing)
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerSpeed + 4);
        }
        else if ((Friend1.isFollowing && Friend2.isFollowing) || (Friend3.isFollowing && Friend2.isFollowing) || (Friend3.isFollowing && Friend1.isFollowing))
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerSpeed + 2);
        }
        else if ((Friend1.isFollowing && !Friend2.isFollowing && !Friend3.isFollowing) || (!Friend1.isFollowing && Friend2.isFollowing && !Friend3.isFollowing) || (!Friend1.isFollowing && !Friend2.isFollowing && Friend3.isFollowing))
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerSpeed + 1);
        }
        else if (!Friend1.isFollowing && !Friend2.isFollowing && !Friend3.isFollowing)
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerSpeed);
        }
    }
}
