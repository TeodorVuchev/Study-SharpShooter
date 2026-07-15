using UnityEngine;

public class MB_Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers;

    public void Shoot(SOS_Weapon weapon)
    {
        RaycastHit hit;

        muzzleFlash.Play();

        if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers)) return;

        Instantiate(weapon.HitVFXPreFab, hit.point, Quaternion.identity);

        if (!hit.collider.TryGetComponent<MB_Health>(out MB_Health component)) return;

        component.TakeDamage(weapon.Damage);
    }
}
