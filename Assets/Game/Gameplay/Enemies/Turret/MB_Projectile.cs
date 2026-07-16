using System.Collections;
using UnityEngine;

public class MB_Projectile : MonoBehaviour
{
    [SerializeField] float movementSpeed = 30f;
    [SerializeField] float lifeTime = 3f;
    [SerializeField] int damage = 1;
    [SerializeField] GameObject hitVFXPreFab;
    
    Rigidbody rb;
    MB_ActiveWeapon player;
    const string PLAYER_STRING = "Player";

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MB_PlayerHealth>() is MB_PlayerHealth playerHealth)
        {
            playerHealth.TakeDamage(damage);
        }
        Instantiate(hitVFXPreFab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Start()
    {
        player = FindFirstObjectByType<MB_ActiveWeapon>();
        transform.LookAt(player.transform);
        StartCoroutine(DestroyDelayOnNoTargetHit());
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * Time.fixedDeltaTime * movementSpeed);
    }

    IEnumerator DestroyDelayOnNoTargetHit()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }


}
