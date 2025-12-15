using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{

    public int jumpheight = 1; //Base jumpheight 
    public Rigidbody rb;
    private bool jump = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ground")) //Checks if on the ground
        {
            jump = true; //if on ground, allow jump
        }
    }

    void OnJump()
    {
        if (jump == true)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpheight, rb.linearVelocity.z); //Lowk not that much to this, just add new linear velocity to the players rigid body while maintaining the horizontal velocities from movement while adding jump height allowing for smooth jumps 
            jump = false;
        }
    }
}
