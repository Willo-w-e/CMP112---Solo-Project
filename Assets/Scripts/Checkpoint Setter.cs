using UnityEngine;


public class CheckpointSetter : MonoBehaviour
{
    private Vector3 position;
    public CheckpointController controller;
    bool end;

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
        position = other.transform.position;

        if (other.GetComponent<Collider>().CompareTag("endpoint"))
        {
            end = true;
        } else
        {
            end = false;
        }

            controller.SetRespawn(position, end);

    }
}
