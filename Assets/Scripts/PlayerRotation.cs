using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVertical = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mosue X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraVertical -= inputY;
        cameraVertical = Mathf.Clamp(cameraVertical, -90f, 90f);

        transform.localEulerAngles = Vector3.right * cameraVertical;
    }
}
