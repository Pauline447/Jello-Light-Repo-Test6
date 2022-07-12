using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequenzScript : MonoBehaviour
{
    //dunkel zu hell - kleine Fisch pfad man kann den einsammeln, player color = 255 und umgebungslichter(Light 2D und Light 2D (1)) aus bis fisch umarmt
    void Start()
    {
        StartCoroutine(StartIntro());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator StartIntro()
    {
        //Player dektiviren, leicht aufschimmern lassen
        //Kleinen Freund auf Pfad schicken
        //Kamera zoom in
        //Player aktivieren
        // if hug - UI gets activated, light gets turned up
        yield return new WaitForSeconds(0f);
    }
}
