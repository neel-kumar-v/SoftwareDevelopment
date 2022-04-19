using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCurrent : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    // This curve is what makes the slider go from 0.1 - 1 in the first half and 1 - 10 in the second half
    [SerializeField] private AnimationCurve curve;
    public float current;

    public void SliderValChange() {
        current = NormalizeSliderValue(slider.value);
        text1.text = "The current is <b>" + current.ToString("#.00") + "</b>";
        text2.text = "I = <b>" + current.ToString("#.00") + "</b>";
        UpdateCurrent(current);
    }

    public float UpdateCurrent(float add) {
        return current;
    }

    public float NormalizeSliderValue(float sliderValue) { // The slider gives a value from 0-1, this normalizes it how we want it
        return curve.Evaluate(sliderValue);
    }

    public void Update() {
        text1.text = "The current is <b>" + current.ToString("#.00") + "</b>";
        SliderValChange();
    }
}