using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public Following[] Friends;

    private float playerDefaultSpeed; //wird vielleicht wo anders genutzt?
    private float playerDefaultMinSpeed;
    private int playerDefaultParticleEmissionDash;

    public int NumberOfPushbacks; //muss von Player eingestellt werden
    public PushBack[] pushBack;

    public PlayerMovementNew player;

    public float AddToPlayerSpeedWhen3 = 4f;
    public float AddToPlayerSpeedWhen2 = 2f;
    public float AddToPlayerSpeedWhen1 = 1f;

    public int AddToPlayerParticleWhen3 = 4;
    public int AddToPlayerParticleWhen2 = 2;
    public int AddToPlayerParticleWhen1 = 1;

    public float speed; 


    // Start is called before the first frame update
    void Start()
    {
        playerDefaultSpeed = player.GetComponent<PlayerMovementNew>().GetDefaultDashSpeed();
        playerDefaultMinSpeed = player.GetComponent<PlayerMovementNew>().GetDefaultMinSpeed();
        playerDefaultParticleEmissionDash = player.GetComponent<PlayerMovementNew>().GetDefaultParticleEmissionDash();
    }

    // Update is called once per frame
    void Update()
    {
        //Player wird schneller jenachdem, wieviele Freunde er hat
        if (Friends[0].isFollowing && Friends[1].isFollowing && Friends[2].isFollowing)
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed + AddToPlayerSpeedWhen3);
            player.GetComponent<PlayerMovementNew>().SetMinSpeed(playerDefaultMinSpeed + AddToPlayerSpeedWhen3);
            player.GetComponent<PlayerMovementNew>().SetParticleEmissionDash(playerDefaultParticleEmissionDash + AddToPlayerParticleWhen3);
        }
        else if ((Friends[0].isFollowing && Friends[1].isFollowing) || (Friends[2].isFollowing && Friends[1].isFollowing) || (Friends[2].isFollowing && Friends[0].isFollowing))
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed + AddToPlayerSpeedWhen2);
            player.GetComponent<PlayerMovementNew>().SetMinSpeed(playerDefaultMinSpeed + AddToPlayerSpeedWhen2);
            player.GetComponent<PlayerMovementNew>().SetParticleEmissionDash(playerDefaultParticleEmissionDash + AddToPlayerParticleWhen2);
        }
        else if ((Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && !Friends[1].isFollowing && Friends[2].isFollowing))
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed + AddToPlayerSpeedWhen1);
            player.GetComponent<PlayerMovementNew>().SetMinSpeed(playerDefaultMinSpeed + AddToPlayerSpeedWhen1);
            player.GetComponent<PlayerMovementNew>().SetParticleEmissionDash(playerDefaultParticleEmissionDash + AddToPlayerParticleWhen1);
        }
        else if (!Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing)
        {
            player.GetComponent<PlayerMovementNew>().SetDashSpeed(playerDefaultSpeed);
            player.GetComponent<PlayerMovementNew>().SetMinSpeed(playerDefaultMinSpeed);
            player.GetComponent<PlayerMovementNew>().SetParticleEmissionDash(playerDefaultParticleEmissionDash);
        }

        speed = player.GetComponent<PlayerMovementNew>().defaultDashSpeed;

        
        //verlangsamt Player, wenn er in der Str�mung is

        for (int i =0; i < NumberOfPushbacks; i++)
        {
            if (pushBack[i].pushBackBool)
            {
                player.GetComponent<PlayerMovementNew>().SetDashSpeed(speed / 2);
            }
        }
    }
}
