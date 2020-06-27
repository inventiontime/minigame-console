using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ASEnumerations;

public class ASArrowScript : MonoBehaviour
{
    public void setDirection(Direction direction)
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z = getArrowRotation(direction);

        transform.eulerAngles = rotation;
    }

    public float getArrowRotation(Direction direction)
    {
        switch (direction)
        {
            case Direction.UP:
                return 180f;
            case Direction.LEFT:
                return 270f;
            case Direction.DOWN:
                return 0f;
            case Direction.RIGHT:
                return 90f;

            default:
                return 0f;
        }
    }
}
