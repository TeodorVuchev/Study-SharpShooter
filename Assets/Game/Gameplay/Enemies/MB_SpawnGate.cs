using System.Collections;
using UnityEngine;

public class MB_SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] Transform spawnLocation;
    [SerializeField] Transform spawnParent;
    [SerializeField] float spawnDelay = 5f;
    MB_PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindFirstObjectByType<MB_PlayerHealth>();
        SpawnEnemy();
        StartCoroutine(SpawnHandler());
    }

    IEnumerator SpawnHandler()
    {
        yield return new WaitForSeconds(spawnDelay);

        if (playerHealth != null)
        {
            SpawnEnemy();
            StartCoroutine(SpawnHandler());
        }
    }

    void SpawnEnemy()
    {
        GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnLocation.position, spawnLocation.rotation);
    }


}
