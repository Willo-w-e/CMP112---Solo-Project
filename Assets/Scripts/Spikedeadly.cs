using UnityEngine;

public class Spikedeadly : MonoBehaviour
{

    public Transform respawn;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("player"))
        {
            collision.transform.position = respawn.position;
        }
    }

}
