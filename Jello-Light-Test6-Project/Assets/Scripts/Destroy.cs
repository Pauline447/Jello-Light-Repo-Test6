using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public CheckForFriend Target1;
    public CheckForFriend Target2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target1.friendthere && Target2.friendthere)
        {
            Destroy(gameObject);
        }
    }
}
