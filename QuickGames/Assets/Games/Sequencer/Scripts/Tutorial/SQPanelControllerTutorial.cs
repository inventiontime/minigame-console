using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Script for managing group of buttons
public class SQPanelControllerTutorial : MonoBehaviour
{
    // References to other objects
    public Animator tapIndicator;
    public SQButtonScript[] buttons;
    public SQScoreScript scoreScript;
    public TutorialStatusController status;
    public TextMeshProUGUI text;

    // Used when showing sequence
    public float onTime;
    public float offTime;

    // Used when showing confirmation dot
    public GameObject tick;
    public float tickTime;

    // Used in making sequence
    List<int> sequence = new List<int>();

    int pageNo = 0;
    bool update = true;
    int nextIndex = 0;

    // Updates things going on on the screen if update == true
    void Update()
    {
        if (update)
        {
            switch (pageNo)
            {
                case 0:
                    sequence = new List<int>();
                    sequence.Add(1);
                    StartCoroutine(ShowSequence());
                    break;

                case 1:
                    tapIndicator.transform.position = buttons[1].transform.position;
                    StartCoroutine(ShowIndicator(pageNo));
                    text.text = "TAP THE BUTTONS IN THE SAME SEQUENCE THAT THEY FLASH";
                    break;

                case 2:
                    scoreScript.addScore();
                    sequence.Add(0);
                    StartCoroutine(ShowSequence());
                    break;

                case 3:
                    tapIndicator.transform.position = buttons[1].transform.position;
                    StartCoroutine(ShowIndicator(pageNo));
                    break;

                case 4:
                    tapIndicator.transform.position = buttons[0].transform.position;
                    StartCoroutine(ShowIndicator(pageNo));
                    break;

                case 5:
                    scoreScript.addScore();
                    sequence.Add(3);
                    StartCoroutine(ShowSequence());
                    text.text = "NOW TRY IT FOR YOURSELF";
                    break;

                case 9:
                    status.Complete();
                    break;

                default:
                    break;
            }

            update = false;
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
        pageNo++;
        update = true;
    }

    // A Coroutine for showing tap indicator
    IEnumerator ShowIndicator(int pageNo)
    {
        while (this.pageNo == pageNo)
        {
            tapIndicator.SetTrigger("Play");
            yield return new WaitForSeconds(2f);
        }
    }

    // Func is called when button is pressed
    public void ButtonPressed(int buttonIndex)
    {
        if (buttonIndex == sequence[nextIndex])
        {
            nextIndex++;
            pageNo++;
            update = true;
            if (nextIndex == sequence.Count)
            {
                nextIndex = 0;
            }
        }
        else
        {
            status.Restart();
        }
    }
}