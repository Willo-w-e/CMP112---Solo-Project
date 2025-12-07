using UnityEngine;
using UnityEngine.InputSystem; 
public class PlayerMovement : MonoBehaviour
{

    PlayerInput playerInput;

    InputAction moveAction;

    [SerializeField] float speed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked; //Locks and hides the cursor for the Camera, this should probably be in PlayerRotation but it doesnt matter either way
        Cursor.visible = false;

        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }
        
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 input = moveAction.ReadValue<Vector2>(); //Takes the X and Y input from the input currently triggering the move action

        Vector3 move = (transform.right * input.x + transform.forward * input.y); //Creates a Vector3 using the X and Y from the previous Vector 2 

        transform.position += move * speed * Time.deltaTime; //Move by the previous Vector 3

        //This allows the player to move in the direction they're facing changing WASD dynamically and not just being the X and Y axis 
    }
}
