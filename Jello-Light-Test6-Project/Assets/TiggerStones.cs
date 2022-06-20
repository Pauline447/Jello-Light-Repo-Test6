using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerStones : MonoBehaviour
{
    public PlayerMovementNew player;
    public GameObject stones;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Stones")
        {
            //player.enabled = true;
            stones.SetActive(true);
            player.enabled = true;
        }
    }
}
