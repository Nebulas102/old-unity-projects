using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void StartScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    public void Options()
    {
        SceneManager.LoadScene(1);
    }

    public void Shop()
    {
        SceneManager.LoadScene(2);
    }
    

    public void Quit()
    {
        Application.Quit();
    }

}
