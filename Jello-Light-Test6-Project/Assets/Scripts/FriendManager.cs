using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public Following Friend1;
    public Following Friend2;

    public GameObject Light1;
    public GameObject Light2;

    public GameObject playerLight;

    public PlayerMovement player;

    private bool ableToHug = false;

    public int numberOfFish = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Nummer hochsetzten
        if (Friend1.isFollowing)
        {
            Light1.SetActive(true);
            if (!Friend1.doneonce)
            {
                numberOfFish++;
                Friend1.SetDoneOnce();
                playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius = 2;
                playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 4;
            }
        }
        if (Friend2.isFollowing)
        {
            Light2.SetActive(true);
            if (!Friend2.doneonce)
            {
                numberOfFish++;
                Friend2.SetDoneOnce();
                playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius = 3;
                playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 5;
            }
        }
        //jeweiligen Freund umarmen
        if (player.hugs == true && Friend1.inRange)
        {
            Friend1.SetHugged();
            player.friend1stopped = false;
        }

        if (player.hugs == true && Friend2.inRange)
        {
            Friend2.SetHugged();
            player.friend2stopped = false;
        }
        //jeweiligen Freund stoppen
        if(Friend1.hugged == true && player.friend1stopped ==true)
        {
            Friend1.isFollowing = false;
        }

        if (Friend2.hugged == true && player.friend2stopped == true)
        {
            Friend2.isFollowing = false;
        }
    }
}
