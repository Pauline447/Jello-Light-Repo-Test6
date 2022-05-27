using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strömung : MonoBehaviour
{
    public GameObject Visual;
    public FriendManager vfriendManage;
    public bool active=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vfriendManage.numberOfFish == 3)
        {
            Visual.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            active = true;
            Visual.SetActive(true);
        }
    }
}
