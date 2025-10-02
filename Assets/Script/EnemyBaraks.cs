using System.Collections.Generic;
using UnityEngine;

public class EnemyBaraks : MonoBehaviour
{
    [Header("Enemy Prefab")]
    public Enemy enemyBasePrefab;

    [Header("Spawn Settings")]
    public float spawnRadius = 5f; // radius around the baraks where enemies can spawn

    public List<Enemy> SpawnEnemies(int amount)
    {
        List<Enemy> enemies = new List<Enemy>();

        for (int i = 0; i < amount; i++)
        {
            // Instantiate the enemy
            var enemy = GameObject.Instantiate<Enemy>(enemyBasePrefab);

            // Randomize position around the baraks
            Vector3 randomOffset = Random.insideUnitSphere;
            randomOffset.z = 0; // keep it 2D if you want
            enemy.transform.position = transform.position + randomOffset * spawnRadius;

            enemies.Add(enemy);
        }

        return enemies;
    }
}
