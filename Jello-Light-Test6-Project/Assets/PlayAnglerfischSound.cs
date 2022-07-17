using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PlayAnglerfischSound : MonoBehaviour
{
    public MMFeedbacks _FeedbacksPlay;
    public MMFeedbacks _FeedbacksStop;
    public MMFeedbacks _FeebacksResume;

    public MMFeedbacks _FeedbackmusicLaut1;
    public MMFeedbacks _FeedbackmusicLaut2;
    public MMFeedbacks _FeedbackmusicLaut3;
    //public MMFeedbacks _FeedbackmusicLaut4;

    public MMFeedbacks _FeedbackmusicLeise1;
    public MMFeedbacks _FeedbackmusicLeise2;
    public MMFeedbacks _FeedbackmusicLeise3;
    //public MMFeedbacks _FeedbackmusicLeise4;

    private bool doneonce = false;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!doneonce)
            {
                _FeedbackmusicLeise1.PlayFeedbacks();
                _FeedbackmusicLeise2.PlayFeedbacks();
                _FeedbackmusicLeise3.PlayFeedbacks();
                //_FeedbackmusicLeise4.PlayFeedbacks();

                _FeedbacksPlay.PlayFeedbacks();
                doneonce = true;
            }
            else
            {
                _FeedbackmusicLeise1.PlayFeedbacks();
                _FeedbackmusicLeise2.PlayFeedbacks();
                _FeedbackmusicLeise3.PlayFeedbacks();
                //_FeedbackmusicLeise4.PlayFeedbacks();

                _FeebacksResume.PlayFeedbacks();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _FeedbackmusicLaut1.PlayFeedbacks();
            _FeedbackmusicLaut2.PlayFeedbacks();
            _FeedbackmusicLaut3.PlayFeedbacks();
            //_FeedbackmusicLaut4.PlayFeedbacks();

            _FeedbacksPlay.StopFeedbacks();
            _FeedbacksStop.PlayFeedbacks();
        }
    }
}
