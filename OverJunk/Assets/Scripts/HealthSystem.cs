using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        maxHealth = health;
        UpdateHealth();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Damage Taken: " + damageAmount);
        UpdateHealth();
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        health = Mathf.Min(health, maxHealth); // Ensure health doesn't exceed maximum
        UpdateHealth();
    }

    void UpdateHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Superfície");
        }
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
