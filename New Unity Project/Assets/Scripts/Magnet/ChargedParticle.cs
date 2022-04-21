using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedParticle : MonoBehaviour
{
    public float charge = 1;

    void Update() {
        UpdateColor();
    }
    
    public void UpdateColor() {
        Color color = charge > 0 ? Color.green : Color.red;
        GetComponent<Renderer>().material.color = color;
    }

    public void SetCharge(float newCharge) {
        charge = newCharge;
    }
}
