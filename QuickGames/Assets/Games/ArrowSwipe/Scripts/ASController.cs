using UnityEngine;
using UnityEngine.SceneManagement;
using static ASEnumerations;

public class ASController : MonoBehaviour
{
    Direction prevDirection = Direction.LEFT;
    public ASArrowScript arrowL;
    public ASArrowScript arrowR;
    public ASPadScript padL;
    public ASPadScript padR;
    public ASTimerBarScript timerBar;

    public ASScoreScript scoreScript;
    public GameObject reviveMenu;

    public float timeIntervalMax;
    public float timeIntervalMin;
    public int minIntervalScore;

    float timePassed;
    float timeInterval;

    bool revived;
    bool started;

    int prev;

    void Start()
    {
        prev = PlayerPrefs.GetInt("LeftHanded");

        if (prev == 0)
        {
            padR.gameObject.SetActive(true);
            padL.gameObject.SetActive(false);

            arrowR.gameObject.SetActive(false);
            arrowL.gameObject.SetActive(true);
        }
        else
        {
            padR.gameObject.SetActive(false);
            padL.gameObject.SetActive(true);

            arrowR.gameObject.SetActive(true);
            arrowL.gameObject.SetActive(false);
        }


        timePassed = 0;

        Direction temp = prevDirection;
        while (temp == prevDirection) temp = (Direction)Random.Range(0, 4);

        prevDirection = temp;
        GetArrow().setDirection(prevDirection);

        revived = false;
        started = false;
    }
    void Update()
    {
        if (prev != PlayerPrefs.GetInt("LeftHanded"))
        {
            prev = PlayerPrefs.GetInt("LeftHanded");

            if (prev == 0)
            {
                padR.gameObject.SetActive(true);
                padL.gameObject.SetActive(false);

                arrowR.gameObject.SetActive(false);
                arrowL.gameObject.SetActive(true);
            }
            else
            {
                padR.gameObject.SetActive(false);
                padL.gameObject.SetActive(true);

                arrowR.gameObject.SetActive(true);
                arrowL.gameObject.SetActive(false);
            }
        }

        if (Time.timeScale != 0f)
        {
            timeInterval = timeIntervalMax - (timeIntervalMax - timeIntervalMin) * ((float)scoreScript.score / (float)minIntervalScore);
            timerBar.SetFraction(1f - timePassed / timeInterval);

            if (started)
            {
                timePassed += Time.deltaTime;
                Direction padDirection = GetPad().GetLastSwipe();

                if (timePassed > timeInterval)
                {
                    GameOver();
                }
                else if (padDirection != Direction.NONE)
                {
                    if (padDirection == prevDirection)
                    {
                        scoreScript.addScore();
                        AudioManager.instance.Play("AcceptedSwipe");
                        timePassed = 0;

                        Direction temp = prevDirection;
                        while (temp == prevDirection) temp = (Direction)Random.Range(0, 4);

                        prevDirection = temp;
                        GetArrow().setDirection(prevDirection);
                    }
                    else
                    {
                        GameOver();
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                    started = true;
            }
        }
    }

    void GameOver()
    {
        timePassed = 0;

        Scores.setScore(scoreScript.score);
        if (!revived)
            reviveMenu.SetActive(true);
        else
            SceneManager.LoadScene("GameOver");
    }

    ASPadScript GetPad()
    {
        if (prev == 0)
            return padR;
        else
            return padL;
    }

    ASArrowScript GetArrow()
    {
        if (prev == 0)
            return arrowL;
        else
            return arrowR;
    }

    public void Revive()
    {
        revived = true;
        reviveMenu.SetActive(false);
        started = false;
    }
}
