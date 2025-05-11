// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEditor.UI;
// using UnityEngine;

// public class BattleHandler : MonoBehaviour {
//     private int maxHealth = 60;
//     private int maxMana = 60;
//     private int maxStrength = 30;
//     private int maxSpeed = 30;
//     private int maxDefense = 30;
//     private int maxLuck = 30;
//     private int health;
//     private int mana;
//     private int strength;
//     private int speed;
//     private int defense;
//     private int luck;
//     private int healingFactor = 100;
//     public BattleHandler(int health, int mana, int strength, int speed, int defense, int luck, int passiveOption) {
//         this.health = maxHealth = health;
//         this.mana = maxMana = mana;
//         this.strength = maxStrength = strength;
//         this.speed = maxSpeed = speed;
//         this.defense = maxDefense = defense;
//         this.luck = maxLuck = luck;
//         if(passiveOption == 1) {
            
//         }
//     }
//     public void changeHealth(int amt) {
//         health = Math.Min(maxHealth, health + amt);
//         health = Math.Max(0, health + amt);
//     }
//     public void changeMana(int amt) {
//         mana = Math.Min(maxMana, mana + amt);
//         mana = Math.Max(0, mana + amt);
//     }
//     public void setDefense(int percent) {
//         defense = (defense*(percent)+99)/100;
//     }
//     public int getDefense() {
//         return defense;
//     }
    
//     public int getMana() {
//         return mana;
//     }
    
//     public int getDamage(BattleHandler other) {
//         return Math.Max(2, strength - other.getDefense()/2);
//     } 
//     public void heal(int pt) {
//         changeHealth(health + (15 + 3 * pt)*healingFactor);
//     }
//     public void cripplingStrike(int pt, BattleHandler other) {
//         other.changeHealth(getDamage(other) + Math.Max(1, getDamage(other)/10));
//         other.setDefense(20);
//     }
//     public void vitalityDrain(int pt, BattleHandler other) {
//         other.changeHealth(-((getDamage(other)*85+99)/100));
//         other.changeHealth(-(5+pt));
//         other.changeMana(-(5+pt));
//     }
//     public void defenseAura(int pt) {
//         setDefense(100-(25+2*pt));
//     }
//     public void parasite(int pt, BattleHandler other) {
//         int amt = (other.getMana()*(10+pt)+99)/100;
//         other.changeMana(-amt);
//         mana += Math.Max(5, amt);
//     }
//     public void strengthBoost(int pt) {
//         strength = 15+2*pt;
//     }
//     public void taintedEdge(int pt, BattleHandler other) {
//         other.changeHealth((-getDamage(other)*85+99)/100);
//         healingFactor = 100-20-2*pt;
//     }
//     public void arcaneSlash(int pt, BattleHandler other) {
//         int dmg = (getDamage(other)*140+99)/100;
//         other.changeHealth(dmg);
//     }
    

// }
