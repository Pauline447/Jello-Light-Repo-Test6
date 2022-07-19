using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadNextSceneWithoutButton : MonoBehaviour
{
    public VideoPlayer _videoPlayer;
    private bool isPlaying = true;
    public int nextScene;

    private bool waited;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
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
           SceneManager.LoadScene(nextScene);
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        waited = true;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(nextScene);
    }
}
