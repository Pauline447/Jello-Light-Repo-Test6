using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStream : MonoBehaviour
{
    public bool active = false;
    public GameObject Visual;
    public GameObject Stream;
    public PolygonCollider2D polyCol;
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
            active = true;
            Stream.SetActive(true);
            Visual.SetActive(true);
            polyCol.enabled=true;
        }
    }
}
