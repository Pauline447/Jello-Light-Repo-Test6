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
    public GameObject SkipButton;
    AsyncOperation loadingOperation;

    public bool isOutro;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
        if (isOutro)
        {
         loadingOperation= SceneManager.LoadSceneAsync(1); 
        }
        else if(!isOutro)
        {
            loadingOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
      
        loadingOperation.allowSceneActivation = false;
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
            if(!isOutro)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else if(isOutro)
                SceneManager.LoadScene(0);
        }

        //loadingOperation.allowSceneActivation = true;

        if (loadingOperation.progress < 0.9f)
        {
                skipable = true;
        }
        if(skipable)
        {
            //activate Button
            SkipButton.SetActive(true);
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        waited = true;
    }
    public void PlayGame()
    {
        loadingOperation.allowSceneActivation = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
