using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float size = 1f;
    public int health = 2;
    public float rotationAmplitude = 45f;
    public float rotationFrequency = 2f;
    public Transform target;
    public GameObject deathEffect;
    private float timeCounter;

    protected virtual void Awake()
    {
        transform.localScale = Vector3.one * 0.5f * size;

    }
    void Update()
    {
        if (GameManager.Instance.CurrentState is PausedState) return;

        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        transform.position += direction * (speed * Time.deltaTime);

        timeCounter += Time.deltaTime;
        float angle = Mathf.Sin(timeCounter * rotationFrequency) * rotationAmplitude;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    void OnDestroy()
    {
        Instantiate(deathEffect, transform.position, deathEffect.transform.rotation);
    }

    void Kill()
    {
        Instantiate(deathEffect, transform.position, deathEffect.transform.rotation);
        Destroy(gameObject);
    }
    public void DoDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Kill();
        }
    }

}