using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject topBulletPrefab;
    public GameObject bottomBulletPrefab;
    public Transform[] topShootingPoints;
    public Transform[] bottomShootingPoints;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ShootFromPoints(topShootingPoints, topBulletPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ShootFromPoints(bottomShootingPoints, bottomBulletPrefab);
        }
    }

    private void ShootFromPoints(Transform[] shootingPoints, GameObject bulletPrefab)
    {
        foreach (Transform point in shootingPoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, point.position, point.rotation);
        }
    }
}
