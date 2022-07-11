using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class LightUpSingleCoral : MonoBehaviour
{

    public Light2D coralLight;

    public float maxLuminosity; // max intensity

    public float luminositySteps = 0.001f; // factor when increasing / decreasing

    public bool startFade = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startFade)
        {
            StartCoroutine(ChangeIntensity(coralLight, maxLuminosity));
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
}
