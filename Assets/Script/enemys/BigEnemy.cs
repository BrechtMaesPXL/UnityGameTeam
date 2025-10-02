using UnityEngine;

public class BigEnemy : Enemy
{
    protected override void Awake()
    {
        health = 3;
        size = 1.5f;
        speed = 2f; 
        base.Awake();
    }
}
