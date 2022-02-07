using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{   
    Rigidbody rb;
    Vector3 Vec;  
    // Start is called before the first frame update  
    void Start()  
    {  
        rb = GetComponent<Rigidbody>();  
    }  
  
    // Update is called once per frame  
    void Update()  
    {  
        
        if(BallLauncher.isShot) {
            return;
        }
        Vec = rb.velocity;  
        Vec.y += Input.GetAxis("Jump") * Time.deltaTime * 20;  
        Vec.x -= Input.GetAxis("Horizontal") * Time.deltaTime * 20;  
        Vec.z -= Input.GetAxis("Vertical") * Time.deltaTime * 20;
        rb.AddForce(Vec - rb.velocity, ForceMode.VelocityChange); 


    }
}
