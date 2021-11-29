using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void Menu() {
        SceneManager.LoadScene("StartScene");
    }

    public void Play() {
        SceneManager.LoadScene("GameScene");
    }

    public void Shop() {
        SceneManager.LoadScene("ShopScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
