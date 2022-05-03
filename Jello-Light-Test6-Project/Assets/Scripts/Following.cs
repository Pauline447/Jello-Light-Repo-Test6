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
        Transform followTarget; //Player

    GameObject Target; //Player
    public bool facingRight = false;
    public float VampireSpeed = 2f;
    private Vector3 targetPos;
    private Vector3 thisPos;


    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player");
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
    }
    private void OnTriggerEnter2D(Collider2D other) //if Player goes over fish- following = true
    {
        if (other.tag == "Player")
        {
            isFollowing = true;
        }
    }

}
