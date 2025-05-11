using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mana : MonoBehaviour
{
    public Slider slider;
    
    public void SetMana(int mana) {
        slider.value = mana;
    }
}
