using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PlaySoundOnTriggerEnter : MonoBehaviour
{
    public MMFeedbacks _FeedbacksPlay;
    public MMFeedbacks _FeedbacksStop;
    public MMFeedbacks _FeebacksResume;

    private bool doneonce = false;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(!doneonce)
            {
                _FeedbacksPlay.PlayFeedbacks();
                doneonce = true;
            }
            else
            {
                _FeebacksResume.PlayFeedbacks();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _FeedbacksPlay.StopFeedbacks();
            _FeedbacksStop.PlayFeedbacks();
        }
    }
}
