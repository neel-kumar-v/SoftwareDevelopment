using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetVoltage : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private Slider slider;

    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    // This curve is what makes the slider go from 0.1 - 1 in the first half and 1 - 10 in the second half
    public float voltage;
    public OhmsGM gm;
    
    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("Voltage");
        voltage = slider.value;
        UpdateText();
        gm.VoltageChanged();
        UpdateVoltage(voltage);
    }

    public float UpdateVoltage(float add) {
        return voltage;
    }

    public void UpdateText() {
        text1.text = "The Voltage is <b>" + voltage.ToString("#.00") + "</b>";
        text2.text = "V = <b>" + voltage.ToString("#.00") + "</b>";
    }

    // public float NormalizeSliderValue(float sliderValue) { // The slider gives a value from 0-1, this normalizes it how we want it
    //     return curve.Evaluate(sliderValue);
    // }

    public void Update() {
        voltage = slider.value;
        UpdateText();
    }
}
