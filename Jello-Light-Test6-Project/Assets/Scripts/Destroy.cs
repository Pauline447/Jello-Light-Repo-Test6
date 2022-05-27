using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Animator animatorWorm;
    public Animator animatorIgel;
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
            animatorWorm.SetBool("FishAtTarget1", true); 
        }
        else if(!Target1.friend1there && !Target2.friend2there)
        {
            animatorWorm.SetBool("FishAtTarget1", false);
        }
        if ((Target1.friend1there || Target1.friend2there) && (Target2.friend1there||Target2.friend2there))
        {
            //Destroy(gameObject);
            animatorWorm.SetBool("FishAtTarget2", true);
            animatorIgel.SetBool("Snatch", true);

        }
    }
}
