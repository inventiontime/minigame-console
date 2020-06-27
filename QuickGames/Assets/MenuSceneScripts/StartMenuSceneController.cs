using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scene controller for StartMenu scene
public class StartMenuSceneController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Start()
    {
        AudioManager.instance.Play("Background");
        if(PlayerPrefs.GetInt("bugfix1") == 0)
        {
            PlayerPrefs.SetInt("BestScoreColorShooter", 0);
            PlayerPrefs.SetInt("bugfix1", 1);
        }
    }
}
