using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class MB_Robot : MonoBehaviour
{

    FirstPersonController player;
    NavMeshAgent agent;

    const string PLAYER_LAYER = "Player";
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        player = FindAnyObjectByType<FirstPersonController>();
    }

    private void Update()
    {
        if(player != null)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_LAYER))
        {
            MB_EnemyHealth enemyHealth = GetComponent<MB_EnemyHealth>();
            enemyHealth.SelfDestruct();
        }
    }
}
