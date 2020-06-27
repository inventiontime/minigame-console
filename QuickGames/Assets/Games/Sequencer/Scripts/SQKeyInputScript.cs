using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SQKeyInputScript : MonoBehaviour
{
    [Serializable]
    public class ButtonClickedEvent : UnityEvent { }

    [SerializeField]
    private ButtonClickedEvent OnPress1 = new ButtonClickedEvent();
    [SerializeField]
    private ButtonClickedEvent OnPress2 = new ButtonClickedEvent();
    [SerializeField]
    private ButtonClickedEvent OnPress3 = new ButtonClickedEvent();
    [SerializeField]
    private ButtonClickedEvent OnPress4 = new ButtonClickedEvent();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            OnPress1.Invoke();
        else if (Input.GetKeyDown(KeyCode.W))
            OnPress2.Invoke();
        else if (Input.GetKeyDown(KeyCode.E))
            OnPress3.Invoke();
        else if (Input.GetKeyDown(KeyCode.R))
            OnPress4.Invoke();
    }
}
