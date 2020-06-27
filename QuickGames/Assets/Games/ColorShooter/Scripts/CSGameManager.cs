using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class CSGameManager : ScriptableObject
{
    // Settings and Values
    public int EnemySpeed;
    public int BulletSpeed;
    public float SpawnSpeed;
    public int secondaryEnemySpwanChancePercentage;
    public bool revived = false;
    public bool reviveMenu = false;

    // InGame Vars
    public int score;

    public void RevivePlayer()
    {
        revived = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void KillPlayer()
    {
        if (!SceneManager.GetActiveScene().name.EndsWith("Tutorial"))
        {
            Scores.setScore(score);
            if (revived)
            {
                SceneManager.LoadScene("GameOver");
                revived = false;
            }
            else
            {
                reviveMenu = true;
            }
        }
        else
        {
            CSTutorialController.Restart();
        }
    }
}