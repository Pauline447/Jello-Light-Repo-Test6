using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStream : MonoBehaviour
{
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
            Destroy(Stream);
        }
    }
}
