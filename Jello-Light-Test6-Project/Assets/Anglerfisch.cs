using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anglerfisch : MonoBehaviour
{
    public Animator animations;

    public float speed = 1f; //geschwindigkeit
    public float amplitude = 1f; //zwischen was es hin und her geht
    public float shift = 0f; //verschiebung auf der y_achse
    public bool PlayerNearAnglerfish = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerNearAnglerfish == true)
        {
            animations.SetFloat("visibility", Mathf.Sin(Time.time * speed) * amplitude + shift);
        }
        else animations.SetFloat("visibility", 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerNearAnglerfish = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerNearAnglerfish = false;
        }
    }
}

