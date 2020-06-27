using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialStatusController : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI text;

    // Restarts tutorial
    public void Restart()
    {
        StartCoroutine(RestartCoroutine());
    }

    IEnumerator RestartCoroutine()
    {
        text.text = "RESTARTING TUTORIAL...";
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(Games.currentGame.ToString() + "Tutorial");
    }

    // Completes tutorial
    public void Complete()
    {
        StartCoroutine(CompleteCoroutine());
    }

    IEnumerator CompleteCoroutine()
    {
        text.text = "TUTORIAL COMPLETE";
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt(Games.currentGame.ToString() + "Tutorial", 1);
        SceneManager.LoadScene(Games.currentGame.ToString());
    }
}
