using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private Rigidbody2D body;
    private Animator anim;
    private bool isGrounded;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip the player when you move left or right
        if(horizontalInput > 0.01f){
            transform.localScale = Vector3.one;
        } else if(horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Jump();
        }

        if(Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0) {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        }
        // Inform the animator
        anim.SetBool("isRunning", horizontalInput != 0);
        anim.SetBool("isGrounded", isGrounded);
    }

    private void Jump() {
        SoundManager.instance.PlaySound(jumpSound);
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        // anim.SetTrigger("isJumping");
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground") { 
            isGrounded = true;
        }
    }

    public bool canAttack() {
        return true;
    }
}
