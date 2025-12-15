using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Vector3 respawn;
    public Transform start;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawn = start.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetRespawn(Vector3 position, bool end)
    {
        respawn = position;
    }
}
    

