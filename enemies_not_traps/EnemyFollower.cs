using System;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private bool flip;

    [SerializeField] private float range;
    private float dist;
    private bool facingRight = true; // Tracks if the enemy is facing right

    void Update()
    {
        // Calculate distance and direction
        dist = Vector2.Distance(transform.position, player.transform.position);

        if (dist>range) return;

        Vector2 dir = player.transform.position - transform.position;
        dir.Normalize();

        // Move the enemy towards the player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        // Check if the enemy should flip
        if(!flip){
            if (dir.x < 0 && !facingRight)
            {
                Flip();
            }
            else if (dir.x > 0 && facingRight)
            {
                Flip();
            }
        } else{
            if (dir.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (dir.x < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    // Method to flip the enemy by adjusting its local scale
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Flip the x-axis
        transform.localScale = localScale;
    }
}
