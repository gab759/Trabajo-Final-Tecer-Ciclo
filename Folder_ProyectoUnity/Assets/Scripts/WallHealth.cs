using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WallHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    public TextMeshProUGUI healthText; 

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameManager.Instance.TriggerLose();
        }
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthText.text = "Vida: " + currentHealth;
    }
}