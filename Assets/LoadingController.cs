using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    public Image loadingAnimationImage;
    public Sprite[] animationFrames;
    private int currentFrame;
    private float timer;
    public float frameRate = 0.1f; 
    void Start()
    {
        currentFrame = 0;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % animationFrames.Length;
            loadingAnimationImage.sprite = animationFrames[currentFrame];
            ++currentFrame;
        }
    }
}
