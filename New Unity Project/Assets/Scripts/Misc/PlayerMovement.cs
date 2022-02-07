using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Just here so the player starts at the same spot every time
    public Vector3 startPos;
    // The amount it accelerates by for moving or rotating
    public float speed;
    // How high it can jump
    public float jumpHeight;
    // WIll represent if the player is on the ground to jump again
    private bool canJump;

    // Character Controller is the thing that makes it easy for playermovenent 
    public CharacterController characterController;

    // Keeps track of current velocity
    Vector3 velocity;
    // gravity
    public float gravityForce = -9.81f;
    // where the ground is so we can check if the player is on the ground
    public Transform ground;
    // The distance from the ground where the player can't jump because the checkSphere thing has the ground in its radius
    public float groundDistance = 0.1f;
    // Layers are things u just make so you can sort different things
    // In the editor, I made a Layer called Ground, and then set the LayerMask to only check for objects in ground
    // Then made the ground object the layer of ground
    public LayerMask groundMask;

    void Start()
    {
        // Set the position
        transform.position = startPos;
    }

    void Update()
    {
        // Physics.CheckSphere returns a bool of whether a point or object is in within a sphere of a given radius
        // It takes in the position thing, ground distance for the radius of the sphere, and which objects to check for
        canJump = Physics.CheckSphere(ground.position, groundDistance, groundMask);

        // Since there is a bit of a gap when the character is still in the air(velocity.y < 0)
        // And the sphere check returns true(canJump)
        // Set the velocity to -5f as a default so the velocity doesn't keep going fown forever(u'll see at the end of the code)
        if(canJump && velocity.y < 0) {
            velocity.y = -5f;
        }

        // get the input movement from the WASD keys
        float sidewaysMovement = Input.GetAxis("Horizontal");
        float forwardMovement = Input.GetAxis("Vertical");

        // Transform.right just means right of the player, so if sidewaysMovement > 0, the player will move right, and if < 0, move left
        // It is multiplied by Time.deltaTime bc the speed shouldn;t change based on ur fps(remember update runs every frame), and Tie.deltaTime stops that, idk how tho
        // Multiply by the speed multiplier
        Vector3 movementVector = (transform.right * sidewaysMovement + transform.forward * forwardMovement) * Time.deltaTime * speed;

        // Tell the character controller to move the player in that direction in that speed that we j calc
        characterController.Move(movementVector);

        // If you can jump and press space to jump
        if(Input.GetKeyDown(KeyCode.Space) && canJump) {
            // Set upwards velocity to this equation that basically does gravity math, i j googled the equation
            // But i think basically the -2f * gravity makes it so that the velocity we take away is canceled out and we still have 9.81 going up * then we multiply that with how high we wanna go, and the square root makes it so its a curve and not a a linear jump, which would feel weird
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityForce);
        }
        // Make the player move down based on gravity - now you see if we didn;t have the if-statement above, the negative velocity would j keep going lower and lower so if we jumped the velocity would send us back down immediately
        velocity.y += gravityForce * Time.deltaTime;
        // Make the character move up
        characterController.Move(velocity* Time.deltaTime);
    }

    // This just so i could show the sphere and what its checking
    // void OnDrawGizmosSelected() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(ground.position, groundDistance);
    // }
}
