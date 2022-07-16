using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PlayAthmo : MonoBehaviour
{
    public MMFeedbacks playAthmo;
    // Start is called before the first frame update
    void Start()
    {
        playAthmo.PlayFeedbacks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
