using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/18/2024]
 * [Contains all player variable data such as health, thirst, etc]
 */

public class PlayerData : MonoBehaviour
{
    //singelton for PlayerData
    private static PlayerData _instance;
    public static PlayerData Instance { get { return _instance; } }

    public bool unlimitedThirst = false;

    //int for the player score, floats for player health and player thirst values
    public int playerScore;
    public float playerHealth;
    public float playerThirst;

    private void Awake()
    {
        //if _instance contains something and it isn't this
        if (_instance != null && _instance != this)
        {
            //Destroy it
            Destroy(this.gameObject);
        }
        else
        {
            //otherwise set this to _instance
            _instance = this;
        }
    }

    void Update()
    {
        if (unlimitedThirst)
        {
            playerThirst = 100f;
        }
    }

    /// <summary>
    /// Resets all of the players data values to their default state
    /// </summary>
    public void ResetPlayerData()
    {
        //set player score to 0, set player health to 100, and set playerThirst to 100
        playerScore = 0;
        playerHealth = 100;
        playerThirst = 100;
    }

    public IEnumerator UnlimitedThirst(float unlimitedDuration)
    {
        float originalThirst = playerThirst;

        for (int index = 0; index < 1; index++)
        {
            unlimitedThirst = true;

            yield return new WaitForSeconds(unlimitedDuration);
        }

        unlimitedThirst = false;

        playerThirst = originalThirst;
    }

    /// <summary>
    /// Applies the items ability to the player data class
    /// </summary>
    /// <param name="itemBehavior"> the use of the item/function </param>
    public void ApplyItemAbility(IItemBehavior itemBehavior)
    {
        itemBehavior.UseItem(this);
    }
}
