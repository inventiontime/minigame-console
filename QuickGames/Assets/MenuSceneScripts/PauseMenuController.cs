using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public enum State { Pause, Options };
    public GameObject pauseScreen;
    public GameObject optionsScreen;

    void Start()
    {
        Time.timeScale = 0f;
        ChangeScreen(0);
    }

    public void ExitPauseMenu()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("PauseMenu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeScreen(int state)
    {
        switch((State)state)
        {
            case State.Pause:
                pauseScreen.SetActive(true);
                optionsScreen.SetActive(false);
                break;

            case State.Options:
                pauseScreen.SetActive(false);
                optionsScreen.SetActive(true);
                break;

            default:
                pauseScreen.SetActive(true);
                optionsScreen.SetActive(false);
                break;
        }
    }

}
