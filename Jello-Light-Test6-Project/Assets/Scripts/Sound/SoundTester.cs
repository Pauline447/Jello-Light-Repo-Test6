using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;

public class SoundTester : MonoBehaviour
{
    public AudioClip myClip;
    public bool playEvent;
    public MMFeedbacks _Feedback;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playEvent)
        {
            _Feedback?.PlayFeedbacks();
        }
    }
    public void PlayMySound()
    {
        MMSoundManagerSoundPlayEvent.Trigger(myClip, MMSoundManager.MMSoundManagerTracks.Sfx, this.transform.position);
    }
}
