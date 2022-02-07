using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject cam;
    public Vector3 pos; // Original position
    public Quaternion rot; // Original rotation
    public GameObject UI; // Normal UI
    public GameObject fadedUI; // Return to View button
    public static bool faded; // Keeps track fo the current UI State
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        rot = Quaternion.Euler(cam.transform.rotation.x, cam.transform.rotation.y, cam.transform.rotation.z);
        faded = false;
        FadeUI(true);
    }

    // Update is called once per frame
    void Update()
    {
        // X-Axis rotational difference
        float diffX = Mathf.Abs(cam.transform.rotation.x - rot.x);
        // Y-Axis rotational difference
        float diffY = Mathf.Abs(cam.transform.rotation.y - rot.y);
        // Since for some reason the default difference for x is 0.29, if its outside plus-minus 0.05, the camera moved
        bool rotXMoved = diffX > 0.35f || diffX < 0.25f;
        // y default is 0, so just 0.15 seemed to work best
        bool rotYMoved = diffY > 0.15f;
        // if the camera itself moved
        bool moved = Vector3.Distance(cam.transform.position, pos) > 1f;
        // If no movement has happened and the UI is faded
        if(!moved && !rotXMoved && !rotYMoved && faded) {
            FadeUI(true);
        } else if ((moved || rotXMoved || rotYMoved) && !faded) {
            FadeUI(false);
        }
    }

    public void FadeUI(bool fade) {
        Debug.Log(fade);
        UI.SetActive(fade);
        fadedUI.SetActive(!fade);     
        faded = !fade;
    }


}
