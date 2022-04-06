using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCharge : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private Text text;
    // This curve is what makes the slider go from 0.1 - 1 in the first half and 1 - 10 in the second half
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Rigidbody rb;
    private float chargeMultiplier;

    private float originalCharge;

    public void Start() {
        originalCharge = rb.GetComponent<ChargedParticle>().charge;
        SliderValChange();
    }

    
    public void SliderValChange() {
        chargeMultiplier = NormalizeSliderValue(slider.value);
        text.text = "The square's mass is currently <b>" + chargeMultiplier.ToString("#.00") + "</b>";
        rb.GetComponent<ChargedParticle>().charge = UpdateSquareCharge(chargeMultiplier);
    }

    public float UpdateSquareCharge(float add) {
        return chargeMultiplier;
    }

    public float NormalizeSliderValue(float sliderValue) { // The slider gives a value from 0-1, this normalizes it how we want it
        return curve.Evaluate(sliderValue);
    }

    public void Update() {
        if(!slider.interactable) {
            text.text = "You must press Start before you can edit the simulation!";
        } else {
            text.text = "The square's mass is currently <b>" + chargeMultiplier.ToString("#.00") + "</b>";
        }
    }
}
