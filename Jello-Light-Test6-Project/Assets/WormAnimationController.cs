using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAnimationController : MonoBehaviour
{
    public Animator anim;
    public CheckForFriend[] _checkForFriend;
    public int numberOfChecks;
    public bool wormThere = false;
    public GetWormToKick _getWormToKick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<numberOfChecks; i++)
        {
            if (((_checkForFriend[i].friend1there || _checkForFriend[i].friend2there || _checkForFriend[i].friend3there || _checkForFriend[i].playerthere) && wormThere) || _getWormToKick.wormkick)
            {
                anim.SetBool("lightThere", true);
            }
            else
            {
                anim.SetBool("lightThere", false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Worm")
        {
            wormThere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Worm")
        {
            wormThere = false;
        }
    }
}
