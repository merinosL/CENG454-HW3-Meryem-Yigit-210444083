using UnityEngine;

public class RapidFireDecorator : WeaponDecorator
{
    public RapidFireDecorator(IWeapon weapon) : base(weapon) { }

    public override void Fire()
    {
        base.Fire();
        Debug.Log("Fired additional rapid projectile");
    }
}