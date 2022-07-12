using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPossible : MonoBehaviour
{
    //public SetFriendCase _setFriendCase; //wird von UI genutzt
    //public int friendCase; //muss in Unity eingestellt werden
    
    public UI_Manager m_UI;
    public UI_Manager m_UI2;
    public UI_Manager m_UI3;

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
            m_UI.interactionPossible = true;
            m_UI2.interactionPossible = true;
            m_UI3.interactionPossible = true;
            //_setFriendCase.interactionPossibleBool = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            m_UI.interactionPossible = false;
            m_UI2.interactionPossible = false;
            m_UI3.interactionPossible = false;
            // _setFriendCase.interactionPossibleBool = false;
        }
    }
}
