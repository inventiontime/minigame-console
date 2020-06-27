using System;
using UnityEngine;
using UnityEngine.Events;

// Handles input based on inputLayout set in GameManager
public class CSInputScript : MonoBehaviour
{
    public CSGameManager gameManager;

    [Serializable]
    public class ButtonClickedEvent : UnityEvent { }

    [SerializeField]
    private ButtonClickedEvent OnPressRed = new ButtonClickedEvent();
    [SerializeField]
    private ButtonClickedEvent OnPressBlue = new ButtonClickedEvent();
    [SerializeField]
    private ButtonClickedEvent OnPressYellow = new ButtonClickedEvent();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            OnPressRed.Invoke();
        else if (Input.GetKeyDown(KeyCode.W))
            OnPressBlue.Invoke();
        else if (Input.GetKeyDown(KeyCode.E))
            OnPressYellow.Invoke();

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            OnPressRed.Invoke();
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            OnPressBlue.Invoke();
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            OnPressYellow.Invoke();
    }
}

