using Unity.Cinemachine;
using UnityEngine;

public class MB_Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers;

    CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shoot(SOS_Weapon weapon)
    {
        RaycastHit hit;

        muzzleFlash.Play();
        impulseSource.GenerateImpulse();

        if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers)) return;

        Instantiate(weapon.HitVFXPreFab, hit.point, Quaternion.identity);

        if (!hit.collider.TryGetComponent<MB_EnemyHealth>(out MB_EnemyHealth component)) return;

        component.TakeDamage(weapon.Damage);
    }
}
