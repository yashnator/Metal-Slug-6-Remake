using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private int numLives = 3;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake() {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }
    private void PRespawn() {
        if(currentCheckpoint == null || numLives == 1) {
            uiManager.GameOver();
            return;
        }
        numLives -= 1;
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "Checkpoint") {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
