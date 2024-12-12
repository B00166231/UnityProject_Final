using UnityEngine;
using UnityEngine.UI; 
using System.Collections; 
using System.Collections.Generic;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    public GameObject obstaclePrefab;
    public GameObject coinPrefab;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();

        SpawnObstacle();
        SpawnCoins();  // Call SpawnCoins to actually spawn the coins
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2f);
    }

    void SpawnObstacle()
    {
        // Choose random spawn point of obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn obstacle at different position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnCoins()  
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;  
        return point;
    }
}
