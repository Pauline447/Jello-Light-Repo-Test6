using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwMainStart : MonoBehaviour
{
    public string EventName = "_ambient_main";
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
        AkSoundEngine.PosteEvent(EventName, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
