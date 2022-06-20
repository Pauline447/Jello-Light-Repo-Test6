using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerStones : MonoBehaviour
{
    public PlayerMovementNew player;
    public GameObject stones;
    public bool stonefalling = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Igel")
        {
            //player.enabled = true;
            stones.SetActive(true);
            stonefalling = true;
        }
    }
}
