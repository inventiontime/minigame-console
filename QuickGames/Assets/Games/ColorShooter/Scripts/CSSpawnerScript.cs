using UnityEngine;

// Spawns enemys depending on values in GameManager object
public class CSSpawnerScript : MonoBehaviour
{
    public CSGameManager gameManager;
    public GameObject spawnPoint;
    public GameObject[] primaryEnemyPrefabs;
    public GameObject[] secondaryEnemyPrefabs;
    float remainingTime;

    private void Update()
    {
        if (remainingTime < 0)
        {
            if (Random.Range(0, 100) > gameManager.secondaryEnemySpwanChancePercentage)
            {
                Instantiate(primaryEnemyPrefabs[Random.Range(0, primaryEnemyPrefabs.Length)], spawnPoint.transform);
            }
            else
            {
                Instantiate(secondaryEnemyPrefabs[Random.Range(0, secondaryEnemyPrefabs.Length)], spawnPoint.transform);
            }
            remainingTime = gameManager.SpawnSpeed;
        }
        else
        {
            remainingTime -= Time.deltaTime;
        }
    }
}
