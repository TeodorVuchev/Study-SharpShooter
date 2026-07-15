using UnityEngine;

public class MB_EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    [SerializeField] GameObject deathVFX;

    int currentHP;

    private void Awake()
    {
        currentHP = maxHP;
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
            Destroy(gameObject);
        }
    }

    public void SelfDestruct()
    {
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
