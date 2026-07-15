using StarterAssets;
using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class MB_ActiveWeapon : MonoBehaviour
{
    [SerializeField] SOS_Weapon startingWeaponSO;
    [SerializeField] GameObject zoomScope;
    [SerializeField] TMP_Text ammoUI;

    CinemachineCamera virtualCamera;
    Animator animator;
    FirstPersonController firstPersonController;

    float defaultFOV;
    float defaultRotationSpeed;
    int currentAmmo;

    const string FIRE_STRING = "A_WeaponFire";


    SOS_Weapon currentWeaponSO;
    StarterAssetsInputs starterAssetsInputs;
    MB_Weapon currentWeapon;
    Coroutine weaponCooldown;

    void Awake()
    {
        virtualCamera = FindFirstObjectByType<CinemachineCamera>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        defaultFOV = virtualCamera.Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start()
    {
        SwitchWeapon(startingWeaponSO);
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmmo(int ammount)
    {
        currentAmmo += ammount;
        if(currentAmmo > currentWeaponSO.MagazinSize)
        {
            currentAmmo = currentWeaponSO.MagazinSize;
        }
        ammoUI.text = currentAmmo.ToString("D2");
    }

    public void SwitchWeapon(SOS_Weapon weapon)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        GameObject newWeapon = Instantiate(weapon.WeaponPrefab, transform);
        newWeapon.transform.localPosition = weapon.HeldPosition;
        newWeapon.transform.localRotation = Quaternion.Euler(weapon.HeldRotation);

        currentWeapon = newWeapon.GetComponent<MB_Weapon>();
        this.currentWeaponSO = weapon;
        currentAmmo = currentWeaponSO.MagazinSize;
        ammoUI.text = currentAmmo.ToString("D2");
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;


        if (weaponCooldown != null) return;
        weaponCooldown = StartCoroutine(WeaponCooldown());

        if (currentAmmo <= 0) return;


        currentWeapon.Shoot(currentWeaponSO);
        AdjustAmmo(-1);
        animator.Play(FIRE_STRING, 0, 0f);

        if (!currentWeaponSO.IsAutomatic)
        {
            starterAssetsInputs.shoot = false;
        }
    }

    IEnumerator WeaponCooldown()
    {
        yield return new WaitForSeconds(currentWeaponSO.FireRate);
        weaponCooldown = null;
    }

    void HandleZoom()
    {
        if(!currentWeaponSO.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            virtualCamera.Lens.FieldOfView = currentWeaponSO.ZoomAmount;
            zoomScope.SetActive(true);
            firstPersonController.ChangeRotationSpeed(currentWeaponSO.ZoomRotationSpeed);
        }
        else
        {
            zoomScope.SetActive(false);
            virtualCamera.Lens.FieldOfView = defaultFOV;
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }
    }
}
