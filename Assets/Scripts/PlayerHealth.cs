using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth instance;

    public int maxHealth, currentHealth;
    public float invincibleLength;
    private float invincCounter;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;

        UIManager.instance.healthSlider.maxValue = maxHealth;
        UIManager.instance.healthSlider.value = currentHealth;
        UIManager.instance.healthText.text = "HEALTH: " + currentHealth + "/" + maxHealth;
    }

    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if (invincCounter <= 0)
        {
            AudioManager.instance.PlaySFX(7);

            currentHealth -= damageAmount;

            UIManager.instance.ShowDamage();

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);

                currentHealth = 0;

                GameManager.instance.PlayerDied();

                AudioManager.instance.StopBGM();
                AudioManager.instance.PlaySFX(6);
                AudioManager.instance.StopSFX(7);
            }

            invincCounter = invincibleLength;

            UIManager.instance.healthSlider.value = currentHealth;
            UIManager.instance.healthText.text = "HEALTH: " + currentHealth + "/" + maxHealth;
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIManager.instance.healthSlider.value = currentHealth;
        UIManager.instance.healthText.text = "HEALTH: " + currentHealth + "/" + maxHealth;
    }
}
