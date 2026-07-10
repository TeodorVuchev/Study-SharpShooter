using UnityEngine;

public class MB_Health : MonoBehaviour
{
    [SerializeField] int maxHP = 3;

    int currentHP;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
