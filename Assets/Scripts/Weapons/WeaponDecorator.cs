using UnityEngine;

public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon wrappedWeapon;

    public WeaponDecorator(IWeapon weapon)
    {
        wrappedWeapon = weapon;
    }

    public virtual void Fire(Transform firePoint, GameObject bulletPrefab)
    {
        wrappedWeapon?.Fire(firePoint, bulletPrefab);
    }
}