using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nn.hid;

public class StartRumble : MonoBehaviour
{
    public RumbleManager _rumbleManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _rumbleManager.SetRumble(0, new VibrationValue(2f,4f,5f,6f));
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _rumbleManager.TurnOffRumble(0);
        }
    }
}
