using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public VideoPlayer _videoPlayer;
    private bool isPlaying = true;

    private bool waited;
    private float loadprogress;

    private bool skipable= false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (_videoPlayer.isPlaying)
        {
            isPlaying = true;
        }
        else if (waited)
        {
            isPlaying = false;
        }
        if (!isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        if (SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1).isDone)
        {
            skipable = true;
        }
        if(skipable)
        {
            //activate Button
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        waited = true;
    }
}
