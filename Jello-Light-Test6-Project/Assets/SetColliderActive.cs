using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColliderActive : MonoBehaviour
{
    public GameObject[] checkCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            for(int i =0; i<checkCollider.Length-1; i++)
            {
                checkCollider[i].SetActive(true);
            }
        }
    }
}
