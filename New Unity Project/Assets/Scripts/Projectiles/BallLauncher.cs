using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{

    public Rigidbody ball;
    public Transform target;

    public float h = 25;
    public float gravity = -18;

    public bool debugPath;

    public LineRenderer line;
    [Range(0, 2)] public float lineLength;

    public static bool isShot;

    public float arc;


    void Start() {
        ball.useGravity = false;
        isShot = false;
    }

    void Update() {
        if (Input.GetKeyDown (KeyCode.Space) && !isShot) {
            Launch();
        }
        
        if (debugPath) {
            DrawPath();
        }

        line.enabled = !isShot;
    }

    void Launch() {
        ball.velocity = new Vector3(0f, 0f, 0f);
        StartCoroutine(LaunchC(0.5f));
    }

    IEnumerator LaunchC(float time) {
        yield return new WaitForSeconds(time);
        Physics.gravity = Vector3.up * gravity;
        ball.useGravity = true;
        LaunchData data = CalculateLaunchData();
        ball.velocity = data.initialVelocity;
        isShot = true;
        StartCoroutine(DisableShoot(data.timeToTarget));
    }

    IEnumerator DisableShoot(float time) {
        yield return new WaitForSeconds(time);
        isShot = false;
    }

    LaunchData CalculateLaunchData() {
        float displacementY = target.position.y - ball.position.y + 1f;
        Vector3 displacementXZ = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);
        float time = Mathf.Sqrt(Mathf.Abs((-2 * h / gravity))) + Mathf.Sqrt(Mathf.Abs((2 * (displacementY - h) / gravity)));
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(Mathf.Abs((-4 * gravity * h)));
        Vector3 velocityXZ = (displacementXZ / time) / arc;

        return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), lineLength * time);
    }

    void DrawPath() {
        LaunchData launchData = CalculateLaunchData();
        Vector3 previousDrawPoint = ball.position;
        for (int i = 1; i <= line.positionCount; i++) {
            float simulationTime = i / (float)line.positionCount * launchData.timeToTarget;
            Vector3 displacement = (launchData.initialVelocity * simulationTime) + (Vector3.up * gravity * simulationTime * simulationTime / 2f);
            Vector3 drawPoint = ball.position + displacement;
            line.SetPosition(i-1, drawPoint);
            previousDrawPoint = drawPoint;
        }
    }

    struct LaunchData {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;

        public LaunchData(Vector3 initialVelocity, float timeToTarget) {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }

    }
}
