using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
    private float timeDuration = 1f;
    public float timer;
    private bool startTimer = false;

    public GameObject player;
    public GameObject playerLight;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer && timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            startTimer = true;
            StartCoroutine(FlackernPlayerLight());
        }
    }
    private void ResetTimer()
    {
        timer = timeDuration;
    }
    private IEnumerator FlackernPlayerLight()
    {
        while (timer > 0)
        {
            playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius = 1f;
            playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 4.5f;
            yield return new WaitForSeconds(0.2f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
            playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius = 1.5f;
            playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 9;
            yield return new WaitForSeconds(0.2f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
        }
    }
}
