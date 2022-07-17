using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class StartFallSound : MonoBehaviour
{
    public MMFeedbacks _playFallFeedback;
    public MMFeedbacks _stopFallFeedback;
    public MMFeedbacks _EatFallFeedback;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void PlayFeedbackKick()
    {
        _playFallFeedback.PlayFeedbacks();
    }
    public void StopFeedbackKick()
    {
        _stopFallFeedback.PlayFeedbacks();
    }
    public void PlayFeedbackEat()
    {
        _EatFallFeedback.PlayFeedbacks();
    }

}
