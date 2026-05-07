using UnityEngine;

public interface IWeapon 
{
    void Fire(Transform firePoint, GameObject bulletPrefab);
}