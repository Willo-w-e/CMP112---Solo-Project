using UnityEngine;


public class CheckpointSetter : MonoBehaviour
{
    private Vector3 position;
    public CheckpointController controller;
    bool end;
    public Transform start;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        

        if (CompareTag("endpoint")) //checks if the collider is the end room
        {
            position = start.position; //If collider is endrooms, set to the respawn point in room 0
        } else
        {
            position = other.transform.position; //Set to current position
        }

            controller.SetRespawn(position, end); //Sets position in the controller

    }
}   
