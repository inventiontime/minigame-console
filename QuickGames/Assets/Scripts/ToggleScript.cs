using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour, IPointerClickHandler
{
    public Color onColor;
    public Color offColor;

    public Transform onTogglePositon;
    public Transform offTogglePositon;

    public Transform toggleDot;

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
        {
            GetComponent<Image>().color = onColor;
            toggleDot.position = onTogglePositon.position;
        }
        else
        {
            GetComponent<Image>().color = offColor;
            toggleDot.position = offTogglePositon.position;
        }
    }
}
