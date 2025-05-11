using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Photon.Pun;
public class PlayerController : MonoBehaviour {
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public int damage = 1;
    bool canMove = true;
    bool isBattling = false;
    public float maxRange = 0.55f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    public Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    public Attack swordAttack;
    PhotonView view;
    public Health healthBar;
    public int health;
    public int maxHealth = 10;
    //public GameObject firstBar;
    public void takeDamage(int damage) {
        health = Math.Max(0, health - damage);
        health = Math.Min(health, maxHealth);
        updateHealthBar();
        // if(health == 0) {
        //     isDefeated = true;
        //     Defeat();
        // }
    }
    public void updateHealthBar() {
        healthBar.SetHealth(Math.Max(0, health));
        print("player health is now: " + health);
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        view = GetComponent<PhotonView>();
        health = maxHealth;
        //PhotonNetwork.PlayerList.Length



        // if(PhotonNetwork.CurrentRoom.PlayerCount == 1) {
        //     if(GameObject.FindGameObjectsWithTag("Bar 1").Length == 0) print("1");
        //     if(GameObject.FindGameObjectsWithTag("Bar 3").Length == 0) print("12");
        //     healthBar = GameObject.FindGameObjectWithTag("Bar 1").GetComponent<Health>();

        // }


        
        //print( + " Players Online");
    }
    private void FixedUpdate() { // FixedUpdate called a certain number of time per second
        // if(Input.GetMouseButtonDown(0))
        //     SelectTarget();
        if(view.IsMine) {
            if(canMove) {
                if(movementInput != Vector2.zero) {
                    bool success = TryMove(movementInput);
                    if(!success) {
                        success = TryMove(new Vector2(movementInput.x, 0));
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                    if(success) {
                        if(movementInput.x > 0) FaceRight();
                        else if(movementInput.x < 0) FaceLeft();
                        else if(movementInput.y > 0) FaceUp();
                        else if(movementInput.y < 0) FaceDown();
                    }
                    animator.SetBool("isMoving", success);
                }
                else animator.SetBool("isMoving", false);
            }
        }
    }
    private void FaceRight() {
        spriteRenderer.flipX = false;
        animator.SetFloat("MoveX", movementInput.x);
        animator.SetFloat("MoveY", 0f);
    }
    private void FaceLeft() {
        spriteRenderer.flipX = true;
        animator.SetFloat("MoveX", -movementInput.x);
        animator.SetFloat("MoveY", 0f);
    }
    private void FaceDown() {
        animator.SetFloat("MoveY", movementInput.y);
        animator.SetFloat("MoveX", 0f);
    }
    private void FaceUp() {
        animator.SetFloat("MoveY", movementInput.y);
        animator.SetFloat("MoveX", 0f);
    }
    private bool TryMove(Vector2 direction) {
        if(direction != Vector2.zero) {
            int count = rb.Cast(direction, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);
            if(count == 0) {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
        }
        return false;
    } 

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
    public void heal() {
        animator.SetTrigger("heal");
        takeDamage(-3);
    }
    public void cripplingStrike() {
        animator.SetTrigger("cs");
        swordAttack.AttackOn();
    }
    public void vitalityDrain() {
        animator.SetTrigger("vd");
        swordAttack.AttackOn();
    }
    public void defenseAura() {
        animator.SetTrigger("da");
    }
    public void parasite() {
        animator.SetTrigger("p");
        swordAttack.AttackOn();
    }
    public void arcaneSlash() {
        animator.SetTrigger("as");
        swordAttack.AttackOn();
    }
    public void PerformBasicAttack() {
        //if(movementInput.x > 0)  
        // if(Math.Sqrt(Math.Pow(player.transform.position.x - selectedUnit.transform.position.x, 2) + Math.Pow(player.transform.position.y - selectedUnit.transform.position.y, 2)) < maxRange) {
        //     float enemyPosX = selectedUnit.transform.position.x, enemyPosY = selectedUnit.transform.position.y;
        //     float selfPosX = player.transform.position.x, selfPosY = player.transform.position.y;
        //     int orientation = 0;
        //     float maxDist = 0f;
        //     if(enemyPosX - selfPosX > maxDist) {
        //         //print("facing down");
        //         orientation = 1;
        //         maxDist = enemyPosX - selfPosX;
        //     }
        //     else if(selfPosX - enemyPosX > maxDist) {
        //         orientation = 2;
        //         maxDist = selfPosX - enemyPosX;
        //     }
        //     // else if(selfPosY - enemyPosY > maxDist) {
        //     //     print("facing down");
        //     //     orientation = 3;
        //     //     maxDist = selfPosY - enemyPosY;
        //     // }
        //     // else if(enemyPosY - selfPosY > maxDist) {
        //     //     orientation = 4;
        //     //     maxDist = enemyPosY - selfPosY;
        //     // }
        //     switch(orientation) {
        //         case 1:
        //             FaceRight();
        //             break;
        //         case 2:
        //             FaceLeft();
        //             break;
        //         // case 3:
        //         //     FaceDown();
        //         //     break;
        //         // case 4:
        //         //     FaceUp();
        //         //     break;
        //         default:
        //             break;
        //     }        
        //     SwordAttack();
        //     //player.transform.position = new Vector2(selectedUnit.transform.position.x, selectedUnit.transform.position.y);
        //     //selectedUnit.GetComponent<Enemy>().takeDamage(damage);
        // }
        //SwordAttack();

        print("hitting");
        LockMovement();
        //LockMovement();
        animator.SetTrigger("swordAttack");
        swordAttack.AttackOn();
        //animator.SetBool("isMoving", true);
        //SwordAttack();
        //UnlockMovement();
        // LockMovement();
        // SwordAttack();
        // if(animator.gameObject.activeSelf)
        //     animator.SetTrigger("swordAttack");
        // UnlockMovement();
        
    }
    //public void SwordAttack() {
        //if(movementInput.x > 0) swordAttack.AttackRight();
        //else swordAttack.AttackLeft();
        
        // //LockMovement();
        // if(movementInput.x > 0) {
        //     //swordAttack.AttackRight();
        //     print("Attacking Right");
        // }
        // else 
        //     //swordAttack.AttackLeft();
        //     print("Attacking Left");
        // }
        // else if(movementInput.y > 0) {
        //     //swordAttack.AttackUp();
        //     print("Attacking Up");
        // }
        // else if(movementInput.y < 0) {
        //     //swordAttack.AttackDown();
        //     print("Attacking Down");
        // }

    //}
    public void EndSwordAttack() {
        UnlockMovement();
        swordAttack.StopAttack();
    }
    public void LockMovement() {
        animator.SetBool("isMoving", false);
        canMove = false;
    }
    public void UnlockMovement() {
        canMove = true;
    }
    // void SelectTarget() {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
    //     if(hit.collider != null && hit.collider.CompareTag("Enemy")) {
    //         if(isBattling) selectedUnit.transform.GetChild(0).gameObject.SetActive(false);
    //         selectedUnit = hit.transform.gameObject;
    //         isBattling = true;
    //         selectedUnit.transform.GetChild(0).gameObject.SetActive(true);
    //     }
    // }
}   
