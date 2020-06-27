using TMPro;
using UnityEngine;

// Animates menu button to fade in and out
public class MenuButtonAnim : MonoBehaviour
{
    public TextMeshProUGUI text;

    [SerializeField]
    float fadeInTime = 0.5f;
    [SerializeField]
    float fadeOutTime = 0.3f;
    [SerializeField]
    float fadeBound = 0.5f;

    float time = 0;

    Color temp;

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;

        if (time < fadeInTime)
        {
            temp = text.color;
            temp.a = (time / fadeInTime) * (1 - fadeBound) + fadeBound;
            text.color = temp;
        }
        else if (time < fadeInTime + fadeOutTime)
        {
            temp = text.color;
            temp.a = (1 - (time - fadeInTime) / fadeOutTime) * (1 - fadeBound) + fadeBound;
            text.color = temp;
        }
        else
        {
            time = 0;
        }
    }
}
