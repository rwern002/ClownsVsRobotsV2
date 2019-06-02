using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public Transform healthBar;
    
    public float startingHealth = 100;                            // The amount of health the player starts the game with.
    public float currentHealth;                                   // The current health the player has.
    GameObject HUDCanvas;
    public Text scoreComponent;                                 // Reference to the UI's score.
    public Text healthComponent;                                // Reference to the UI's health.
    public float score;


    bool isDead;                                                // Whether the player is dead.


    void Awake()
    {
        // Set the initial health of the player.
        HUDCanvas = GameObject.Find("HUDCanvas");
        //scoreComponent = 
        //healthComponent = GameObject.FindGameObjectWithTag("health");
        currentHealth = startingHealth;
        score = 100;
    }


    void Update()
    {
        // Set the health bar's value to the current health.
        healthComponent.text = "Health: " + currentHealth.ToString() + " / " + startingHealth.ToString();
        scoreComponent.text = "Money: " + score.ToString();
    }


    public void TakeDamage(int amount)
    {
        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        healthBar.localScale = new Vector3(currentHealth / startingHealth , 1.0f);

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void SpendMoney(int amount)
    {
        score -= amount;
    }

    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
    }
}