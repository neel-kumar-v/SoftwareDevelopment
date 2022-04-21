using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetResistance : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private Slider slider;

    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    // This curve is what makes the slider go from 0.1 - 1 in the first half and 1 - 10 in the second half
    public float resistance;
    public OhmsGM gm;
    
    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("Resistance");
        resistance = slider.value;
        UpdateText();
        gm.ResistanceChanged();
        UpdateResistance(resistance);
    }

    public float UpdateResistance(float add) {
        return resistance;
    }

    public void UpdateText() {
        text1.text = "The resistance is <b>" + resistance.ToString("#.00") + "</b>";
        text2.text = "R = <b>" + resistance.ToString("#.00") + "</b>";
    }

    // public float NormalizeSliderValue(float sliderValue) { // The slider gives a value from 0-1, this normalizes it how we want it
    //     return curve.Evaluate(sliderValue);
    // }

    public void Update() {
        resistance = slider.value;
        UpdateText();
    }
}
