using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonDisable : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    public Text forceText;

    bool play;
    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        play = CarMovement.isPlayingStatic;
        buttonText.text = play ? "Reset" : "Play";
        if(forceText.text == "") return;
        button.interactable = true;
    }
}
