using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Image healthBar;
    private float maxBarSize;
    private float currentBarSize;
    private int maxHealth;
    private int currentHealth;
    private int playerNumber;

    private void Start()
    {
        playerNumber = GetComponent<Character>().PlayerNumber;
        if (playerNumber == 1)
            healthBar = FindObjectOfType<HealthContainer>().healthBar1;
        else
            healthBar = FindObjectOfType<HealthContainer>().healthBar2;

        maxBarSize = healthBar.transform.localScale.x;
    }

    private void Update()
    {
        currentHealth = GetComponent<Character>().CurrentHealth;
        maxHealth = GetComponent<Character>().MaxHealth;

        float currentSizeX = maxBarSize / maxHealth * currentHealth;
        healthBar.transform.localScale = new Vector2(currentSizeX, healthBar.transform.localScale.y);
    }
}
