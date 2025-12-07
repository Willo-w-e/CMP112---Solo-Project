using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{

    public int jumpheight = 1; //Base jumpheight 
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnJump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpheight, rb.linearVelocity.z); //Lowk not that much to this, just add new linear velocity to the players rigid body while maintaining the horizontal velocities from movement while adding jump height allowing for smooth jumps 
    }
}
