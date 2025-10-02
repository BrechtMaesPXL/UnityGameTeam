using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PlanetController : MonoBehaviour
{
    public int maxHp = 1000;
    private int hp ;
    public GameObject hpBar;

    private Vector3 initilaHpScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = maxHp;
        if (hpBar != null)
            initilaHpScale = hpBar.transform.localScale;        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentState is PausedState) return;

        var mousePosition = Mouse.current.position.ReadValue();
        var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -Camera.main.transform.position.z));

        Vector3 direction = worldPos - transform.position;

        transform.up = direction;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggerd ");

        if (other.gameObject.CompareTag("Enemy"))
        {
            hp -= 50;
            Destroy(other.gameObject);
            if (hp <= 0)
            {
                Enemy[] allEnemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
                foreach (Enemy enemy in allEnemies)
                {
                    Destroy(enemy.gameObject);
                }
                hp = maxHp;
                EnemySpawner spawn = FindFirstObjectByType<EnemySpawner>();
                spawn.paused = true;

            }
            UpdateLifeUI();

        }
    }
    private void UpdateLifeUI()
    {
        if (hp <= 0) return;
        float ratio = Mathf.Clamp01((float)hp / maxHp);
        Vector3 scale = initilaHpScale;
        scale.x = initilaHpScale.x * ratio;
        hpBar.transform.localScale = scale;
    }
}