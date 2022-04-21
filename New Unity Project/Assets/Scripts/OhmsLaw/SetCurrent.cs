using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetCurrent : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private Slider slider;

    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    // This curve is what makes the slider go from 0.1 - 1 in the first half and 1 - 10 in the second half

    public float current;
    public OhmsGM gm;

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("Current");
        current = slider.value;
        UpdateText();
        gm.CurrentChanged();
        UpdateCurrent(current);
    }

    public float UpdateCurrent(float add) {
        return current;
    }

    public void UpdateText() {
        text1.text = "The current is <b>" + current.ToString("#.00") + "</b>";
        text2.text = "I = <b>" + current.ToString("#.00") + "</b>";
    }

    // public float NormalizeSliderValue(float sliderValue) { // The slider gives a value from 0-1, this normalizes it how we want it
    //     return curve.Evaluate(sliderValue);
    // }

    // public float DenormalizeSliderValue(float normalizedSliderValue) {
    //     return denormalizeCurve.Evaluate(normalizedSliderValue);
    // }

    public void Update() {
        current = slider.value;
        UpdateText();
    }
}