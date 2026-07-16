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

        if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore)) return;

        Instantiate(weapon.HitVFXPreFab, hit.point, Quaternion.identity);

        if (hit.collider.GetComponentInParent<MB_EnemyHealth>() is MB_EnemyHealth component)
        {
            component.TakeDamage(weapon.Damage);
        }
    }
}
