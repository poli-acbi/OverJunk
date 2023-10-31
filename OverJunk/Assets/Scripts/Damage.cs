using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public HealthSystem pHealth;
    public int damage;
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 50.0f;
    public float selfDestructTime = 20.0f;
    
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * moveSpeed;

        Invoke("SelfDestruct", selfDestructTime);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth = other.gameObject.GetComponent<HealthSystem>();
            if (pHealth != null)
            {
                pHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

    }
}
