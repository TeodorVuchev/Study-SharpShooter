using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class MB_PlayerHealth : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] int maxHP = 5;
    [SerializeField] CinemachineCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] healthBars;


    int gameOverVirtualCameraPriority = 20;
    int currentHP;

    private void Awake()
    {
        currentHP = maxHP;
    }

    private void Start()
    {
        AdjustShieldUI();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        AdjustShieldUI();

        if (currentHP <= 0)
        {
            weaponCamera.parent = null;
            deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
            Destroy(gameObject);
        }
    }

    void AdjustShieldUI()
    {
        int hpAvailable = currentHP;

        foreach(Image bar in  healthBars)
        {
            if (hpAvailable < 1)
            {
                bar.enabled = false;
            }
            else
            {
                bar.enabled = true;
                hpAvailable--;
            }
        }
    }
}
