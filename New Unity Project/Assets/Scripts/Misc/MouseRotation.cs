using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    // Basically a multiplier for how much the mouse movement makes the camera rotate
    // In unity editor this value = 600
    public float mouseSpeed;
    // Keeps track of the rotation
    private float rotation = 0f;

    // A transform is the posituion, rotation, and scale of a thing, so basically the transform componenet in the editor
    // This one represents the player rotation, so that when the camera turns the player does with it
    public Transform playerTransform;

    // How smoothed out the smoothing is
    // I turned it off cuz it looked bad
    public float smoothSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Makes it so u don't see the cursor and the cursor can't hit the edge of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Used LateUpdate cuz if u don't it sometimes moves the camera when it shouldn;t, so this LateUpdate() j runs 1 frame after the Update() function
    void LateUpdate()
    {
        // Takes the mouse input and multiplies by multiplier
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        // For some reason, the x-rotation(side to side), and you just multiply the speed(mouseX) by a direction(Vector3.up)
        playerTransform.Rotate(Vector3.up * mouseX);

        //  This is for vertical rotation
        //  rotation is basically the negative of mouseY because Unity thinks the mouse going forward should make the camera go down
        rotation -= mouseY;
        // Makes it so ur player doesn;t have an owl neck and cant j keep rotating
        rotation = Mathf.Clamp(rotation, -90f, 90f);
        // I don't actually know what this does, but it does some Euler math and turns a Vector3(3 coords)[Here we only changing one part of the rotation b/c we had a float not a Vector3] into a Qauternion which Unity needs for rotation
        Quaternion target = Quaternion.Euler(rotation, 0f, 0f);
        // This code would round it - SLerp is just a smoothing function
        // Quaternion rounded = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smoothSpeed);
        // This code runs on the camera, so if we just did rotation, it would only change the camera rotation
        // So we use localRotation, which accesses the rotation of the parent object, and set it to the rotation
        transform.localRotation = target;


    }
}
