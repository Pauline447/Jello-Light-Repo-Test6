using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using MoreMountains.Feedbacks;

public class FriendManager : MonoBehaviour
{
  //  public int NumberOfFriends; //= NumberOfFriendLights and NumberOfUIStuff
    public Following[] Friends; 

    public Light2D[] FriendLights; 

    public GameObject playerLight;
    private float lightRadius;
    public float addLightValue = 1; //einstellbar

    public PlayerMovementScript player;

    public int numberOfFish = 0; //actually not needed at all XD
    public int numberOfFishFollowing = 0;
    public int numberOfFriends = 3;

    public interactionUI2[] UIstuff;

   // public Light2D coralLight;

    public float[] maxLuminosity; // max intensity

    public float luminositySteps = 0.001f; // factor when increasing / decreasing

    public bool startFade = false;

    //Sound
    public MMFeedbacks _StopFeedback1;
    public MMFeedbacks _StopFeedback2;
    public MMFeedbacks _StopFeedback3;

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

        for (int i = 0; i < numberOfFriends; i++)
        {
            if (Friends[i].isFollowing)
            {
                StartCoroutine(ChangeIntensity(FriendLights[i], maxLuminosity[i]));
                //FriendLights[i].SetActive(true);
               // Friends[i].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                if (!Friends[i].doneonce)
                {
                    numberOfFish++;
                    Friends[i].SetDoneOnce();
                    lightRadius = lightRadius + addLightValue;
                }
            }
        }

        //jeweiligen Freund umarmen

        for (int i = 0; i < numberOfFriends; i++)
        {
            if (player.hugs == true && Friends[i].inRange)
            {
                Friends[i].SetHugged();
            }
        }

        //jeweiligen Freund stoppen

        for (int i = 0; i < numberOfFriends; i++)
        {
            if (Friends[i].hugged == true && player.friendcalled[i] == true && Friends[i].isFollowing == true)  //hier nochmal schauen
            {
                StartCoroutine(StopFriend(Friends[i]));
            }
        }

        //jeweiligen Freund starten

        for (int i = 0; i < numberOfFriends; i++)
        {
            if (Friends[i].hugged == true && Friends[i].isFollowing == false && Friends[i].inRange && player.friendcalled[i] == true && !Friends[i].atTentecal)
            {
                StartCoroutine(StartFriend(Friends[i]));
            }
        }

        //UI

        for (int i = 0; i < numberOfFriends; i++)
        {
            if (Friends[i].inRange && !Friends[i].hugged)
            {
                UIstuff[i].interactionCase = 1;
                UIstuff[i].ChangeInteractionUI();
            }
            else
            {
                UIstuff[i].interactionCase = 0;
                UIstuff[i].ChangeInteractionUI();
            }
        }
    }
    private IEnumerator StartFriend(Following friend)
    {
        yield return new WaitForSeconds(0.2f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
        friend.isFollowing = true;

        friend.startSoundAgain = true;
        yield return new WaitForSeconds(1f);
        friend.startSoundAgain = false;
    }
    private IEnumerator StopFriend(Following friend)
    {
        yield return new WaitForSeconds(0.2f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////SoundFeedback
        
        if(friend.tag == "Friend1")
        {
            _StopFeedback1.PlayFeedbacks();
        }
        if (friend.tag == "Friend2")
        {
            _StopFeedback2.PlayFeedbacks();
        }
        if (friend.tag == "Friend3")
        {
            _StopFeedback3.PlayFeedbacks();
        }

        friend.isFollowing = false;
        friend.transform.position = Vector3.Lerp(friend.transform.position, player.transform.position, 10f * Time.deltaTime);
        friend.stopped = true;

        friend.stopSound = true;
        yield return new WaitForSeconds(1f);
        friend.stopSound = false;

    }
    private IEnumerator ChangeIntensity(Light2D l, float maxLumi)
    {
        while (l.intensity <= maxLumi)
        {
            l.intensity += luminositySteps; // increase the firefly intensity / fade in
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0f); // wait 3 seconds
    }
}
