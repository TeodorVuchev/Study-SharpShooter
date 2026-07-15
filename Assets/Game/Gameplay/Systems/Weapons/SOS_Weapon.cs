using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class SOS_Weapon : ScriptableObject
{
    public int Damage = 1;
    public float FireRate = .5f;
    public GameObject HitVFXPreFab;
    public bool IsAutomatic = false;
    public bool CanZoom = false;
    public float ZoomAmount = 10f;
    public float ZoomRotationSpeed = 0.3f;
    public Vector3 HeldPosition;
    public Vector3 HeldRotation;
    public GameObject WeaponPrefab;
    public int MagazinSize = 12;
}
