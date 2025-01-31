using UnityEngine;

public class Unit : MonoBehaviour, IMovable, IDamagable
{
    public float speed = 5f;
    public int health = 3;
    public float range = 100f;

    private Vector3 startPosition;
    private bool moveRight = true;
    public int Health => health;
    protected virtual void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (health > 0)
        {
            Move();
        }
    }
    public virtual void Move()
    {
        float maxOffset = range / 2;
        if (moveRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x > startPosition.x + maxOffset)
                moveRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < startPosition.x - maxOffset)
                moveRight = true;
        }
    }

    public virtual void TakeDamage()
    {
        health -= 10;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log("Unit is destroyed!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}