using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    [SerializeField] private List<GameObject> wheels;

    private Rigidbody rb;

    float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationSpeed = rb.velocity.x * 10f;
    }

    public void SetSpinSpeed() {
        for (int i = 0; i < wheels.Count; i++)
        {
            wheels[i].transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
