using System;
using System.Collections;
using UnityEngine;

public class MB_Turret : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerLocation;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float fireRate = 2f;

    MB_PlayerHealth player;

    private void Start()
    {
        player = FindFirstObjectByType<MB_PlayerHealth>();
        StartCoroutine(FireRoutine());
    }

    private void Update()
    {
        turretHead.LookAt(playerLocation);
    }

    IEnumerator FireRoutine()
    {
        while (player)
        {
            yield return new WaitForSeconds(fireRate);
            if(player != null)
            {
                Instantiate(projectilePrefab,projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            }
        }
    }
}
