using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallingFriendsUI : MonoBehaviour
{
    public Sprite interationLeft;
    public Sprite interationRight;
    public Sprite interationUp;
    public Sprite interationDown;
    public Sprite zero;
    private Image UIimage;

    public int interactionCase;
    public GameObject UIinteraction;
    public InteractionPossible m_interactionPossible;

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
        }
        else
        {
            interactionCase = 0;
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
            case 2:
                UIimage.sprite = interationRight;
                break;
            case 3:
                UIimage.sprite = interationUp;
                break;
            case 4:
                UIimage.sprite = interationDown;
                break;

        }
    }
}
