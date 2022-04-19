using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSelect : MonoBehaviour
{
    public float hoverMetallic;
    private Renderer rend;
    private float startMetallic;
    public bool isHovered;
    public bool isSelected;

    public void Start() {
        rend = GetComponent<Renderer>();
        startMetallic = rend.material.GetFloat("_Metallic");
    }

    void OnMouseEnter() {
        rend.material.SetFloat("_Metallic", hoverMetallic);
        isHovered = true;
    }
    void OnMouseExit() {
        rend.material.SetFloat("_Metallic", startMetallic);
        isHovered = false;
    }

    void OnMouseDown() {
        isSelected = true;
    }
    void OnMouseUp() {
        isSelected = false;
    }

    void Update() {
        if(isSelected) {
            Destroy(gameObject);
            transform.position = MousePosition.GetMousePosition(gameObject);
        }
    }

}
