using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightUpTentacel : MonoBehaviour
{
    public GameObject[] _particles;
    public bool startFade = false;
    public int TentacelCase;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (startFade)
        {
            switch(TentacelCase)
            {
                case 0:
                    _particles[0].SetActive(true);
                    break;
                case 1:
                   _particles[1].SetActive(true);
                    break;
                case 2:
                    _particles[2].SetActive(true);
                    break;
            }
        }
    }
}
