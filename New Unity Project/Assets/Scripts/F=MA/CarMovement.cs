using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{

    public Vector3 originalPos;

    public Rigidbody car;
    public static float speed;

    public bool isPlaying;
    public static bool isPlayingStatic;


    void Start() {
        originalPos = car.transform.position;
        car = GetComponent<Rigidbody>();
        isPlaying = false;
    }

    void FixedUpdate() {
        if(!isPlaying) return;
        if((transform.position - originalPos).magnitude > 87f) {
            StartCoroutine(WaitReset(1f, "The car went far"));
        }
        if(car.velocity.x < 1f) {
            StartCoroutine(CheckSpeed());
        }
    }

    public void MoveCar() {
        car.AddForce(Vector3.right * speed, ForceMode.Impulse);
        isPlaying = true;
    }

    public IEnumerator CheckSpeed() {
        yield return new WaitForSeconds(0.001f);
        if(car.velocity.x < 1f) {
            StartCoroutine(WaitReset(0.25f, "The car went slow"));
        }
    }


    public IEnumerator WaitReset(float time, string reason) {
        Debug.Log(reason);
        if(!isPlaying || car.velocity.x > 1f) yield return null;
        yield return new WaitForSeconds(time);
        car.transform.position = originalPos;
        car.GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
        isPlaying = false;
    }

    public void ButtonPlay() {
        speed = ForceUIManager._force;
        if (isPlaying) {
            StartCoroutine(WaitReset(0f, "The Reset Button was pressed"));
        } else {
            MoveCar();

        }
    }

    public void Update() {
        isPlayingStatic = isPlaying;
        //test
    }
}

