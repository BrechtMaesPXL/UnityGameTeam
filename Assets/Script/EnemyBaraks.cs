using System.Collections.Generic;
using UnityEngine;

public class EnemyBaraks : MonoBehaviour
{
    [Header("Enemy Prefab")]
    public Enemy enemyBasePrefab;
    public FastEnemy fastEnemyPrefab;
    public BigEnemy bigEnemyPrefab;
    [Header("Spawn Settings")]
    public float spawnRadius = 5f;
    public List<Enemy> SpawnEnemies(int amount)
    {
        List<Enemy> enemies = new List<Enemy>();

        for (int i = 0; i < amount; i++)
        {
            var enemy = RandomEnemy();

            Vector3 randomOffset = Random.insideUnitSphere;
            randomOffset.z = 0;
            enemy.transform.position = transform.position + randomOffset * spawnRadius;

            enemies.Add(enemy);
        }

        return enemies;
    }
    public Enemy RandomEnemy()
    {
        int rand = Random.Range(0, 100);
        if (rand <= 50)
            return GameObject.Instantiate<Enemy>(enemyBasePrefab);
        else if (rand <= 80)
            return GameObject.Instantiate<FastEnemy>(fastEnemyPrefab);
        else
            return GameObject.Instantiate<BigEnemy>(bigEnemyPrefab);
    }
}
