using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public Following Friend1;
    public Following Friend2;
    public Following Friend3;

    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;

    public GameObject playerLight;

    public PlayerMovementNew player;

    private bool ableToHug = false;

    public int numberOfFish = 0;
    public int numberOfFishFollowing = 0;
   
    private float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = player.GetComponent<PlayerMovementNew>().GetDefaultDashSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        //Nummer hochsetzten
        if (Friend1.isFollowing)
        {
            Light1.SetActive(true);
            Friend1.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
            if (!Friend1.doneonce)
            {
                numberOfFish++;
                Friend1.SetDoneOnce();
                //playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius = 2;
                playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 10;
            }
        }
        if (Friend2.isFollowing)
        {
            Light2.SetActive(true);
            Friend2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            if (!Friend2.doneonce)
            {
                numberOfFish++;
                Friend2.SetDoneOnce();
                //playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius = 3;
                playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 11;
            }
        }
        if (Friend3.isFollowing)
        {
            Friend3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            Light3.SetActive(true);
            if (!Friend3.doneonce)
            {
                numberOfFish++;
                Friend3.SetDoneOnce();
               // playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius = 4;
                playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 12;
            }
        }
        //jeweiligen Freund umarmen
        if (player.hugs == true && Friend1.inRange)
        {
            Friend1.isFollowing = true;
            Friend1.SetHugged();
            player.friend1stopped = false;
        }

        if (player.hugs == true && Friend2.inRange)
        {
            Friend2.isFollowing = true;
            Friend2.SetHugged();
            player.friend2stopped = false;
        }
        if (player.hugs == true && Friend3.inRange)
        {
            Friend3.isFollowing = true;
            Friend3.SetHugged();
            player.friend3stopped = false;
        }
       
        //jeweiligen Freund stoppen
        if (Friend1.hugged == true && player.friend1stopped ==true)
        {
            Friend1.isFollowing = false;
        }
        if (Friend2.hugged == true && player.friend2stopped == true)
        {
            Friend2.isFollowing = false;   
        }
        if (Friend3.hugged == true && player.friend3stopped == true)
        {
            Friend3.isFollowing = false;
        }
    }
}
