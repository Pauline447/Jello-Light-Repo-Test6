using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChangeVolume : MonoBehaviour
{
    private bool changeBloom = false;
    public float bloomValue = 0f;
    public float vigValue = 0f;
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
            if (volume.profile.TryGet<Vignette>(out var vig))
            {
                var t = 0.0f;
                t += Time.deltaTime;
                vig.intensity.overrideState = true;
                vig.intensity.value = vigValue;
            }
        }
        else if (!changeBloom)
        {
            if (volume.profile.TryGet<Bloom>(out var bloom))
            {
                var t = 0.0f;
                t += Time.deltaTime;
                bloom.intensity.overrideState = true;
                bloom.intensity.value = 0.3f;
            }
            if (volume.profile.TryGet<Vignette>(out var vig))
            {
                var t = 0.0f;
                t += Time.deltaTime;
                vig.intensity.overrideState = true;
                vig.intensity.value = 0.309f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if( other.tag == "Player")
        changeBloom = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            changeBloom = false;
    }
}
