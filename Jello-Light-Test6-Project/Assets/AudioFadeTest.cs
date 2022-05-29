using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeTest : MonoBehaviour
{
    public Camera MainCamra;
    private AudioSource track;
    // Start is called before the first frame update
    void Start()
    {
        track = MainCamra.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(StartFade(track,3f,0f));
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
