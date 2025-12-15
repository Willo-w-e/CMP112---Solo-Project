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
        

        if (CompareTag("endpoint"))
        {
            position = start.position;
        } else
        {
            position = other.transform.position;
        }

            controller.SetRespawn(position, end);

    }
}   
