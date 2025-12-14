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
                pickup();
            } else
            {
                drop();
            }
        }
    }

    private void FixedUpdate()
    {
        if (heldObject != null)
        {
            Vector3 moveDirection = PickupBox.position - heldObject.transform.position;
            heldObject.linearVelocity = moveDirection * moveSpeed;
        }
    }

    void pickup()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("detectable"))
            {
                heldObject = hit.collider.GetComponent<Rigidbody>();   
                if (heldObject != null)
                {
                    heldObject.useGravity = false;
                    heldObject.angularVelocity = Vector3.zero;
                }
            }
        }
    }

    void drop()
    {
        if (heldObject != null)
        {
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                heldObject.useGravity = true;
                heldObject.linearVelocity = Vector3.zero;
                heldObject = null;

            }
            
        }
    }

}

