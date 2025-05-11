using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public Health healthBar;
    Animator animator;
    public int health;
    private bool isDefeated = false;
    public int maxHealth = 10;
    public SpriteRenderer renderer2;
    public GameObject player;
    public GameObject self;
    public void Start() {
        //Instantiate(e, transform.position, transform.rotation); this doesn't work
        animator = GetComponent<Animator>();
        renderer2 = GetComponent<SpriteRenderer>();
        health = maxHealth;
    }

    private void FixedUpdate() {
        if(isDefeated) return;
        if(self.transform.position.x > player.transform.position.x) renderer2.flipX = true;
        else if(self.transform.position.x < player.transform.position.x) renderer2.flipX = false;
    }
    public void Defeat() {
        animator.SetTrigger("Defeated");
    }
    public void RemoveEnemy() {
        Destroy(gameObject);
    }
    void OnMouseEnter()
    {
        HighlightObject();
    }

    void OnMouseExit()
    {
        RemoveHighlight();
    }

    void HighlightObject()
    {
        renderer2.color = Color.red;
    }

    void RemoveHighlight()
    {
        renderer2.color = Color.white; 
    }
    public void takeDamage(int damage) {
        health = Math.Max(0, health - damage);
        updateHealthBar();
        if(health == 0) {
            isDefeated = true;
            Defeat();
        }
    }
    public void updateHealthBar() {
        healthBar.SetHealth(Math.Max(0, health));
    }

}
