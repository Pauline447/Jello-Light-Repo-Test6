using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFollowWormActiveAgain : MonoBehaviour
{
    public WormFollowsPlayer _wormFollowsPlayer;
    public WormAnimationController _WormAnimationController;
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
        if(other.tag == "Player" && !_WormAnimationController.wormThere)
        {
            _wormFollowsPlayer.followingAllowed = true;
        }
    }
}
