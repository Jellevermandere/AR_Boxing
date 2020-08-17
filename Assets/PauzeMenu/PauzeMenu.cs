using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauzeMenu : MonoBehaviour
{
    public void PauzeGame()
    {
        Time.timeScale = 0f;
    }

    public void UnpauzeGame()
    {
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
