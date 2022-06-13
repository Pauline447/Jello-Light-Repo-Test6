using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUI : MonoBehaviour
{
    public PlayerMovementNew player;
    public GameObject _DashUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.dashUIDashDone)
        {
            Destroy(_DashUI);
        }
    }
}
