using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPossible : MonoBehaviour
{
    public SetFriendCase _setFriendCase; //wird von UI genutzt
    public int friendCase; //muss in Unity eingestellt werden
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
        if (other.tag == "Player")
        {
            _setFriendCase.interactionPossibleBool = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _setFriendCase.interactionPossibleBool = false;
        }
    }
}
