using UnityEngine;

public class BaseWeapon : IWeapon
{
    public void Fire(Transform firePoint, GameObject bulletPrefab)
    {
        Object.Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}