using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagneticGM : MonoBehaviour
{
    public Vector3 originalPosition; // Keeps track of all the planets' original pos
    public Rigidbody square;
    public static bool play;
    
    public Text text;
    public Slider slider;

    public void Start()
    {
        slider.interactable = true; // The user can only change the gravity once the sim has started
        play = false;
        originalPosition = square.transform.position;
        Time.timeScale = 0f; // Keep the sim paused until they press play
    }

    public void Play() {
        text.text = "PLAY";
        slider.interactable = false; // Allow them to change gravity
        Time.timeScale = 1f; // Unpause game
    } 

    public void Reset() {
        text.text = "RESET";
        slider.interactable = true; // Since the game is back to being paused, disable slider again

    
            square.transform.position = originalPosition;
            square.velocity = new Vector3(0f, 0f, 0f);
        

        Time.timeScale = 0f; // Pause
    }

    public void ButtonPlay() {
        play = !play;
        if(play) {
            Play();
        } else {
            Reset();
        }
    }
}
