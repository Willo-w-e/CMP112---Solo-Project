using System.Collections.Generic;
using UnityEngine;

public class PushPad : MonoBehaviour
{
    public activator activator;

    public Material ActiveMat;
    public Material InactiveMat;

    public bool invert = false;

    public int maxdistance = 10;
    private Vector3 Origin;
    private Vector3 direction;

    private bool totrigger = true;

    public float strength = 10f;

    private HashSet<Rigidbody> affectedRBs = new HashSet<Rigidbody>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (invert == true)
        {
            totrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Origin = transform.position;
        direction = transform.up;

        HashSet<Rigidbody> currentHits = new HashSet<Rigidbody>(); //Creates a hash for containing rigidbodies being hit in the current frame

        if (activator.active == totrigger)
        {
            Ray Sensor = new Ray(Origin, direction); //Defines ray

            RaycastHit[] hits; //Creates array of hits 

            hits = Physics.RaycastAll(Origin, direction, maxdistance);

            for (int i = 0; i < hits.Length; i++) //Runs through array the length of the amount of stuff hit
            {
                RaycastHit hit = hits[i];

                if ((hit.collider.CompareTag("detectable")) || (hit.collider.CompareTag("player")) || (hit.collider.CompareTag("pickup")))
                { //Checks for tag (I dont want to be flinging walls about that wouldnt be slay
                    {
                        Rigidbody rb = hit.collider.attachedRigidbody; //Sets rigidbody to object thats currently being handled

                        rb.useGravity = false; //Disable gravity to stop the trajectories being as downhill as me on a saturday night

                        rb.AddForce(direction * strength); //WEEEEEEEEEEEEEE

                        currentHits.Add(rb); //Add current rb to current hits
                        affectedRBs.Add(rb); //Add current rb to affected rigidbodies
                    }
                }
            }
            foreach (Rigidbody rb in affectedRBs) //Go through all affected rigidbodies
            {
                if (!currentHits.Contains(rb))
                {
                    rb.useGravity = true; //Check if they are currently being hit and if not, re-enable their gravity
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero; //Stops the thingie completely when it gets to the top

                }
            }

            affectedRBs = currentHits; //Set affected RBs to currently hit RBs preventing an infinite loop
        }
    }

    private void OnDrawGizmos()
    {
        direction = transform.up;

        Gizmos.color = new Color(0f, 1f, 0f, 1f);

        Gizmos.DrawRay(transform.position, direction * maxdistance); //For visualizing button range when level building
    }
}
