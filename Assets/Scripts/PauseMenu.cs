using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GamePaused = false;

    public GameObject pauseMenu;

    int sceneIndex;
    // Update is called once per frame

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
       

    }
    /*
    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void PauseGame()
    {
        if(GamePaused)
            {
            Resume();
        }
            else
        {
            Pause();
        }
    }
    */

    public void ResetGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.DeleteKey("score");
        ScoreManager.Score = 0;
        Debug.Log("Game reset.");
        Debug.Log(PlayerPrefs.GetInt("score"));
    }

    public void BackToMenu()
    {
        Debug.Log("Back to Menu ");
        PlayerPrefs.DeleteKey("score");
        ScoreManager.Score = 0;
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(2);
    }
}

