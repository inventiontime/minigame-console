using UnityEngine;

// Shoots bullets from gun at gunPoint
public class CSGunScript : MonoBehaviour
{
    public GameObject gunPoint;
    public GameObject[] bulletPrefabs;

    public void shootBullet(int i)
    {
        Instantiate(bulletPrefabs[i], gunPoint.transform);
        AudioManager.instance.Play("Shoot");
    }
}
