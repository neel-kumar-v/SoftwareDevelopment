using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousePosition : MonoBehaviour
{
    public Camera cam;
    public GameObject selectedObj;
    public Text text;

    void Start()
    {
    }

    void Update()
    {
        // GetMousePosition(selectedObj);
    }

    public Vector3 GetMousePosition(GameObject selectedObject, bool select) {
        if(select) selectedObj = selectedObject;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) { 
            Vector3 mousePosition = new Vector3(hit.point.x, selectedObject.transform.localScale.y / 2, hit.point.z);
            Debug.DrawLine(ray.origin, mousePosition, Color.blue);
            return mousePosition;
        }
        return new Vector3(0f, 0f, 0f);

    }

    public void SetCharge(float charge) {
        if(selectedObj.CompareTag("Square")) {
            selectedObj.GetComponent<ChargedParticle>().charge = charge;
            text.text = charge.ToString("#.00");
        }
        else if(selectedObj.CompareTag("Sphere")) {
            selectedObj.GetComponent<MovingChargedParticle>().charge = charge;
            text.text = charge.ToString("#.00");
        }
    }

}
