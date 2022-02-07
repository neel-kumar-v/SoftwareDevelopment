using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    readonly float G = 100f; // Gravity constant
    private GameObject[] planets; 
    public GameObject sun;
    
    // Start is called before the first frame update
    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
    }

    private void FixedUpdate() { // FixedUpdate is used for physics
        Gravity();
    }

    public void Gravity() {
        foreach(GameObject a in planets) { // For each planet
            foreach(GameObject b in planets) { // Apply the gravities from all of the planets near it
                if (!a.Equals(b)) { // As long as the first plaent isnt the same one as the second planet
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }


    public void InitialVelocity() { // This gives each of the planet the required sideways force to start an orbit using the same things as for gravity.
        foreach(GameObject a in planets) {
            foreach(GameObject b in planets) {
                if (!a.Equals(b)) {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / r);
                }
            }
        }
    }
}
