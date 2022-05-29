using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStream : MonoBehaviour
{
    public GameObject Visual;
    public GameObject Stream;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Stream.SetActive(true);
            Visual.SetActive(true);
        }
    }
}
