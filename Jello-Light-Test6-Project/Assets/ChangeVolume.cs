using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChangeVolume : MonoBehaviour
{
    public bool changeBloom = false;
    public float bloomValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var volume = gameObject.GetComponent<Volume>();
        if(changeBloom)
        {
            if (volume.profile.TryGet<Bloom>(out var bloom))
            {
                var t = 0.0f;
                   t += Time.deltaTime;
                bloom.intensity.overrideState = true;
                bloom.intensity.value = bloomValue;
            }
        }
    }
}
