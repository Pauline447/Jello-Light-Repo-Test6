using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class OnTriggerTrackControl : MonoBehaviour
{
    public MMFeedbacks _startControl;
    public MMFeedbacks _stopControl;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _startControl.PlayFeedbacks();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _stopControl.PlayFeedbacks();
        }
    }

}
