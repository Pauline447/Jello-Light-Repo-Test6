using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallingFriendsUI : MonoBehaviour
{
    public Sprite interationLeft;
    public Sprite interationLeftActive;
    public Sprite interationRight;
    public Sprite interationRightActive;
    public Sprite interationUp;
    public Sprite interationUpActive;
    public Sprite interationDown;
    public Sprite interationDownActive;
    public Sprite interationDownandUp;
    public Sprite interationDownandUpActive;
    public Sprite interationDownandLeft;
    public Sprite interationDownandLeftActive;
    public Sprite interationDownandRight;
    public Sprite interationDownandRightActive;
    public Sprite interationUpandLeft;
    public Sprite interationUpandLeftActive;
    public Sprite interationUpandRight;
    public Sprite interationUpandRightActive;
    public Sprite interationLeftandRight;
    public Sprite interationLeftandRightActive;
    public Sprite interationAll;
    public Sprite interationAllActive;
    public Sprite zero;
    private Image UIimage;

    public int interactionCase;
    public GameObject UIinteraction;

    public int numberOfInteractions;
    public SetFriendCase _SetFriendCase;

    public InteractionPossible[] interactions; 

    // Start is called before the first frame update
    void Start()
    {
        UIimage = UIinteraction.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numberOfInteractions; i++)
        {
            if(interactions[i].interactionPossibleBool)
            {
                interactionCase = interactions[i].friendCase;
                ChangeUI();
            }
            else
            {
                interactionCase = _SetFriendCase.caseforUI;
            }
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
            case 5:
                UIimage.sprite = interationDownandUp;
                break;
            case 6:
                UIimage.sprite = interationDownandLeft;
                break;
            case 7:
                UIimage.sprite = interationDownandRight;
                break;
            case 8:
                UIimage.sprite = interationUpandLeft;
                break;
            case 9:
                UIimage.sprite = interationUpandRight;
                break;
            case 10:
                UIimage.sprite = interationLeftandRight;
                break;
            case 11:
                UIimage.sprite = interationAll;
                break;
            case 12:
                UIimage.sprite = interationLeftActive;
                break;
            case 13:
                UIimage.sprite = interationRightActive;
                break;
            case 14:
                UIimage.sprite = interationUpActive;
                break;
            case 15:
                UIimage.sprite = interationDownActive;
                break;
            case 16:
                UIimage.sprite = interationDownandUpActive;
                break;
            case 17:
                UIimage.sprite = interationDownandLeftActive;
                break;
            case 18:
                UIimage.sprite = interationDownandRightActive;
                break;
            case 19:
                UIimage.sprite = interationUpandLeftActive;
                break;
            case 20:
                UIimage.sprite = interationUpandRightActive;
                break;
            case 21:
                UIimage.sprite = interationLeftandRightActive;
                break;
            case 22:
                UIimage.sprite = interationAllActive;
                break;
        }
    }
}
