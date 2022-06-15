using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFriendCase : MonoBehaviour
{
    public Following friend1;
    public Following friend2;
    public InteractionPossible interaction;
    public int caseforUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (friend1.isFollowing && !friend2.isFollowing)
        {
            interaction.friendCase = 4;
            caseforUI = 4;
        }
        if (!friend1.isFollowing && friend2.isFollowing)
        {
            interaction.friendCase = 1;
            caseforUI = 1;
        }
        if (!friend1.isFollowing && !friend2.isFollowing)
        {
            interaction.friendCase = 0;
            caseforUI = 0;
        }
        if (friend1.isFollowing && friend2.isFollowing)
        {
            interaction.friendCase = 8;
            caseforUI = 0;
        }
    }
}
