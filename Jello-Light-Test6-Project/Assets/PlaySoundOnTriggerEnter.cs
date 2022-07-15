using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PlaySoundOnTriggerEnter : MonoBehaviour
{
    public MMFeedbacks _FeedbacksPlay;
    public MMFeedbacks _FeedbacksResume;
    public MMFeedbacks _FeedbacksStop;
    private bool doneOnce = false;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(!doneOnce)
            {
                _FeedbacksPlay.PlayFeedbacks();
                doneOnce = true;
            }
            else
            {
                _FeedbacksResume.PlayFeedbacks();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _FeedbacksStop.PlayFeedbacks();
        }
    }
}
