using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBelowFloor : MonoBehaviour
{
    [SerializeField] private float killHeight = -10f; 
    [SerializeField] private Health playerHealth; 

    void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = GetComponent<Health>();
        // Debug.Log("here");
        }
        // Debug.Log("theres3");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the trigger has the tag "Player"
        // Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("theres2");
            // Try to get the Health component from the player
            Health playerHealth = collision.GetComponent<Health>();

            if (playerHealth != null)
            {
                Debug.Log("theres");
                // Deal lethal damage by calling the TakeDamage method with the player's current health
                playerHealth.TakeDamage(playerHealth.currentHealth);
            }
            else
            {
                Debug.LogWarning("Player does not have a Health component attached!");
            }
        }
    }
}
