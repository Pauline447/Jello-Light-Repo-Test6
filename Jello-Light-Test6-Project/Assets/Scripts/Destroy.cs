using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Animator animator;
    public CheckForFriend Target1;
    public CheckForFriend Target2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Target1.friend1there || Target1.friend2there)
        {
            animator.SetBool("FishAtTarget1", true); 
        }
        else if(!Target1.friend1there && !Target2.friend2there)
        {
            animator.SetBool("FishAtTarget1", false);
        }
        if ((Target1.friend1there || Target1.friend2there) && (Target2.friend1there||Target2.friend2there))
        {
            Destroy(gameObject);
            animator.SetBool("FishAtTarget2", true);
        }
    }
}
