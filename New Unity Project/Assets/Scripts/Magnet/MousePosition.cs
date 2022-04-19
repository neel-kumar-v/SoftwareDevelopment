using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] public static Camera cam;
    public GameObject selectedObj;
    void Start()
    {
    }

    void Update()
    {
        GetMousePosition(selectedObj);
    }

    public static Vector3 GetMousePosition(GameObject selectedObject) {
        if(selectedObject == null) return new Vector3(0f, 0f, 0f);  
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) { 
            Vector3 mousePosition = new Vector3(hit.point.x, selectedObject.transform.localScale.y / 2, hit.point.z);
            Debug.DrawLine(ray.origin, mousePosition, Color.blue);
            return mousePosition;
        }
        return new Vector3(0f, 0f, 0f);

    }

}
