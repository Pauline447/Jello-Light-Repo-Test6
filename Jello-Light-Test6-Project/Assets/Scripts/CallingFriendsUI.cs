using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallingFriendsUI : MonoBehaviour
{
    public Sprite interationLeft;
    //public Sprite interationRight;
    //public Sprite interationUp;
    public Sprite interationDown;
    //public Sprite interationDownandUp;
    //public Sprite interationDownandLeft;
    //public Sprite interationDownandRight;
    public Sprite interationUpandLeft;
    //public Sprite interationUpandRight;
    //public Sprite interationLeftandRight;
    //public Sprite interationAll;
    public Sprite zero;
    private Image UIimage;

    public int interactionCase;
    public GameObject UIinteraction;
    
    public InteractionPossible m_interactionPossible;
    public InteractionPossible m_interactionPossible1;
    public InteractionPossible m_interactionPossible2;
    public InteractionPossible m_interactionPossible3;

    // Start is called before the first frame update
    void Start()
    {
        UIimage = UIinteraction.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_interactionPossible.interactionPossibleBool)
        {
            interactionCase = m_interactionPossible.friendCase;
            ChangeUI();
        }
        else if (m_interactionPossible1.interactionPossibleBool)
        {
            interactionCase = m_interactionPossible1.friendCase;
            ChangeUI();
        }
        else if (m_interactionPossible2.interactionPossibleBool)
        {
            interactionCase = m_interactionPossible2.friendCase;
            ChangeUI();
        }
        else if (m_interactionPossible3.interactionPossibleBool)
        {
            interactionCase = m_interactionPossible3.friendCase;
            ChangeUI();
        }
        else
        {
            interactionCase = 0;
            ChangeUI();
        }
    }

    public void ChangeUI()
    {
        switch (interactionCase)
        {
            case 0:
                UIimage.sprite = zero;
                break;
            case 1:
                UIimage.sprite = interationLeft;
                break;
            //case 2:
            //    UIimage.sprite = interationRight;
            //    break;
            //case 3:
            //    UIimage.sprite = interationUp;
            //    break;
            case 4:
                UIimage.sprite = interationDown;
                break;
            //case 5:
            //    UIimage.sprite = interationDownandUp;
            //    break;
            //case 6:
            //    UIimage.sprite = interationDownandLeft;
            //    break;
            //case 7:
            //    UIimage.sprite = interationDownandRight;
            //    break;
            case 8:
                UIimage.sprite = interationUpandLeft;
                break;
            //case 9:
            //    UIimage.sprite = interationUpandRight;
            //    break;
            //case 10:
            //    UIimage.sprite = interationLeftandRight;
            //    break;
            //case 11:
            //    UIimage.sprite = interationAll;
            //    break;


        }
    }
}
