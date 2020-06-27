using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static ASEnumerations;

public class ASPadScript : MonoBehaviour, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    Direction lastDirection;
    bool pointerInPad = false;
    Vector2 startPosition;

    void Start()
    {
        lastDirection = Direction.NONE;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerInPad = true;
        startPosition = eventData.position;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(pointerInPad)
            lastDirection = SwipeDirection(eventData);
        pointerInPad = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(pointerInPad)
            lastDirection = SwipeDirection(eventData);
    }

    Direction SwipeDirection(PointerEventData eventData)
    {
        float rotation = (Mathf.Rad2Deg * Mathf.Atan2(eventData.position.y - startPosition.y, eventData.position.x - startPosition.x));
        
        if (45 < rotation && rotation < 135) return Direction.UP;
        if (135 < rotation || rotation < -135) return Direction.LEFT;
        if (-135 < rotation && rotation < -45) return Direction.DOWN;
        if (-45 < rotation || rotation < 45) return Direction.RIGHT;

        return Direction.UP;
    }

    public Direction GetLastSwipe()
    {
        Direction temp = lastDirection;
        lastDirection = Direction.NONE;
        return temp;
    }
}
