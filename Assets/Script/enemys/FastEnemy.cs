using UnityEngine;

public class FastEnemy : Enemy
{
    protected override void Awake()
    {
        size = 0.7f;
        speed = 6.0f; 
        base.Awake();
    }
}
