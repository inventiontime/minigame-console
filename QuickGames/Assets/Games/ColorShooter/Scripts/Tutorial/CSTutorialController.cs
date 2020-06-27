using System.Collections;
using TMPro;
using UnityEngine;

public class CSTutorialController : MonoBehaviour
{
    int pageNo = 0;
    bool update = true;
    int scorePrevious = 0;
    public static bool restart = false;

    public TextMeshProUGUI text;
    public TutorialStatusController statusController;
    public GameObject tapIndicator;

    public GameObject redEnemyPrefab;
    public GameObject blueEnemyPrefab;
    public GameObject yellowEnemyPrefab;

    public GameObject greenEnemyPrefab;
    public GameObject orangeEnemyPrefab;
    public GameObject purpleEnemyPrefab;

    public GameObject redButton;
    public GameObject blueButton;
    public GameObject yellowButton;

    public GameObject spawnPoint;

    public CSGameManager gameManager;

    private void Start()
    {
        gameManager.EnemySpeed = 4;
    }

    private void Update()
    {
        if (update)
        {
            switch (pageNo)
            {
                case 0:
                    Instantiate(redEnemyPrefab, spawnPoint.transform);
                    tapIndicator.transform.position = redButton.transform.position;
                    StartCoroutine(ShowIndicator(pageNo));
                    text.text = "BULLETS DESTROY ENEMIES OF THE SAME COLOR";
                    break;

                case 1:
                    Instantiate(blueEnemyPrefab, spawnPoint.transform);
                    tapIndicator.transform.position = blueButton.transform.position;
                    StartCoroutine(ShowIndicator(pageNo));
                    text.text = "BULLETS DESTROY ENEMIES OF THE SAME COLOR";
                    break;

                case 2:
                    Instantiate(yellowEnemyPrefab, spawnPoint.transform);
                    text.text = "NOW TRY IT FOR YOURSELF";
                    break;

                case 3:
                    Instantiate(orangeEnemyPrefab, spawnPoint.transform);
                    tapIndicator.transform.position = redButton.transform.position;
                    StartCoroutine(ShowIndicator(pageNo));
                    text.text = "RED + YELLOW = ORANGE";
                    break;

                case 4:
                    tapIndicator.transform.position = yellowButton.transform.position;
                    StartCoroutine(ShowIndicator(pageNo));
                    text.text = "RED + YELLOW = ORANGE";
                    break;

                case 5:
                    Instantiate(purpleEnemyPrefab, spawnPoint.transform);
                    tapIndicator.transform.position = redButton.transform.position;
                    StartCoroutine(ShowIndicator(pageNo));
                    text.text = "RED + BLUE = PURPLE";
                    break;

                case 6:
                    tapIndicator.transform.position = blueButton.transform.position;
                    StartCoroutine(ShowIndicator(pageNo));
                    text.text = "RED + BLUE = PURPLE";
                    break;

                case 7:
                    Instantiate(greenEnemyPrefab, spawnPoint.transform);
                    tapIndicator.transform.position = blueButton.transform.position;
                    StartCoroutine(ShowIndicator(pageNo));
                    text.text = "BLUE + YELLOW = GREEN";
                    break;

                case 8:
                    tapIndicator.transform.position = yellowButton.transform.position;
                    StartCoroutine(ShowIndicator(pageNo));
                    text.text = "BLUE + YELLOW = GREEN";
                    break;

                case 9:
                    statusController.Complete();
                    break;

                default:
                    break;
            }
            update = false;
        }

        if(scorePrevious < gameManager.score)
        {
            scorePrevious = gameManager.score;
            pageNo++;
            update = true;
        }

        if(restart)
        {
            statusController.Restart();
            restart = false;
        }
    }

    // A Coroutine for showing tap indicator
    IEnumerator ShowIndicator(int pageNo)
    {
        while (this.pageNo == pageNo)
        {
            tapIndicator.GetComponent<Animator>().SetTrigger("Play");
            yield return new WaitForSeconds(2f);
        }
    }

    public static void Restart()
    {
        restart = true;
    }
}
