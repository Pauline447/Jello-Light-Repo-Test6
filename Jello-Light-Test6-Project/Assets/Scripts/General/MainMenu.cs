using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator loading;
    // Start is called before the first frame update
    public void PlayGame(int sceneIndex)
    {
        StartCoroutine(LoadAsynchonly(sceneIndex));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadAsynchonly(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone)
        {

            yield return null;
        }
    }
}
