using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OhmsGM : MonoBehaviour
{
    // Voltage
    [SerializeField] public Slider slider1;

    // Resistance
    [SerializeField] public Slider slider2;

    // Current
    [SerializeField] public Slider slider3;

    // For Voltage
    [SerializeField] public Text text2;
    [SerializeField] public Text text3;

    // For Resistance
    [SerializeField] public Text text4;
    [SerializeField] public Text text5;

    // For Current
    [SerializeField] public Text text6;
    [SerializeField] public Text text7;

    private float current;

    private float voltage;

    private float resistance;

    public bool changed1 = false;
    public bool changed2 = false;
    public bool changed3 = false;

    public void Start()
    {
        slider1.interactable = true; // The user can only change the gravity once the sim has started
        slider2.interactable = true;
        slider3.interactable = true;

        slider1.value = 0;
        slider2.value = 0;
        slider3.value = 0;
    }

    public void Update() {
        slider1.interactable = true;
        slider2.interactable = true;
        slider3.interactable = true;

        Check();
    }

    public void Check() {
         if (slider1.value > 0 && slider2.value > 0) {
            current = (slider1.GetComponent<SetVoltage>().voltage / slider2.GetComponent<SetResistance>().resistance);
            Debug.Log("A:" + current);
            text6.text = "The Current is <b>" + (current).ToString("#.000") + "</b>";
            text7.text = "I = <b>" + (current).ToString("#.00") + "</b>";
            slider3.value = (current);
        } else if (slider1.value > 0 && slider3.value > 0) {
            resistance = (slider1.GetComponent<SetVoltage>().voltage / slider3.GetComponent<SetCurrent>().current);
            Debug.Log("B:" + resistance);
            text4.text = "The Resistance is <b>" + (resistance).ToString("#.00") + "</b>";
            text5.text = "R = <b>" + (resistance).ToString("#.00") + "</b>";
            slider2.value = (resistance);
        } else if (slider2.value > 0 && slider3.value > 0) {
            voltage = (slider2.GetComponent<SetResistance>().resistance * slider3.GetComponent<SetCurrent>().current);
            Debug.Log("C:" + voltage);
            text2.text = "The Voltage is <b>" + (voltage).ToString("#.00") + "</b>";
            text3.text = "V = <b>" + (voltage).ToString("#.00") + "</b>";
            slider1.value = (voltage);
        }
    }
}
