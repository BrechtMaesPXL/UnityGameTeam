using System.Collections.Generic;
using UnityEngine;

public class PlayingState : State
{
    private EnemySpawner spawn;

    private GameManager gM;


    // [System.Obsolete]
    public void OnEnter(GameManager gameManager)
    {
        gM = gameManager;
        spawn = Object.FindObjectOfType<EnemySpawner>();
        int amount = gM.returnWave() * 10;
        List<Enemy> enemies = gM.baraks.SpawnEnemies(amount);
        spawn.EnemyListAdd(enemies);

    }


    public void OnExit(GameManager gameManager)
    {
    }


    public void OnUpdate(GameManager gameManager)
    {
    }
}