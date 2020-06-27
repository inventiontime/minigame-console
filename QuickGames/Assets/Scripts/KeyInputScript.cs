using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyInputScript : MonoBehaviour
{

    [Serializable]
    public class ButtonClickedEvent : UnityEvent { }

    [SerializeField]
    private ButtonClickedEvent OnPressEnter = new ButtonClickedEvent();
    [SerializeField]
    private ButtonClickedEvent OnPressLeft = new ButtonClickedEvent();
    [SerializeField]
    private ButtonClickedEvent OnPressRight = new ButtonClickedEvent();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            OnPressLeft.Invoke();
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            OnPressEnter.Invoke();
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            OnPressRight.Invoke();
    }
}
