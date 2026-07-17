using StarterAssets;
using System;
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
    [SerializeField] GameObject gameOverUI;


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
            PlayerGameOver();
        }
    }

    private void PlayerGameOver()
    {
        weaponCamera.parent = null;
        deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
        gameOverUI.SetActive(true);
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(gameObject);
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

    internal void TakeDamage(object damage)
    {
        throw new NotImplementedException();
    }
}
