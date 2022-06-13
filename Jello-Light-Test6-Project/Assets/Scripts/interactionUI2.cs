using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionUI2 : MonoBehaviour
{
    public Sprite interactionB;
    public Sprite zero;
    private SpriteRenderer spriteRenderer;
    public int interactionCase;
    public GameObject UIinteraction;
    public PlayerMovementNew Player;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = UIinteraction.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.ableToHug)
        {
            interactionCase = 1;
            ChangeInteractionUI();
        }

        if (Player.ableToHug == false)
        {
            interactionCase = 0;
            ChangeInteractionUI();
        }
    }

    public void ChangeInteractionUI()
    {
        switch (interactionCase)
        {
            case 0:
                spriteRenderer.sprite = zero;
                break;
            case 1:
                spriteRenderer.sprite = interactionB;
                break;
        }
    }
}
