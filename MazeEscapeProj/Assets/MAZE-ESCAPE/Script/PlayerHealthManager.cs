using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;
    public int playerHealAmount;
    

    public void HurtPlayer(int damageToGive)
    {
        if(playerCurrentHealth <= 1)
        {
            // change game state to game over
            GameManager.instance.UpdateGameState(GameState.GameOver);
            return;
        }
        
        GameManager.instance.UpdateGameState(GameState.Playing);
        playerCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void HealPlayer(int healAmount)
    {
        playerCurrentHealth += healAmount;
        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
    }

}
