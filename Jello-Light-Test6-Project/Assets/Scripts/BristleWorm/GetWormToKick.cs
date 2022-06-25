using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GetWormToKick : MonoBehaviour
{
    public Animator anim2;
    public GameObject worm;
    public Transform target;
   // public Transform playerTarget;
    public float positionX;
    public PlayerMovementNew player;
    public WormFollowsPlayer wormFollows;
    public GameObject playerObject;
    public CinemachineVirtualCamera vCam;

    public float followSpeed = 3f;
    public Animator anim;

    private Transform pos;
    public Transform igel;

    public bool stopFollowing = false;

    public bool wormkick = false;
    // Start is called before the first frame update

    private void Update()
    {
        if (stopFollowing)
        {
            worm.transform.position = Vector3.Lerp(worm.transform.position, target.position, followSpeed * Time.deltaTime);
            vCam.Follow = igel;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            wormkick = true;
            wormFollows.enabled = false;
            // wormFollows.chageWormPosition = false;
            anim2.SetBool("lightThere", true);
            anim.SetBool("Kicked", true);
            stopFollowing = true;   
            playerObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            pos = player.transform;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(pos.position.x * 0, pos.position.y * 0);
            player.GetComponent<PlayerMovementNew>().enabled = false;
            StartCoroutine(DeleteThis());

        }
    }

    private IEnumerator DeleteThis()
    {
        yield return new WaitForSeconds(0.5f);
       anim2.SetBool("lightThere", false);
        yield return new WaitForSeconds(5f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
        wormkick = false;
        wormFollows.enabled = true;
       // wormFollows.chageWormPosition = true;
        vCam.Follow = playerObject.transform;
        player.enabled = true;
        Destroy(this);
    }

}
