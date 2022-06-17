using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFriendCase : MonoBehaviour
{
    public Following friend1;
    public Following friend2;
    public Following friend3;
    public int caseforUI;
    public bool interactionPossibleBool = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (friend1.isFollowing && !friend2.isFollowing && !friend3.isFollowing)
        {
            if (interactionPossibleBool)
            {
                caseforUI = 15;
            }
            else caseforUI = 4;
        }
        if (!friend1.isFollowing && friend2.isFollowing && !friend3.isFollowing)
        {
            if (interactionPossibleBool)
            {
                caseforUI = 12;
            }
            else caseforUI = 1;
        }
        if (!friend1.isFollowing && !friend2.isFollowing && friend3.isFollowing)
        {
            if (interactionPossibleBool)
            {
                caseforUI = 13;
            }
            else caseforUI = 2;
        }
        if (!friend1.isFollowing && !friend2.isFollowing && !friend3.isFollowing)
        {
            if (interactionPossibleBool)
            {
                caseforUI = 0;
            }
            else caseforUI = 0;
        }
        if (friend1.isFollowing && friend2.isFollowing & !friend3.isFollowing)
        {
            if (interactionPossibleBool)
            {
                caseforUI = 17;
            }
            else
                caseforUI = 6;
        }
        if (!friend1.isFollowing && friend2.isFollowing & friend3.isFollowing)
        {
            if (interactionPossibleBool)
            {
                caseforUI = 21;
            }
            else
                caseforUI = 10;
        }
        if (friend1.isFollowing && !friend2.isFollowing & friend3.isFollowing)
        {
            if (interactionPossibleBool)
            {
                caseforUI = 18;
            }
            else
                caseforUI = 7;
        }
        if (friend1.isFollowing && friend2.isFollowing & friend3.isFollowing)
        {
            if (interactionPossibleBool)
            {
                caseforUI = 24;
            }
            else
                caseforUI = 28;
        }
    }
}
