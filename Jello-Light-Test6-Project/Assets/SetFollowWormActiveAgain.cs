using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFollowWormActiveAgain : MonoBehaviour
{
    public WormFollowsPlayer _wormFollowsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            _wormFollowsPlayer.followingAllowed = true;
        }
    }
}
