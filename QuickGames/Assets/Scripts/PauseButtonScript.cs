using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonScript : MonoBehaviour
{
    public void showPauseMenu()
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }
}
