using StarterAssets;
using UnityEngine;

public class MB_Weapon : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] ParticleSystem muzzleFlash;

    StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    private void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        starterAssetsInputs.ShootInput(false);

        RaycastHit hit;

        muzzleFlash.Play();
        
        if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity)) return;

        if (!hit.collider.TryGetComponent<MB_Health>(out MB_Health component)) return;

        component.TakeDamage(damage);
    }
}
