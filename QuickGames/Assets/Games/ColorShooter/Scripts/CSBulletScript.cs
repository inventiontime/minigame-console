using UnityEngine;
using static CSEnumerations;

// Handles bullet motion
public class CSBulletScript : MonoBehaviour
{
    public PrimaryType type;
    public CSGameManager gameManager;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * gameManager.BulletSpeed * Time.fixedDeltaTime);
    }
}
