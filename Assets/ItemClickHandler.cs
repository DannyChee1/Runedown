using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemClickHandler : MonoBehaviour
{
    public KeyCode _Key;
    private Button _button;
    public Animator animator;

    void Awake() {
        _button = GetComponent<Button>();
    }
    void Update() {
        if(Input.GetKeyDown(_Key)) {
            FadeToColor(_button.colors.pressedColor);
            _button.onClick.Invoke();
            print("clicked");
        }
        else if(Input.GetKeyUp(_Key))
            FadeToColor(_button.colors.normalColor);
    }
    void FadeToColor(Color color) {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, _button.colors.fadeDuration, true, true);
    }
    public void onClick() {
        print("clicked");
    }
}
