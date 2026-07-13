using StarterAssets;
using UnityEngine;

public class MB_Weapon : MonoBehaviour
{
    [SerializeField] GameObject hitVFXPrefab;
    [SerializeField] int damage = 1;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem muzzleFlash;

    const string FIRE_STRING = "A_WeaponFire";

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
        animator.Play(FIRE_STRING, 0, 0f);
        
        if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity)) return;

        Instantiate(hitVFXPrefab, hit.point, Quaternion.identity);

        if (!hit.collider.TryGetComponent<MB_Health>(out MB_Health component)) return;

        component.TakeDamage(damage);
    }
}
