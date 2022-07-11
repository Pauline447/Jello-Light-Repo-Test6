using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugOctupus : MonoBehaviour
{
    public Following friend1;
    public Following friend2;
    public Following friend3;

    public GameObject lastParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (friend1.atTentecal && friend2.atTentecal && friend3.atTentecal)
        {
            lastParticle.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //zoom in
            //UI
            //if player hugs, StartCoroutine --> End of Game --> zoom in again, hug animation --> fade to white, load next scene
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //zoom out
        }
    }
}
