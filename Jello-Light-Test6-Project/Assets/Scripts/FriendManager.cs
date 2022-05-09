using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public Following Friend1;
    public Following Friend2;

    public GameObject Light1;
    public GameObject Light2;

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
        if (Friend1.isFollowing)
        {
            Light1.SetActive(true);
            if (!Friend1.doneonce)
            {
                numberOfFish++;
                Friend1.SetDoneOnce();
            }
        }
        if (Friend2.isFollowing)
        {
            Light2.SetActive(true);
            if (!Friend2.doneonce)
            {
                numberOfFish++;
                Friend2.SetDoneOnce();
            }
        }
        if (player.hugs == true && Friend1.inRange)
        {
            Friend1.SetHugged();
        }
        if (player.hugs == true && Friend2.inRange)
        {
            Friend2.SetHugged();
        }
    }
}
