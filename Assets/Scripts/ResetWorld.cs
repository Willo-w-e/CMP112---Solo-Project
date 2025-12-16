using UnityEngine;

public class ResetWorld : MonoBehaviour
{
    public static ResetWorld instance;

    private ResetObject[] resettargets;

    private ButtonPress[] buttons;

    public CheckpointController checkpoints;

    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this; //Make instance
        }

         //Find all objects with ResetObject script
    }

    // Update is called once per frame
    public void ResetWorldState()
    {
        resettargets = Object.FindObjectsByType<ResetObject>(FindObjectsSortMode.None); //Find all moveable objects

        buttons = Object.FindObjectsByType<ButtonPress>(FindObjectsSortMode.None); //Find all buttons

        foreach (var obj in resettargets) //Go through all moveable objects
        {
            obj.resetobject(); //resets moveable object in that spot of the array
        }

        foreach (var obj in buttons) //Go through all buttons
        {
            obj.ResetButton(); //resets button in that spot of the array
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
