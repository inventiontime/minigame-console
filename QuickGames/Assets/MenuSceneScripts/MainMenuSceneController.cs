using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Scene controller for MainMenu scene
public class MainMenuSceneController : MonoBehaviour
{
    public int pageNo = 0;
    public TextMeshProUGUI gameTitle;
    public TextMeshProUGUI scoreText;

    public GameObject tutorialButton;
    public GameObject playButton;

    private void Start()
    {
        SetText();
    }

    // Moves to next pag
    public void NextPage()
    {
        pageNo++;

        if (pageNo >= Games.noOfGames)
            pageNo = Games.noOfGames - 1;

        SetText();
    }

    // Moves to previous page
    public void PrevPage()
    {
        pageNo--;

        if (pageNo < 0)
            pageNo = 0;

        SetText();
    }

    // Set text
    public void SetText()
    {
        gameTitle.text = ((Games.GamesEnum)pageNo).ToString().ToUpper();

        if(Games.isCompleted[pageNo])
            scoreText.text = "BEST: " + PlayerPrefs.GetInt("BestScore" + ((Games.GamesEnum)pageNo).ToString()).ToString();
        else
            scoreText.text = "COMING SOON";

        tutorialButton.SetActive(PlayerPrefs.GetInt(((Games.GamesEnum)pageNo).ToString() + "Tutorial") != 0 && Games.isCompleted[pageNo]);

        playButton.GetComponent<SoundButtonScript>().interactable = Games.isCompleted[pageNo];
    }

    // Changes to game scene
    public void Play()
    {
        Games.currentGame = (Games.GamesEnum)pageNo;

        if (PlayerPrefs.GetInt(Games.currentGame.ToString() + "Tutorial") == 0 && Games.isTutorial[pageNo] == true)
            SceneManager.LoadScene(Games.currentGame.ToString() + "Tutorial");
        else
            SceneManager.LoadScene(Games.currentGame.ToString());
    }

    // Changes to tutorial scene
    public void Tutorial()
    {
        Games.currentGame = (Games.GamesEnum)pageNo;
        SceneManager.LoadScene(Games.currentGame.ToString() + "Tutorial");
    }
}
