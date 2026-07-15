using UnityEngine;

public class MB_WeaponPickup : MB_Pickup
{
    [SerializeField] SOS_Weapon weapon;

    protected override void OnPickUp()
    {
        if (collision.GetComponentInChildren<MB_ActiveWeapon>() is MB_ActiveWeapon activeWeapon)
        {
            activeWeapon.SwitchWeapon(weapon);
            Destroy(gameObject);
        }
    }
}
