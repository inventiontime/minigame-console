using UnityEngine;
using UnityEngine.UI;
using static CSEnumerations;

public class CSSecondaryEnemyScript : MonoBehaviour
{
    public SecondaryType type;
    public GameObject redPrimaryEnemy;
    public GameObject bluePrimaryEnemy;
    public GameObject yellowPrimaryEnemy;
    public CSGameManager gameManager;

    public GameObject enemyImage;
    public GameObject glow;
    public Shader shader;

    bool isDestroyed = false;
    float fade = 1;
    Material material;
    Image glowImage;
    Color tempColor;

    void Start()
    {
        enemyImage.GetComponent<Image>().material = new Material(shader);
        material = enemyImage.GetComponent<Image>().material;

        glowImage = glow.GetComponent<Image>();
    }

    // Moves enemy && sets shader's _Fade value if enemy is being destroyed
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * gameManager.EnemySpeed * Time.fixedDeltaTime);

        if (isDestroyed)
        {
            fade -= 2 * Time.fixedDeltaTime;

            tempColor = glowImage.color;
            tempColor.a = fade;
            glowImage.color = tempColor;

            if (fade <= 0)
                Destroy(gameObject);

            material.SetFloat("_Fade", fade);
        }
    }

    // Handles bullet and player collisons
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            PrimaryType temp = OtherColor(collision.gameObject.GetComponent<CSBulletScript>().type, type);
            if (temp != PrimaryType.Invalid)
            {
                // Correct bullet
                Destroy(collision.gameObject);
                Instantiate(GetPrefab(temp), transform.position, Quaternion.identity, transform.parent);
                Destroy(gameObject);

                gameManager.score += 75;
            }
            else
            {
                // Incorrect bullet
                Destroy(collision.gameObject);
                gameManager.KillPlayer();
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Hit player
            isDestroyed = true;
            AudioManager.instance.Play("Dissolve");
            gameManager.KillPlayer();
        }
    }

    // Converts PrimaryType to Prefab
    GameObject GetPrefab(PrimaryType type)
    {
        switch (type)
        {
            case PrimaryType.Red:
                return redPrimaryEnemy;

            case PrimaryType.Blue:
                return bluePrimaryEnemy;

            case PrimaryType.Yellow:
                return yellowPrimaryEnemy;

            default:
                return redPrimaryEnemy;
        }
    }
}
