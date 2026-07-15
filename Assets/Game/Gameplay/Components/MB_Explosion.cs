using UnityEngine;

public class MB_Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;
    [SerializeField] int damage = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Start()
    {
        Explode();
    }

    void Explode()
    {
        Collider[] overlaps = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider collision in overlaps)
        {
            if(collision.GetComponent<MB_PlayerHealth>() is MB_PlayerHealth playerHealth)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
