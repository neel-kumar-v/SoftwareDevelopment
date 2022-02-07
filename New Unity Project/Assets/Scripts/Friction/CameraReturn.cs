using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

[RequireComponent(typeof(SimpleCameraController))]
public class CameraReturn : MonoBehaviour
{
    public Vector3 pos;
    public Quaternion rot;

    public SimpleCameraController controller;


    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(0f, 44.344f, -58.35f);
        rot = Quaternion.Euler(35f, 0f, 0f);
        // timeCount = 0f;
    }



    public void ButtonPressed(Transform transform) {
        // Disable the camera controller script so that this thing works
        controller.enabled = false;
        transform.SetPositionAndRotation(pos, rot);
        controller.enabled = true;

    }


}
