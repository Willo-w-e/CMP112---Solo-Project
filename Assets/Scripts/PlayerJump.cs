using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{

    public int jumpheight = 1;
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
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpheight, rb.linearVelocity.z);
    }
}
