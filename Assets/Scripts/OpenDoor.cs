using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public activator otherObject; //Link to the activator 

    

    private bool initialstate;

  
 
    public Material closedMat; //Containers for the 2 materials

    public Material openedMat;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (otherObject.active == true)
        {
            this.GetComponent<Collider>().enabled = false; //Disables the doors collider letting you pass through it
            this.GetComponent<MeshRenderer>().material = openedMat; //Sets door mat to a transparent texture I made
        }
        else
        {
            this.GetComponent<Collider>().enabled = true; //Re-enables the doors collider 
            this.GetComponent<MeshRenderer>().material = closedMat; //Sets door mat to a solid texture
        }
    }
}
