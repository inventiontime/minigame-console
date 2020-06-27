using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HandOptionScript : MonoBehaviour, IPointerClickHandler
{
    public string onText;
    public string offText;

    [Serializable] public class ButtonClickedEvent : UnityEvent { }
    [SerializeField] private ButtonClickedEvent OnStateChangeToTrue = new ButtonClickedEvent();
    [SerializeField] private ButtonClickedEvent OnStateChangeToFalse = new ButtonClickedEvent();

    bool state;

    public void OnPointerClick(PointerEventData eventData)
    {
        setState(!state);

        if (state)
            OnStateChangeToTrue.Invoke();
        else
            OnStateChangeToFalse.Invoke();
    }

    public void setState(bool state)
    {
        this.state = state;

        if (state)
            GetComponent<TextMeshProUGUI>().text = onText;
        else
            GetComponent<TextMeshProUGUI>().text = offText;
    }
}
