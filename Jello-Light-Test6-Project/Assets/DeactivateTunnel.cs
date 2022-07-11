using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateTunnel : MonoBehaviour
{
    public GameObject tunnel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            tunnel.SetActive(false);
        }
    }
}
