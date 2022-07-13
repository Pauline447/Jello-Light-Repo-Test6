using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class CheckIfWormIsWalking : MonoBehaviour
{
    public Transform[] BristleWormTargets;
    public Transform bristleworm;
    public bool isWalking = false; //set private
    public MMFeedbacks soundFeedback;
    public MMFeedbacks soundFeedbackStop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<BristleWormTargets.Length-1;i++)
        {
            if (bristleworm == BristleWormTargets[i])
            {
                isWalking = false;
            }
            else isWalking = true;
        }
        if(isWalking)
        {
           // soundFeedback.PlayFeedbacks();
        }
        else
        {
            //soundFeedbackStop.PlayFeedbacks();
        }
    }
}
