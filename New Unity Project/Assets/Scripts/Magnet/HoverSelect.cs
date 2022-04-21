using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSelect : MonoBehaviour
{
    public float hoverMetallic;
    private Renderer rend;
    private float startMetallic;
    [HideInInspector] public bool isHovered;
    [HideInInspector] public bool isSelected;
    public static bool switched;
    public bool isSwitched;



    public MousePosition mousePosition;

    public void Start() {
        rend = GetComponent<Renderer>();
        mousePosition = GameObject.FindObjectOfType<MousePosition>();
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

    public void OnMouseDown() {
        isSelected = true;
    }
    public void OnMouseUp() {
        isSelected = false;
    }

    void Update() {
        if(isSelected && isSwitched) {
            // if(GetComponent<Clicks>().ready == true) {
            transform.position = mousePosition.GetMousePosition(gameObject, true);
            // }
        }
    }
}
