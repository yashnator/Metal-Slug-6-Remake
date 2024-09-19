using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator anim;
    private bool dead;

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    [Header ("Components")]
    [SerializeField] private Behaviour[] components;
    private bool isInvunerable;
    private SpriteRenderer spriteRend;

    [Header("Death sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    private int minHt = -1000;

    private void Awake() {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage) {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth > 0) {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            SoundManager.instance.PlaySound(hurtSound);
        } else{
            if(!dead){
                anim.SetTrigger("die");
                dead = true;

                foreach(Behaviour component in components){
                    component.enabled = false;
                }
                anim.SetBool("isGrounded", true);
                SoundManager.instance.PlaySound(deathSound);
            }
        }
    }

    private void Update() {
        if(transform.position.y < minHt) {
            // Debug.Log(transform.position.y);
            TakeDamage(currentHealth);
        }
    }

    public void AddHealth(float _value) {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn() {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("PlayerIdle");
        StartCoroutine(Invunerability());
        foreach(Behaviour component in components){
            component.enabled = true;
        }
    }

    private IEnumerator Invunerability() {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for(int i = 0; i < numberOfFlashes; ++i){
            foreach(SpriteRenderer c in GetComponentsInChildren<SpriteRenderer>()) {
                c.material.color = new Color(1, 0, 0, 0.5f);
            }
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            foreach(SpriteRenderer c in GetComponentsInChildren<SpriteRenderer>()) {
                c.material.color = Color.white;
            }
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}
