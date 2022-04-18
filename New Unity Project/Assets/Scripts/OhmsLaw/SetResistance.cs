using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResistance : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    // This curve is what makes the slider go from 0.1 - 1 in the first half and 1 - 10 in the second half
    [SerializeField] private AnimationCurve curve;
    public float resistance;

    public void Start() {
        SliderValChange();
    }
    
    public void SliderValChange() {
        resistance = NormalizeSliderValue(slider.value);
        text1.text = "The resistance is <b>" + resistance.ToString("#.00") + "</b>";
        text2.text = "R = <b>" + resistance.ToString("#.00") + "</b>";
        UpdateResistance(resistance);
    }

    public float UpdateResistance(float add) {
        return resistance;
    }

    public float NormalizeSliderValue(float sliderValue) { // The slider gives a value from 0-1, this normalizes it how we want it
        return curve.Evaluate(sliderValue);
    }

    public void Update() {
        text1.text = "The resistance is <b>" + resistance.ToString("#.00") + "</b>";
    }
}
