using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    public Transform playerrotation;
    public Transform camerarotation;

    public float mouseSensitivity = 100f;

    private Vector2 lookDelta;
    private float Rotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = lookDelta * mouseSensitivity * Time.deltaTime; //Creates a readable vector of the mouses movement delta

        playerrotation.Rotate(Vector3.up * mouse.x); //Rotates the player based off the x of the mouses movement delta

        Rotation -= mouse.y; //Sets rotation to the mouses movement delta on the Y axis
        Rotation = Mathf.Clamp(Rotation, -90f, 90f); //Prevents the camera from breaking your neck, cause that would be BAD by clamping the angle between 90 and -90

        camerarotation.localRotation = Quaternion.Euler(Rotation, 0f, 0f); //Does the rotation on the camera
    }

    public void OnRotation(InputValue value)
    {
        lookDelta = value.Get<Vector2>(); //Updates lookdelta to current mouse location
    }




}
