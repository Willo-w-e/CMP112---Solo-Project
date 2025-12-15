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
        initialpos = transform.position;
        initialrot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void resetobject()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        transform.position = initialpos;
        transform.rotation = initialrot;
    }
}
