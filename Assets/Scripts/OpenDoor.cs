using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public activator otherObject;

    public bool active;

    private bool initialstate;

  
 
    public Material closedMat;

    public Material openedMat;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialstate = active;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<MeshRenderer>().material = openedMat;
        }
        else
        {
            this.GetComponent<Collider>().enabled = true;
            this.GetComponent<MeshRenderer>().material = closedMat;
        }

        if (otherObject.active == true)
        {
            active = !initialstate;
        }
    }
}
