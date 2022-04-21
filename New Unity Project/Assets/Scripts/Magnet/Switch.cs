using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public static bool switchCam;
    public Vector3 originalPos;
    public Quaternion originalRot;

    public Camera cam;

    public GameObject simUI;
    public GameObject buildUI;

    public Vector3 newPos;
    public Quaternion newRot;

    private Vector3 velocity = Vector3.zero;
    private Vector3 velocity2 = Vector3.zero;
    public float smoothSpeed;

    public Button switchButton;

    Vector3 targetPos;
    Quaternion targetRot;

    public void Start() {
        switchCam = false;
        originalPos = cam.transform.position;
        originalRot = cam.transform.localRotation;

        newPos = new Vector3(26f,35f,-16.6230698f);
        newRot = new Quaternion(0.707106709f,0f,0f,0.707106888f);
    }     
     
    public void CamUp() {
        Time.timeScale = 1f;
        cam.transform.localPosition =  newPos;
        cam.transform.localRotation = newRot;
        buildUI.SetActive(true);
        simUI.SetActive(false);
        switchButton.GetComponentInChildren<Text>().text = "Sim";
        Time.timeScale = 0f;
    }

    public void Reset() {
        Time.timeScale = 1f;
        cam.transform.localPosition = originalPos;
        cam.transform.localRotation = originalRot;
        buildUI.SetActive(false);
        simUI.SetActive(true);
        switchButton.GetComponentInChildren<Text>().text = "Build";
        Time.timeScale = 0f;
    }

    public void ButtonSwitch() {
        switchCam = !switchCam;
        
        if(switchCam) {
            CamUp();
        } else {
            Reset();
        }
    }

    public void Update() {
        HoverSelect[] hoverSelects = GameObject.FindObjectsOfType<HoverSelect>();
        foreach(HoverSelect hoverSelect in hoverSelects) {
            hoverSelect.isSwitched = switchCam;
        }
    }
}
