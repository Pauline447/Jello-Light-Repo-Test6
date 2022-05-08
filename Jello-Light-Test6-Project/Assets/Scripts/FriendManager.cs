using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public Following Friend1;
    public Following Friend2;

    public GameObject Light1;
    public GameObject Light2;

    public int numberOfFish = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Friend1.isFollowing)
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
    }
}
