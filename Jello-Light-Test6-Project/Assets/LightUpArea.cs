using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightUpArea : MonoBehaviour
{
    public Light2D[] lights;
    public float[] startTime;

    public float[] maxLuminosity; // max intensity

    private float luminositySteps = 0.001f; // factor when increasing / decreasing

    public bool startFade = false;
    public float timer = 0.0f;
    public int NumberOfLights = 0;

    private void Start()
    {
       // pointLight = GetComponent<Light>();
        //pointLight.intensity = Random.Range(minLuminosity, maxLuminosity); // start with a random intensity
        //StartCoroutine(ChangeIntensity()); // start the process
    }
    private void Update()
    {
        if (startFade)
        { 
            timer += Time.deltaTime;
            if(NumberOfLights == 2)
            {
                if (timer > startTime[0])
                {
                    StartCoroutine(ChangeIntensity(lights[0], maxLuminosity[0]));
                }
                if (timer > startTime[1])
                {
                    StartCoroutine(ChangeIntensity(lights[1], maxLuminosity[1]));
                }
            }
                                        //for-Schleife nicht möglich, da das eine schon angefangen muss während das andere noch in der Coroutine is...
        }
    }

    private IEnumerator ChangeIntensity(Light2D l, float maxLumi)
    {
            while (l.intensity <= maxLumi)
            {
                l.intensity += luminositySteps / 10; // increase the firefly intensity / fade in
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(0f); // wait 3 seconds
    }

    //function FadeLight(l: Light, fadeStart: float, fadeEnd: float, fadeTime: float)
    //{
    //    var t = 0.0;

    //    while (t < fadeTime)
    //    {
    //        t += Time.deltaTime;

    //        l.intensity = Mathf.Lerp(fadeStart, fadeEnd, t / fadeTime);
    //        yield;
    //    }
    //}
}
