using UnityEngine;

// Handles difficulty of game based on score
public class CSGameDifficultyScript : MonoBehaviour
{
    public CSGameManager gameManager;
    public int stage1 = 2000;
    public int stage2 = 40000;
    public int stage3 = 60000;

    void Update()
    {
        if(gameManager.score <= stage1)
        {
            gameManager.SpawnSpeed = ((stage1 - gameManager.score) * 2f / stage1) + 1f;
            gameManager.secondaryEnemySpwanChancePercentage = 0;
        }
        else if(gameManager.score <= stage2)
        {
            gameManager.SpawnSpeed = ((gameManager.score - stage1) * 2f / (stage2 - stage1)) + 1f;
            gameManager.secondaryEnemySpwanChancePercentage = (gameManager.score - stage1) * 100 / (stage2 - stage1);
        }
        else if (gameManager.score <= stage3)
        {
            gameManager.SpawnSpeed = (((stage3 - stage2) - (gameManager.score - stage2)) * 2f / (stage3 - stage2)) + 1f;
            gameManager.secondaryEnemySpwanChancePercentage = 100;
        }
        else
        {
            gameManager.SpawnSpeed = 1f;
            gameManager.secondaryEnemySpwanChancePercentage = 100;
        }
    }
}
