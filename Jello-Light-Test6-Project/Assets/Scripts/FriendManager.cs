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
    private float lightRadius;
    public float addLightValue = 1;

    public PlayerMovementNew player;

    public int numberOfFish = 0;
    public int numberOfFishFollowing = 0;

    public interactionUI2 UIstuff;
   

    // Start is called before the first frame update
    void Start()
    {
        lightRadius = playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius;
    }

    // Update is called once per frame
    void Update()
    {
        playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = lightRadius;

        //Nummer hochsetzten
        if (Friend1.isFollowing)
        {
            Light1.SetActive(true);
            Friend1.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
            if (!Friend1.doneonce)
            {
                numberOfFish++;
                Friend1.SetDoneOnce();
                lightRadius = lightRadius + addLightValue;
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
                lightRadius = lightRadius + addLightValue;
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
                lightRadius = lightRadius + addLightValue;
            }
        }
        //jeweiligen Freund umarmen
        if (player.hugs == true && Friend1.inRange)
        {
            Friend1.SetHugged();
        }

        if (player.hugs == true && Friend2.inRange)
        {
            Friend2.SetHugged();
        }
        if (player.hugs == true && Friend3.inRange)
        {
            Friend3.SetHugged();
        }
       
        //jeweiligen Freund stoppen
        if (Friend1.hugged == true && player.friend1called ==true && Friend1.isFollowing == true && player.friend1called == true)
        {
            StartCoroutine(StopFriend(Friend1));
        }
        if (Friend2.hugged == true && player.friend2called == true && Friend2.isFollowing == true)
        {
            StartCoroutine(StopFriend(Friend2));
        }
        if (Friend3.hugged == true && player.friend3called == true && Friend2.isFollowing == true)
        {
            StartCoroutine(StopFriend(Friend3));
        }

        //jeweiligen Freund starten
        if (Friend1.hugged == true && Friend1.isFollowing == false && Friend1.inRange &&player.friend1called == true)
        {
            StartCoroutine(StartFriend(Friend1));
        }
        if (Friend2.hugged == true && Friend2.isFollowing == false && Friend2.inRange && player.friend2called == true)
        {
            StartCoroutine(StartFriend(Friend2));
        }
        if (Friend3.hugged == true && Friend3.isFollowing == false && Friend3.inRange && player.friend3called == true)
        {
            StartCoroutine(StartFriend(Friend3));
        }

        //UI
        if (player.ableToHug && Friend1.isFollowing && Friend2.inRange == false)
        {
            UIstuff.interactionCase = 0;
            UIstuff.ChangeUI();
        }

        else if (player.ableToHug && Friend2.isFollowing == false)
        {
            UIstuff.interactionCase = 1;
            UIstuff.ChangeUI();
        }

        if (player.ableToHug && Friend2.isFollowing)
        {
            UIstuff.interactionCase = 0;
            UIstuff.ChangeUI();
        }
    }
    private IEnumerator StartFriend(Following friend)
    {
        yield return new WaitForSeconds(0.2f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
        friend.isFollowing = true;
    }
    private IEnumerator StopFriend(Following friend)
    {
        yield return new WaitForSeconds(0.2f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
        friend.isFollowing = false;
    }
}
