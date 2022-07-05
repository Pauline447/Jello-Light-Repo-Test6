using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactionUI : MonoBehaviour
{
    public Sprite interactionB;
    public Sprite zero;
    private Image UIimage;
    public int interactionCase;
    public GameObject UIinteraction;
    public PlayerMovementScript Player;

    // Start is called before the first frame update
    void Start()
    {
        UIimage = UIinteraction.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Player.ableToHug)
        {
            interactionCase = 1;
            ChangeUI();
        }  
       
       if (Player.ableToHug == false)
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
                UIimage.sprite = interactionB;
                break;
        }
    }
}
