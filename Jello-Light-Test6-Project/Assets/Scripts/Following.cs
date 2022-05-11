using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    public
        bool isFollowing = false;
    public
        float followSpeed = 3f;
    public
        Transform followTarget; //Empty

    public GameObject Target; //Player
    private bool facingRight = false;

    public bool doneonce=false;

    public bool hugged = false;
    public bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime); //actual following

        }
        if (Target.transform.position.x < gameObject.transform.position.x && facingRight)
        { //gameobject.transform.position = fish
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
            facingRight = false;
        }

        if (Target.transform.position.x > gameObject.transform.position.x && !facingRight)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
            facingRight = true;
        }

        if (hugged)
        {
            isFollowing = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }
    public void SetDoneOnce()
    {
        doneonce = true;
    }

    public void SetHugged()
    {
        hugged = true;
    }
}
