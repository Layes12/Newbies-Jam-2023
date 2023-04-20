using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject topBulletPrefab;
    public GameObject bottomBulletPrefab;
    public Transform[] topShootingPoints;
    public Transform[] bottomShootingPoints;
    public float fireRate = 0.2f;

    private bool shooting = false;
    private float nextFire = 0f;
    private bool canShootTop = true;
    private bool canShootBottom = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && canShootTop)
        {
            shooting = true;
            canShootBottom = false;
        }
        else if (Input.GetKeyDown(KeyCode.S) && canShootBottom)
        {
            shooting = true;
            canShootTop = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            shooting = false;
            canShootBottom = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            shooting = false;
            canShootTop = true;
        }

        if (shooting && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            if (canShootTop)
            {
                for (int i = 0; i < topShootingPoints.Length; i++)
                {
                    GameObject bullet = Instantiate(topBulletPrefab, topShootingPoints[i].position, Quaternion.identity);
                    
                }
            }
            else if (canShootBottom)
            {
                for (int i = 0; i < bottomShootingPoints.Length; i++)
                {
                    GameObject bullet = Instantiate(bottomBulletPrefab, bottomShootingPoints[i].position, Quaternion.identity);
                    
                }
            }
        }
    }
}
