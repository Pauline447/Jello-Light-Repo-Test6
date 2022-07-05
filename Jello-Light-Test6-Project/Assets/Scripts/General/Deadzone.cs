using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private float timeDuration = 8f;
    public float timer;
    private bool startTimer = false;

    public GameObject player;
    private Transform pos;
    public GameObject playerLight;
    public Camera main;
    private AudioSource track;

    // Start is called before the first frame update
    void Start()
    {
        track = main.GetComponent<AudioSource>();
        ResetTimer();   
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer && timer >0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer < 0)
        {
            Death();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            startTimer = true;
            player.GetComponent<PlayerMovementScript>().defaultDashSpeed = 3f;
            StartCoroutine(FlackernPlayerLight());
            StartCoroutine(StartFade(track, 3f, 0f));
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            startTimer = false;
            ResetTimer();
        }
    }
    private void ResetTimer()
    {
        timer = timeDuration;
    }
    private void Death()
    {
        //zoom in
        //Player Animation --> Attack by sea monster
        //Player Movement ausschalten
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = false;
        pos = player.transform;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2 (pos.position.x*0, pos.position.y*0);
        player.GetComponent<PlayerMovementScript>().enabled = false;
        player.GetComponent<Animator>().SetBool("SchokoHai", true);
      //  Debug.Log("U dead");
    }
    private IEnumerator FlackernPlayerLight()
    {
        while (timer>0)
        {
            playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius = 2.5f;
            playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 4.5f;
            yield return new WaitForSeconds(1f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
            playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerRadius = 1.2f;
            playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 3.5f;
            yield return new WaitForSeconds(1f); //Nach einer Halben Sekunde wird der Code von hier aus weiter ausgeführt
        }
    }
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
