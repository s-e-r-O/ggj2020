using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Vector2 direction = Vector2.right;
    public float fireRate = 1f;
    
    
    private float nextFire;
    public void Update()
    {
       if (Input.GetButton("Fire1"))
        {
            Shoot();
        } 
    }

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.direction = direction;
            nextFire = Time.time + fireRate;
        }
    }
}
