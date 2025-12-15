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
            instance = this;
        }

        resettargets = Object.FindObjectsByType<ResetObject>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    public void ResetWorldState()
    {
        foreach (var obj in resettargets)
        {
            obj.resetobject();
        }

        player.position = checkpoints.respawn;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");
            ResetWorldState();
        }
    }
}
