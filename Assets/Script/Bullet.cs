using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentState is PausedState) return;

        transform.position = transform.position + speed * Time.deltaTime * transform.up;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}