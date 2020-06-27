using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SQTutorialStatusController : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI text;

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

    public void Complete()
    {
        StartCoroutine(CompleteCoroutine());
    }

    IEnumerator CompleteCoroutine()
    {
        text.text = "TUTORIAL COMPLETE";
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(Games.currentGame.ToString());
    }
}
