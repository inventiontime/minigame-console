using TMPro;
using UnityEngine;

// Handles score counter and adding to score
public class ASScoreScript : MonoBehaviour
{
    public int score = 0;

    // Score counter script
    public void Update()
    {
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    // Used by other classes when adding score
    public void addScore()
    {
        score += 10;
    }
}
