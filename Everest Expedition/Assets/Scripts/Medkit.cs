using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: []
 * Last Updated: [03/19/2024]
 * [A medkit that the player can pickup, and bring health back to full]
 */

public class Medkit : Item
{
    /// <summary>
    /// heals the players health back to full
    /// </summary>
    public void HealPlayer()
    {
        //set the itemHealAmount to the amount of health the player is missing
        itemHealAmount = 100 - PlayerData.Instance.playerHealth;

        //add the itemHealAmount to the player's health to bring them back to full health
        PlayerData.Instance.playerHealth += itemHealAmount;
    }
}