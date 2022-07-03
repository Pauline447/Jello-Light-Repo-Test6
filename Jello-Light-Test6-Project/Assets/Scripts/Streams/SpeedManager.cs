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

    public PlayerMovementScript player;

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
        playerDefaultSpeed = player.GetDefaultDashSpeed();
        playerDefaultMinSpeed = player.GetDefaultMinSpeed();
        playerDefaultParticleEmissionDash = player.GetDefaultParticleEmissionDash();
    }

    // Update is called once per frame
    void Update()
    {
        //Player wird schneller jenachdem, wieviele Freunde er hat
        if (Friends[0].isFollowing && Friends[1].isFollowing && Friends[2].isFollowing)
        {
            player.SetDashSpeed(playerDefaultSpeed + AddToPlayerSpeedWhen3);
            player.SetMinSpeed(playerDefaultMinSpeed + AddToPlayerSpeedWhen3);
            player.SetParticleEmissionDash(playerDefaultParticleEmissionDash + AddToPlayerParticleWhen3);
        }
        else if ((Friends[0].isFollowing && Friends[1].isFollowing) || (Friends[2].isFollowing && Friends[1].isFollowing) || (Friends[2].isFollowing && Friends[0].isFollowing))
        {
            player.SetDashSpeed(playerDefaultSpeed + AddToPlayerSpeedWhen2);
            player.SetMinSpeed(playerDefaultMinSpeed + AddToPlayerSpeedWhen2);
            player.SetParticleEmissionDash(playerDefaultParticleEmissionDash + AddToPlayerParticleWhen2);
        }
        else if ((Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && !Friends[1].isFollowing && Friends[2].isFollowing))
        {
            player.SetDashSpeed(playerDefaultSpeed + AddToPlayerSpeedWhen1);
            player.SetMinSpeed(playerDefaultMinSpeed + AddToPlayerSpeedWhen1);
            player.SetParticleEmissionDash(playerDefaultParticleEmissionDash + AddToPlayerParticleWhen1);
        }
        else if (!Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing)
        {
            player.SetDashSpeed(playerDefaultSpeed);
            player.SetMinSpeed(playerDefaultMinSpeed);
            player.SetParticleEmissionDash(playerDefaultParticleEmissionDash);
        }

        speed = player.GetComponent<PlayerMovementScript>().defaultDashSpeed;

        
        //verlangsamt Player, wenn er in der Strömung is
            if (pushBack[0].pushBackBool)
            {
                if ((Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && !Friends[1].isFollowing && Friends[2].isFollowing))
                {
                    player.SetDashSpeed(speed / 2 + 5);
                    player.SetMinSpeed(playerDefaultMinSpeed / 2 + 5);
                }
                else if (!Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing)
                {
                    player.SetDashSpeed(speed / 2);
                    player.SetMinSpeed(playerDefaultMinSpeed / 2);
                }
            }
            if (pushBack[1].pushBackBool)
            {
                if (Friends[0].isFollowing && Friends[1].isFollowing && Friends[2].isFollowing)
                {
                    player.SetDashSpeed(speed / 2 + 5);
                    player.SetMinSpeed(playerDefaultMinSpeed / 2 + 5);
                }
                else if ((Friends[0].isFollowing && Friends[1].isFollowing) || (Friends[2].isFollowing && Friends[1].isFollowing) || (Friends[2].isFollowing && Friends[0].isFollowing))
                {
                    player.SetDashSpeed(speed / 2);
                    player.SetMinSpeed(playerDefaultMinSpeed / 2);
                }
                else if ((Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && !Friends[1].isFollowing && Friends[2].isFollowing))
                {
                    player.SetDashSpeed(speed / 2);
                    player.SetMinSpeed(playerDefaultMinSpeed / 2);
                }
                else if (!Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing)
                {
                    player.SetDashSpeed(speed / 2);
                    player.SetMinSpeed(playerDefaultMinSpeed / 2);
                }
            }
            if (pushBack[2].pushBackBool)
            {
                if (Friends[0].isFollowing && Friends[1].isFollowing && Friends[2].isFollowing)
                {
                    player.SetDashSpeed(speed / 2 + 5);
                    player.SetMinSpeed(playerDefaultMinSpeed / 2 + 5);
                }
                else if ((Friends[0].isFollowing && Friends[1].isFollowing) || (Friends[2].isFollowing && Friends[1].isFollowing) || (Friends[2].isFollowing && Friends[0].isFollowing))
                {
                    player.SetDashSpeed(speed / 2);
                    player.SetMinSpeed(playerDefaultMinSpeed / 2);
                }
                else if ((Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && Friends[1].isFollowing && !Friends[2].isFollowing) || (!Friends[0].isFollowing && !Friends[1].isFollowing && Friends[2].isFollowing))
                {
                    player.SetDashSpeed(speed / 2);
                    player.SetMinSpeed(playerDefaultMinSpeed / 2);
                }
                else if (!Friends[0].isFollowing && !Friends[1].isFollowing && !Friends[2].isFollowing)
                {
                    player.SetDashSpeed(speed / 2);
                    player.SetMinSpeed(playerDefaultMinSpeed / 2);
                }
            }
    }
}
