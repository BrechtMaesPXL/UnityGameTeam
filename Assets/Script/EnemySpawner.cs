using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlanetController target;
    public float range = 15f;
    public bool paused = true;
    private float countDown;

    private List<Enemy> enemies = new List<Enemy>();
    private int currentEnemyIndex = 0; // Track which enemy to spawn next

    void Update()
    {
        if (paused) return;

        if (GameManager.Instance.CurrentState is WaveEndState) return;
        // All enemies spawned
        if (currentEnemyIndex >= enemies.Count)
        {
            GameManager.Instance.WaveEnd();
            return;
        }

        countDown -= Time.deltaTime;

        if (countDown <= 0)
        {
            // Spawn the next enemy
            SpawnEnemy(enemies[currentEnemyIndex]);
            currentEnemyIndex++;

            // Reset countdown for next spawn
            countDown = Random.Range(0.8f, 2f);
        }
    }

    void SpawnEnemy(Enemy enemy)
    {
        if (enemy == null) return;

        enemy.target = target.transform;

        Vector3 randomDirection = Random.insideUnitSphere;
        randomDirection.z = 0; // Keep on 2D plane

        enemy.transform.position = transform.position + randomDirection * range;
        enemy.transform.up = target.transform.position - enemy.transform.position;
    }

    public void EnemyListAdd(List<Enemy> newEnemies)
    {
        enemies = newEnemies;
        currentEnemyIndex = 0; // Reset spawn index for new wave
        countDown = 0; // Start spawning immediately
    }
}
