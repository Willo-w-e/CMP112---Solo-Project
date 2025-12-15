using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ResetObject : MonoBehaviour
{

    private Vector3 initialpos;
    private Quaternion initialrot;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        initialpos = transform.position; //Saves objects initial position
        initialrot = transform.rotation; //Saves objects initial rotation
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void resetobject()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero; //freeze! dont move!
            rb.angularVelocity = Vector3.zero; //freeze! dont move!
        }

        transform.position = initialpos; //Move there
        transform.rotation = initialrot; //rotate to original position, this isnt necessarily vital for the game as of now, but I plan to make the game bigger later after submission, and it'll be necessary then
    }
}
