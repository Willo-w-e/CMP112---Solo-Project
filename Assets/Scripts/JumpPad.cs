using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float strength = 10;

    public activator activator; //Link to the activator 

    public bool invert = false;

    bool totrigger = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (invert == true)
        {
            totrigger = false; //make the door open if activator is false if the invert is set to true
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }


    private void OnCollisionEnter(Collision other)
    {

        if (activator.active = totrigger)
        {

            if ((other.collider.CompareTag("detectable")) || (other.collider.CompareTag("player")))
            {

                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>(); //Set rigidbody to the rigidbody of the item colliding with it allowing me to use this with movable objects too

                if (rb != null) //Only tries to run if theres a rigidbody
                {
                    rb.AddForce(transform.up * strength, ForceMode.Impulse); //Im sure I remember being able to just have the force be an impulse by default but I couldnt find that in my old code
                } //I use transform.up so I can slant the launcher and still get a proper angle
            }
        }
    }
}
