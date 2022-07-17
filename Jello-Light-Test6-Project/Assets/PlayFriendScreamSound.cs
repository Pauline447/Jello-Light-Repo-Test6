using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PlayFriendScreamSound : MonoBehaviour
{
    public MMFeedbacks _FeedbacksPlay;
    public MMFeedbacks _FeedbacksFree;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _FeedbacksPlay.PlayFeedbacks();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _FeedbacksFree.PlayFeedbacks();
        }
    }
}
