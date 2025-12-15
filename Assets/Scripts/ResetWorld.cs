using UnityEngine;

public class ResetWorld : MonoBehaviour
{
    public static ResetWorld instance;

    private ResetObject[] resettargets;

    public CheckpointController checkpoints;

    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this; //Make instance
        }

        resettargets = Object.FindObjectsByType<ResetObject>(FindObjectsSortMode.None); //Find all objects with ResetObject script
    }

    // Update is called once per frame
    public void ResetWorldState()
    {
        foreach (var obj in resettargets) //Go through all objects
        {
            obj.resetobject(); //resets object in that spot of the array
        }

        player.position = checkpoints.respawn; //Move player to respawn loction
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetWorldState(); //Reset
        }
    }
}
