using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityGameManager : MonoBehaviour
{
    
    public List<Vector3> originalPositions; // Keeps track of all the planets' original pos
    [HideInInspector] public GameObject[] planets;
    public SolarSystem solarSystem;
    public static bool play;
    
    public Text text;
    public Slider slider;
    public void Start()
    {
        slider.interactable = false; // The user can only change the gravity once the sim has started
        play = false;
        planets = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject planet in planets) { // Adds all the original positions to the list
            originalPositions.Add(planet.transform.position);
        }
        Time.timeScale = 0f; // Keep the sim paused until they press play
    }

    public void Play() {
        text.text = "PLAY";
        slider.interactable = true; // Allow them to change gravity

        Time.timeScale = 1f; // Unpause game

        solarSystem.InitialVelocity(); // Run the gravity calculations
    } 

    public void Reset() {
        text.text = "RESET";
        slider.interactable = false; // Since the game is back to being paused, disable slider again

         for (int i = 0; i < planets.Length; i++) { // Return every planet to their original positions
            planets[i].transform.position = originalPositions[i];
            planets[i].GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            
            TrailRenderer rend = planets[i].GetComponent<TrailRenderer>();

            if (rend != null) { // Clear the trails b/c otherwise it looks weird
                rend.Clear();
            }
        }

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
