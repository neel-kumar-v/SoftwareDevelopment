using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchObject : MonoBehaviour
{
    public ObjectName[] objects;
    public Dropdown objDrop;
    public string objText;
    public Text accelText;
    public static GameObject savedObj;
    public static Rigidbody rb;
    
    public bool first;


    public void Start() {
        first = true;
        Replace();
    }

    public void DropdownUpdated() {        
        Replace();
    }

    public void Replace() {
        objText = objDrop.captionText.text;
        foreach(ObjectName obj in objects) { 
            if(obj.objectName == objText) {
                if(first) {
                    savedObj = Instantiate(obj.obj, obj.pos, obj.obj.transform.rotation);
                    first = false;
                    rb = savedObj.GetComponent<Rigidbody>();
                    return;
                }
                if(savedObj == null) return;
                Destroy(savedObj);
                savedObj = Instantiate(obj.obj, obj.pos, obj.obj.transform.rotation);
            }
        }
        rb = savedObj.GetComponent<Rigidbody>();
    }

    public void Send() {
        var script = savedObj.GetComponent<CarMovement>();
        if(script == null) {
            Debug.Log("Script wasn't found");
            return;
        }
        script.ButtonPlay();
    }
}
