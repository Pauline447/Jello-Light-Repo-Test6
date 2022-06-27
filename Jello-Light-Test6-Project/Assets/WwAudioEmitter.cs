using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwAudioEmitter : MonoBehaviour
{
    public string EventName = "default";
    public string StopEvent = "default";
    private bool IsInColloder = false;

    void Start()
    {
        //AkSoundEngine.RegisterGameObj(gameObject);
    }

    //auf Game-Object Collider ziehen
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" || IsInColloder)
        {
            return;
        }
        IsInColloder = true;
        //AkSoundEngine.PosteEvent(EventName, gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player" || !IsInColloder)
        {
            return;
        }
        //AkSoundEngine.PostEvent(StopEvent, gameObject);
        IsInColloder = false;
    }

    //private void OnTriggerStay(Collider2D other)
    //{
    //    if (other.tag != "Player" || IsInColloder)
    //    {
    //        return;
    //    }
    //    IsInColloder = true;
    //    //AkSoundEngine.PostEvent(EventName, gameObject);
    //}
}
