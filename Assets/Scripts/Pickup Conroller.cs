using Unity.VisualScripting;
using UnityEngine;

public class PickupConroller : MonoBehaviour
{
    public Transform PickupBox;
    public float moveSpeed = 10f;
    public float pickupRange = 1.0f;
    private Rigidbody heldObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
            {
                pickup(); //If not holding an object, run pickup, else, run drop
            } else
            {
                drop();
            }
        }
    }

    private void FixedUpdate()
    {
        if (heldObject != null) //Dont run if theres no held object
        {
            Vector3 moveDirection = PickupBox.position - heldObject.transform.position;
            heldObject.linearVelocity = moveDirection * moveSpeed;
        }
    }

    void pickup()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; //Cast a ray forward and take hit data

        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("detectable")) //If hit data is marked detectable (Im gonna change this tagging later to make it more robust for expansion
            {
                heldObject = hit.collider.GetComponent<Rigidbody>();   //Set held object to be the object hit
                if (heldObject != null)
                {
                    heldObject.useGravity = false; //Disable gravity
                    heldObject.angularVelocity = Vector3.zero; //Remove moveement
                }
            }
        }
    }

    void drop()
    {
        if (heldObject != null) //Only run if theres a held object
        {
            Rigidbody rb = heldObject.GetComponent<Rigidbody>(); //create local variable
            if (rb != null)
            {
                heldObject.useGravity = true;  //Re-enable gravity
                heldObject.linearVelocity = Vector3.zero; //Remove linear velocity
                heldObject = null; //Remove the RB from held objet

            }
            
        }
    }

}

