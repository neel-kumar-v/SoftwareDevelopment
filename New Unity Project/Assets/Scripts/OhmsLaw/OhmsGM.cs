using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

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

    public float current;

    public float voltage;

    public float resistance;

    private bool done;



    public bool changed1 = false;
    public bool changed2 = false;
    public bool changed3 = false;
    public List<string> array;
    public string typetoSet;




    // public void AddToArray(string name) {
    //     if(array.Count == 0) {
    //         array.Insert(0, name);
    //     } else if(array.Count == 1) {
    //         if(array[0] == name) return;
    //         array.Insert(0, name);
    //         Check();
    //     } else if(array.Count == 2) {
    //         if(array[0] != name) {
    //             if(array[1] == name) {
    //                 string temp = array[1];
    //                 array[1] = array[0];
    //                 array[0] = temp;
    //             }
    //             array.Insert(0, name);
    //             array.RemoveAt(2);
    //             Check();
    //         }
            
    //     }
    // }

    public void VoltageChanged() {
        array.Insert(0, "Voltage");
        done = false;
    }

    public void ResistanceChanged() {
        array.Insert(0, "Resistance");
        done = false;
    }

    public void CurrentChanged() {
        array.Insert(0, "Current");
        done = false;
    }

    public void Reset() {
        for (int i = array.Count - 1; i >= 0 ; i--)
        {
            array.RemoveAt(i);
        }
    }

    public void Update() {
        if(done) return;
        Check();
    }

    // public void LateUpdate() {
    //     var lastZero2 = text2.text.LastIndexOf('0');
    //     Debug.Log(lastZero2);
    //     Debug.Log(text2.text.Length.ToString());
    //     if(voltage > float.Parse(text2.text.Substring(14, lastZero2))) {
    //         text2.text = "The Voltage is <b>" + voltage.ToString("#.00") + "</b>";
    //         text3.text = "V = <b>" + voltage.ToString("#.00") + "</b>";
    //     }
    //     var lastZero4 = text4.text.LastIndexOf('0');
    //     if(resistance > float.Parse(text4.text.Substring(17, lastZero4))) {
    //         text4.text = "The Resistance is <b>" + resistance.ToString("#.00") + "</b>";
    //         text5.text = "R = <b>" + resistance.ToString("#.00") + "</b>";
    //     }
    //     var lastZero6 = text6.text.LastIndexOf('0');
    //     if(resistance > float.Parse(text6.text.Substring(14, lastZero6))) {
    //         text6.text = "The Current is <b>" + current.ToString("#.00") + "</b>";
    //         text7.text = "I = <b>" + current.ToString("#.00") + "</b>";
    //     }
    // }

    public void Check() {

        if(array.Count == 3){
            array.RemoveAt(2);
        }

        if(array.Contains("Voltage")) {
            if(array.Contains("Resistance")) {
                current = (slider1.GetComponent<SetVoltage>().voltage / slider2.GetComponent<SetResistance>().resistance);
                Debug.Log(current);
                
                slider3.value = current;
                done = true;
            } else if (array.Contains("Current")) {
                resistance = (slider1.GetComponent<SetVoltage>().voltage / slider3.GetComponent<SetCurrent>().current);
                Debug.Log(resistance);
                slider2.value = resistance;
                done = true;
            }
        } else if(array.Contains("Resistance")) {
            if (array.Contains("Current")) {
                voltage = (slider2.GetComponent<SetResistance>().resistance * slider3.GetComponent<SetCurrent>().current);
                Debug.Log(voltage);
                
                slider1.value = voltage;
                done = true;
            }
        }




            
    //     //go through the array of elements and set the value of whatever is not set.
    //     List<string> possibleArray = new List<string>();
        
    //     possibleArray.Insert(0,  "Voltage");
    //     possibleArray.Insert(0, "Current");
    //     for (int i = 0; i < array.Count - 1; i++) // finds the variable that is not set currently
    //     {
    //         if(possibleArray.Contains(array[i])) {
    //             possibleArray.Remove(array[i]);   
    //             Debug.Log(array[i]);
    //         }
    //     }
    //     typetoSet = possibleArray[0];
    //     if(possibleArray[0] == "Current") { // we know that voltage and resistance have been set more recently
    //         current = (slider1.GetComponent<SetVoltage>().voltage / slider2.GetComponent<SetResistance>().resistance);
    //         text6.text = "The Current is <b>" + (current).ToString("#.00") + "</b>";
    //         text7.text = "I = <b>" + (current).ToString("#.00") + "</b>";
    //         slider3.value = slider3.GetComponent<SetCurrent>().DenormalizeSliderValue(current);
    //     }
    //     if(possibleArray[0] == "Voltage") {
    //         voltage = (slider2.GetComponent<SetResistance>().resistance * slider3.GetComponent<SetCurrent>().current);
    //         text2.text = "The Voltage is <b>" + (voltage).ToString("#.00") + "</b>";
    //         text3.text = "V = <b>" + (voltage).ToString("#.00") + "</b>";
    //         slider1.value = (voltage);
    //     }
    //     if(possibleArray[0] == "Resistance") {
    //         resistance = (slider1.GetComponent<SetVoltage>().voltage / slider3.GetComponent<SetCurrent>().current);
    //         text4.text = "The Resistance is <b>" + (resistance).ToString("#.00") + "</b>";
    //         text5.text = "R = <b>" + (resistance).ToString("#.00") + "</b>";
    //         slider2.value = (resistance);
    //     }
    // }
}
}
