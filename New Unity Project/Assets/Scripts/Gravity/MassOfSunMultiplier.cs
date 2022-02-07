using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassOfSunMultiplier : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private Text text;
    // This curve is what makes the slider go from 0.1 - 1 in the first half and 1 - 10 in the second half
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Rigidbody rb;
    private float massMultiplier;

    private float originalMass;

    public void Start() {
        originalMass = rb.mass;
        SliderValChange();
    }

    
    public void SliderValChange() {
        massMultiplier = NormalizeSliderValue(slider.value);
        text.text = "The sun's mass is currently being multiplied by <b>" + massMultiplier.ToString("#.00") + "</b>";
        rb.mass = UpdateSunMass(massMultiplier);
    }

    public float UpdateSunMass(float multiplier) {
        return originalMass * massMultiplier;
    }

    public float NormalizeSliderValue(float sliderValue) { // The slider gives a value from 0-1, this normalizes it how we want it
        return curve.Evaluate(sliderValue);
    }

    public void Update() {
        if(!slider.interactable) {
            text.text = "You must press Start before you can edit the simulation!";
        } else {
            text.text = "The sun's mass is currently being multiplied by <b>" + massMultiplier.ToString("#.00") + "</b>";
        }
    }

}
