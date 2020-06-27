using UnityEngine;
using UnityEngine.SceneManagement;

public class HandOptionSceneScript : MonoBehaviour
{
    public void ChangeToRightHanded()
    {
        PlayerPrefs.SetInt("LeftHanded", 0);
        PlayerPrefs.SetInt("HandOptionDone", 1);
        SceneManager.LoadScene("ColorShooter");
    }

    public void ChangeToLeftHanded()
    {
        PlayerPrefs.SetInt("LeftHanded", 1);
        PlayerPrefs.SetInt("HandOptionDone", 1);
        SceneManager.LoadScene("ColorShooter");
    }
}
