using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Animator animatorWorm;
    public Animator animatorIgel;
    public CheckForFriend Target1;
    public CheckForFriend Target2;
    public CheckForFriend Target3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Target1.friend1there || Target1.friend2there ||Target1.playerthere)
        {
            //animatorWorm.SetBool("FishAtTarget1", true);
            animatorWorm.SetBool("IsLit", true);
        }
        else if(!Target1.friend1there && !Target1.friend2there && !Target1.playerthere)
        {
           // animatorWorm.SetBool("FishAtTarget1", false);
            animatorWorm.SetBool("IsLit", false);
        }
        if (Target2.friend1there || Target2.friend2there || Target2.playerthere)
        {
           // animatorWorm.SetBool("FishAtTarget2", true);
            animatorWorm.SetBool("IsLit", true);
        }
        else if (!Target2.friend1there && !Target2.friend2there && !Target2.playerthere)
        {
            //animatorWorm.SetBool("FishAtTarget2", false);
            animatorWorm.SetBool("IsLit", false);
        }
        if ((Target1.friend1there || Target1.friend2there ||Target1.playerthere) && (Target2.friend1there || Target2.friend2there || Target2.playerthere)&& (Target3.friend1there || Target3.friend2there || Target3.playerthere))
        {
            //Destroy(gameObject);
           // animatorWorm.SetBool("FishAtTarget3", true);
            animatorIgel.SetBool("Snatch", true);

        }
    }
}
