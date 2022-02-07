using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    [Range(0f, 1f)]
    public float smoothSpeed;

    public Vector3 offset;

    void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, 10 * smoothSpeed * Time.deltaTime);

        transform.LookAt(player);
    }
}