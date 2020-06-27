using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Script for each button in game
public class SQButtonScript : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject lightShader;

    [Serializable] public class ButtonClickedEvent : UnityEvent { }
    [SerializeField] private ButtonClickedEvent OnClick = new ButtonClickedEvent();

    // Invoke OnClick when pressed
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke();
    }

    // Turn the light on or off
    public void SetState(bool lightOn)
    {
        lightShader.SetActive(!lightOn);
    }

    // Turn the light on when pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        SetState(true);
    }

    // Turn the light off when released
    public void OnPointerUp(PointerEventData eventData)
    {
        SetState(false);
    }
}
