using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IWeapon currentWeapon;
    [SerializeField] private GameObject bulletPrefab;

    private void Start()
    {
        currentWeapon = new BaseWeapon();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentWeapon.Fire(transform, bulletPrefab);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            currentWeapon = new RapidFireDecorator(currentWeapon);
            Debug.Log("Weapon Upgraded: Rapid Fire Acquired");
        }
    }
}