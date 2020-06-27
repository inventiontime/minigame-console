using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scene controller for GameOver scene
public class GameOverSceneController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject tapToContObject;

    float time;

    // Sets score texts
    void Start()
    {
        scoreText.text = Scores.getScore().ToString();
        bestScoreText.text = Scores.getBestScore().ToString();
        tapToContObject.SetActive(false);
    }

    // Loads MainMenu on press
    void Update()
    {
        if (time < 1f)
        {
            time += Time.deltaTime;
        }
        else
        {
            tapToContObject.SetActive(true);
            if (Input.GetMouseButtonUp(0))
            {
                Next();
            }
        }
    }

    public void Next()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
