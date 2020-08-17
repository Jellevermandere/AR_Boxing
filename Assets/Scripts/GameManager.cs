using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //********************* GameMode *********************

    // 0 == search state 1 == play state
    [Tooltip("0 == search state 1 == play state")]
    public static int GameMode = 0;




    //********************* ScoreManagement *********************

    public static float HighScore = Mathf.Infinity;
    public static float currentTime;
    
    public static float CurrentScore;

    public static void IncreaseScore(float amount)
    {
        CurrentScore += amount;

        if(CurrentScore >= 15)
        {
            if (currentTime < HighScore) HighScore = currentTime;
            LoadEndLevel(SceneManager.sceneCountInBuildSettings -1);
        }
    }
    public static void ResetScore()
    {
        CurrentScore = 0f;
    }

    static void LoadEndLevel(int levelNr)
    {
        SceneManager.LoadScene(levelNr);
    }

    //********************* SceneManagement *********************

    public void EndGame(float delay, bool loadNextLevel)
    {
        if (loadNextLevel) Invoke("LoadNextLevel", delay);
        else Invoke("LoadEndScene", delay);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel(int levelNr)
    {
        SceneManager.LoadScene(levelNr);
    }

    public void LoadLevelName(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void PauzeGame()
    {
        Time.timeScale = 0f;
    }

    public void UnpauzeGame()
    {
        Time.timeScale = 1f;
    }
}
