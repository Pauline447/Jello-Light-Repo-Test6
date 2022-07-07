using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightUpArea : MonoBehaviour
{
    public Light2D[] lights;
    public float[] startTime;

    public float[] maxLuminosity; // max intensity

    public float luminositySteps = 0.001f; // factor when increasing / decreasing

    public bool startFade = false;
    public float timer = 0.0f;
    //public int NumberOfLights = 0;

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
            //if(NumberOfLights == 16)
            //{
                if (timer > startTime[0])
                {
                    StartCoroutine(ChangeIntensity(lights[0], maxLuminosity[0]));
                }
                if (timer > startTime[1])
                {
                    StartCoroutine(ChangeIntensity(lights[1], maxLuminosity[1]));
                }
                if (timer > startTime[2])
                {
                    StartCoroutine(ChangeIntensity(lights[2], maxLuminosity[2]));
                }
                if (timer > startTime[3])
                {
                    StartCoroutine(ChangeIntensity(lights[3], maxLuminosity[3]));
                }
                if (timer > startTime[4])
                {
                    StartCoroutine(ChangeIntensity(lights[4], maxLuminosity[4]));
                }
                if (timer > startTime[5])
                {
                    StartCoroutine(ChangeIntensity(lights[5], maxLuminosity[5]));
                }
                if (timer > startTime[6])
                {
                    StartCoroutine(ChangeIntensity(lights[6], maxLuminosity[6]));
                }
                if (timer > startTime[7])
                {
                    StartCoroutine(ChangeIntensity(lights[7], maxLuminosity[7]));
                }
                if (timer > startTime[8])
                {
                    StartCoroutine(ChangeIntensity(lights[8], maxLuminosity[8]));
                }
                if (timer > startTime[9])
                {
                    StartCoroutine(ChangeIntensity(lights[9], maxLuminosity[9]));
                }
                if (timer > startTime[10])
                {
                    StartCoroutine(ChangeIntensity(lights[10], maxLuminosity[10]));
                }
                if (timer > startTime[11])
                {
                    StartCoroutine(ChangeIntensity(lights[11], maxLuminosity[11]));
                }
                if (timer > startTime[12])
                {
                    StartCoroutine(ChangeIntensity(lights[12], maxLuminosity[12]));
                }
                if (timer > startTime[13])
                {
                    StartCoroutine(ChangeIntensity(lights[13], maxLuminosity[13]));
                }
                if (timer > startTime[14])
                {
                    StartCoroutine(ChangeIntensity(lights[14], maxLuminosity[14]));
                }
          //  }
                                        //for-Schleife nicht möglich, da das eine schon angefangen muss während das andere noch in der Coroutine is...
        }
    }

    private IEnumerator ChangeIntensity(Light2D l, float maxLumi)
    {
            while (l.intensity <= maxLumi)
            {
                l.intensity += luminositySteps; // increase the firefly intensity / fade in
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
