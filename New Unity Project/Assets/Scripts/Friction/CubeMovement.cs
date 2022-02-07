using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMovement : MonoBehaviour
{
    // Saves the original position
    private Vector3 originalPos;

    private Rigidbody cube;
    public float speed;

    // isCubeInMotion keeps track of whether the cube is currently in motion or not
    private bool isCubeInMotion;
    // If other scripts need to access this variable
    public static bool isCubeInMotionStatic;

    public Text text;


    void Start() {
        cube = GetComponent<Rigidbody>();
        originalPos = cube.transform.position;
        isCubeInMotion = false;
    }

    void FixedUpdate() {
        if(!isCubeInMotion) return;
        if((transform.position - originalPos).magnitude > 87f) {
            StartCoroutine(ResetCoroutine(1f, "The cube went far"));
        }
        if(cube.velocity.x < 0.5f) {
            StartCoroutine(DoubleCheckSpeed());
        }
    }

    public void Move() {
        cube.AddForce(Vector3.right * speed * cube.mass, ForceMode.Impulse);
        isCubeInMotion = true;
    }

    public IEnumerator DoubleCheckSpeed() {
        // Checks the cubes velocity again after 0.001 sseconds
        // This is because when the cube starts, its velocity is low, but we don't want to reset it
        yield return new WaitForSeconds(0.001f);
        if(cube.velocity.x < 1f) {
            StartCoroutine(ResetCoroutine(0.5f, "The cube went slow"));
        }
    }


    public IEnumerator ResetCoroutine(float time, string reason) {
        // For debugging purposes, I added a reason so in the console you can see why the cube's position was reset
        Debug.Log(reason);
        if(!isCubeInMotion || cube.velocity.x > 1f) yield return null;
        yield return new WaitForSeconds(time);
        cube.transform.position = originalPos; // Reset position
        cube.GetComponent<Rigidbody>().velocity = Vector3.zero; // Reset velocity
        isCubeInMotion = false; // The cube is no longer in motion
    }

    public void ButtonPlay() {
        // Sets up the toggle functionality where one button can have two functions based on the current state
        if (isCubeInMotion) {
            StartCoroutine(ResetCoroutine(0f, "The Reset Button was pressed"));
        } else {
            Move();
        }
    }

    public void Update() {
        isCubeInMotionStatic = isCubeInMotion;
        text.text = isCubeInMotion ? "Reset" : "Play"; 
    }
}
