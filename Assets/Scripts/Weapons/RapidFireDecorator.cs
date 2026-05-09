using UnityEngine;

public class RapidFireDecorator : WeaponDecorator
{
    public RapidFireDecorator(IWeapon weapon) : base(weapon) { }

    public override void Fire(Transform firePoint, GameObject bulletPrefab)
    {
        base.Fire(firePoint, bulletPrefab);
        
        Vector3 offset = new Vector3(-0.5f, 0, 0);
        Object.Instantiate(bulletPrefab, firePoint.position + offset, Quaternion.identity);
    }
}