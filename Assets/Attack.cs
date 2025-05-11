using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Vector2 rightAttackOffset;
    public Collider2D swordCollider;
    public PlayerController playerController;
    public void Start() {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
    }
    public void AttackOn() {
        swordCollider.enabled = true;  
    }
    // public void AttackLeft() {
    //     swordCollider.enabled = true;
    //     transform.localPosition = new Vector2(-rightAttackOffset.x, rightAttackOffset.y);
    // }
    // public void AttackUp() {
    //     swordCollider.enabled = true;
    //     transform.localPosition = new Vector2(downAttackOffset.x, -downAttackOffset.y);
    // }

    // public void AttackDown() {
    //     swordCollider.enabled = true;
    //     transform.localPosition = downAttackOffset;
    // }

    public void StopAttack() {
        swordCollider.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        // if(other.tag == "Enemy") {
        //     //playerController.LockMovement();
        //     Enemy enemy = other.GetComponent<Enemy>();
        //     if(enemy != null) {
        //         enemy.takeDamage(1);
        //         //playerController.LockMovement();
        //     }
        // }
        if(other.tag == "Player") {
            PlayerController p = other.GetComponent<PlayerController>();
            if(p != null) {
                p.takeDamage(1);
            }
        }
        swordCollider.enabled = false; 
    }
}
