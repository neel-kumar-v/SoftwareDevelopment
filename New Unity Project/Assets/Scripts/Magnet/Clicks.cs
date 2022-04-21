using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicks : MonoBehaviour
{
    public bool ready = false;
    public Vector3 clickPosition;
    public Camera cam;
    public float mouseClicks = 1f;


    public void AddClicks() {
        mouseClicks = mouseClicks + 1f;
    }

    public void Update() {
        if(Input.GetMouseButtonDown(0)) {
        AddClicks();

        Vector3 clickPosition = -Vector3.one;

        if(mouseClicks >= 3f) {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 5f));
            ready = true;
        }
        }
    }
}
