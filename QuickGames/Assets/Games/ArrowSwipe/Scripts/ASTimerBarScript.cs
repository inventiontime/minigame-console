using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ASTimerBarScript : MonoBehaviour
{
    public Image image;

    public void SetFraction(float fraction)
    {
        image.rectTransform.localScale = new Vector3(fraction, 1, 1);
        image.color = Color.HSVToRGB(100f * fraction / 360, 0.75f, 1f);
    }
}
