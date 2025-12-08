using UnityEngine;

public class ProximityButton : MonoBehaviour
{

    public Material ActiveMat; //Containers for the 2 materials

    public Material InactiveMat;

    public bool valid;

    public int maxdistance = 10;

    Vector3 Origin;

    Vector3 Direction = Vector3.forward;

    public activator otherObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Origin = transform.position;

        Ray Sensor = new Ray(Origin, Direction); //Defines ray as moving from the position of the object, forward

        RaycastHit hit;

        if (Physics.Raycast(Sensor, out hit, maxdistance)) //Send out ray for max distance
        {

            if (hit.collider.CompareTag("detectable")) //Checks if the collided target is marked as detectable with tags
            {
                otherObject.active = true; //Sets the activator proxy to true
                this.GetComponent<MeshRenderer>().material = ActiveMat;
            }
            else
            {
                otherObject.active = false; //Sets the activator proxy to false if the collided object isnt marked as detectable
                this.GetComponent<MeshRenderer>().material = InactiveMat;
            }
        } 
        else
        {
            otherObject.active = false; //Sets the activator proxy to false if nothing is collided
            this.GetComponent<MeshRenderer>().material = InactiveMat;
        }



    }
}
