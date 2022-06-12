using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPossible : MonoBehaviour
{
    public bool interactionPossibleBool = false;
    public int friendCase;
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
            interactionPossibleBool = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactionPossibleBool = false;
        }
    }
}
