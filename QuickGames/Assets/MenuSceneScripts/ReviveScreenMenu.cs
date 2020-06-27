using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviveScreenMenu : MonoBehaviour
{
    private void OnEnable()
    {
        #if UNITY_ANDROID
        Time.timeScale = 0f;
        #else
        noRevival();
        #endif
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void noRevival()
    {
        SceneManager.LoadScene("GameOver");
    }
}
