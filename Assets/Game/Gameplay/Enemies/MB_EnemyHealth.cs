using UnityEngine;

public class MB_EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    [SerializeField] GameObject deathVFX;

    int currentHP;

    MB_GameManager manager;

    private void Awake()
    {
        currentHP = maxHP;
    }

    private void Start()
    {
        manager = FindFirstObjectByType<MB_GameManager>();
        manager.AdjustEnemiesLeft(1);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            if (deathVFX != null)
            {
                Instantiate(deathVFX, transform.position, Quaternion.identity);
            }
            manager.AdjustEnemiesLeft(-1);
            Destroy(gameObject);
        }
    }

    public void SelfDestruct()
    {
        manager.AdjustEnemiesLeft(-1);
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
