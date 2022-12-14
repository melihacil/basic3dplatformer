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
    private void Start()
    {
        FindObjectOfType<SoundManager>().PlaySound("MainMenu");
    }
    public void ExitApp()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void LoadTestLevel()
    {
        SceneManager.LoadScene(4);
    }

}
