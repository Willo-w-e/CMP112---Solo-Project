using UnityEngine;

public class Spikedeadly : MonoBehaviour
{

    public Transform respawn;


    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = respawn.position;
    }

}
