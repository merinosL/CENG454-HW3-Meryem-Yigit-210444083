using UnityEngine;

public class BaseWeapon : IWeapon
{
    public void Fire()
    {
        Debug.Log("Fired standard projectile");
    }
}