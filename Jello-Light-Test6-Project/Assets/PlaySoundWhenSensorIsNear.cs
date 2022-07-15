using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PlaySoundWhenSensorIsNear : MonoBehaviour
{
    public MMFeedbacks startSoudnFeedback;
    public MMFeedbacks stopSoundFeedback;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            startSoudnFeedback.PlayFeedbacks();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            stopSoundFeedback.PlayFeedbacks();
        }
    }
}
