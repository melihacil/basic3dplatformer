using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);  
    }
    public void ExitApp()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }



    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / 9);
            Debug.Log(progress);
            yield return null;
        }

    }
}
