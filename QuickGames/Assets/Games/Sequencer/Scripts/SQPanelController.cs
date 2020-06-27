using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for managing group of buttons
public class SQPanelController : MonoBehaviour
{
    // References to other objects
    public SQButtonScript[] buttons;
    public SQScoreScript scoreScript;

    public GameObject reviveMenu;

    // Used when showing sequence
    public float onTime;
    public float offTime;

    // Used when showing confirmation dot
    public GameObject tick;
    public float tickTime;

    // Used in making sequence
    List<int> sequence = new List<int>();
    int nextIndex = 0;

    bool revived = false;

    enum GameState { Player, Show, Showing, Tick };
    GameState gameState = GameState.Show;

    float remainingTime;

    // Handles (showing the dot when user entered sequence is correct) && (adding to sequence)
    void Update()
    {
        if (gameState == GameState.Show)
        {
            AddToSequence();
            StartCoroutine(ShowSequence());
            gameState = GameState.Showing;
        }
        else if (gameState == GameState.Tick)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                gameState = GameState.Show;
                tick.SetActive(false);
            }
        }
    }

    // A Coroutine for showing the sequence
    IEnumerator ShowSequence()
    {
        for (int i = 0; i < sequence.Count; i++)
        {
            yield return new WaitForSeconds(offTime);
            buttons[sequence[i]].SetState(true);
            AudioManager.instance.Play("Sequencer" + (sequence[i] + 1).ToString());
            yield return new WaitForSeconds(onTime);
            buttons[sequence[i]].SetState(false);
        }
        gameState = GameState.Player;
    }

    // Revive the player
    public void Revive()
    {
        StartCoroutine(ShowSequence());
        nextIndex = 0;
        gameState = GameState.Showing;
        reviveMenu.SetActive(false);

        revived = true;
    }

    // Adds a random buttonIndex to sequence (after checking if the index different from previous)
    void AddToSequence()
    {
        int temp;
        temp = Random.Range(0, buttons.Length);
        if (sequence.Count > 0) { while (temp == sequence[sequence.Count - 1]) { temp = Random.Range(0, buttons.Length); } }
        sequence.Add(temp);
    }

    // Func is called when button is pressed
    public void ButtonPressed(int buttonIndex)
    {
        if (gameState == GameState.Player)
        {
            if (buttonIndex == sequence[nextIndex])
            {
                nextIndex++;
                if (nextIndex == sequence.Count)
                {
                    nextIndex = 0;

                    gameState = GameState.Tick;
                    scoreScript.addScore();
                    tick.SetActive(true);
                    remainingTime = tickTime;
                }
            }
            else
            {
                Scores.setScore(scoreScript.score);
                if(!revived)
                    reviveMenu.SetActive(true);
                else
                    SceneManager.LoadScene("GameOver");
            }
        }
    }
}
