using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public HealthSystem pHealth;
    public int healAmount;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth = other.gameObject.GetComponent<HealthSystem>();
            if (pHealth != null)
            {
                pHealth.Heal(healAmount); // Healing the player
            }

            Destroy(gameObject);
        }
    }
}
