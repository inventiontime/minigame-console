using UnityEngine;
using UnityEngine.SceneManagement;

// Reset GameManager vars
public class CSReset : MonoBehaviour
{
    public CSGameManager gameManager;

    void Awake()
    {
        if (!gameManager.revived)
        {
            gameManager.score = 0;
        }

        if (!SceneManager.GetActiveScene().name.EndsWith("Tutorial") && PlayerPrefs.GetInt("HandOptionDone") == 0)
        {
            SceneManager.LoadScene("HandOptionScene");
        }
    }
}
