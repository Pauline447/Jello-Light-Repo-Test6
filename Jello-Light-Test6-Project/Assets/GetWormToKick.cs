using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWormToKick : MonoBehaviour
{
    public Animator anim2;
    public GameObject worm;
    public Transform target;
    public float positionX;
    public PlayerMovementNew player;

    public float followSpeed = 3f;
    public Animator anim;

    public bool stopFollowing = false;
    // Start is called before the first frame update

    private void Update()
    {
        if(stopFollowing)
        {
            worm.transform.position = Vector3.Lerp(worm.transform.position, target.position, followSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //worm.transform.position = Vector3.Lerp(worm.transform.position, target.position, followSpeed * Time.deltaTime);
            stopFollowing = true;
            anim.SetBool("Kicked", true);
            anim2.SetBool("IsLit", true);
            player.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //worm.transform.position = Vector3.Lerp(worm.transform.position, target.position, followSpeed * Time.deltaTime);
            stopFollowing = true;
            //anim.SetBool("Kicked", true);
            anim2.SetBool("IsLit", false);
            Destroy(this);
        }
    }
}
