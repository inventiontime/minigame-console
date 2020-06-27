using TMPro;
using UnityEngine;

// Updates score counter
public class CSScoreScript : MonoBehaviour
{
    public CSGameManager gameManager;
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = gameManager.score.ToString();
    }
}
