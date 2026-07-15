using Unity.Cinemachine;
using UnityEngine;

public class MB_AmmoPickup : MB_Pickup
{
    [SerializeField] int ammoAmount = 8;

    protected override void OnPickUp()
    {
        if(collision.GetComponentInChildren<MB_ActiveWeapon>() is MB_ActiveWeapon activeWeapon)
        {
            activeWeapon.AdjustAmmo(ammoAmount);
            Destroy(gameObject);
        }
    }
}
