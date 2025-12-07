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
        Vector2 mouse = lookDelta * mouseSensitivity * Time.deltaTime;

        playerrotation.Rotate(Vector3.up * mouse.x);

        Rotation -= mouse.y;
        Rotation = Mathf.Clamp(Rotation, -90f, 90f);

        camerarotation.localRotation = Quaternion.Euler(Rotation, 0f, 0f);
    }

    public void OnRotation(InputValue value)
    {
        lookDelta = value.Get<Vector2>();
    }




}
