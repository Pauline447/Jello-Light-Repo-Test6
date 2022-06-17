using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWormToKick : MonoBehaviour
{
    public Animator anim2;
    public Animator anim;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            anim.SetBool("Kicked", true);
            anim2.SetBool("IsLit", true);
        }
    }
}
