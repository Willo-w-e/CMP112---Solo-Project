using UnityEngine;

public class CubeNoise : MonoBehaviour
{

    private AudioSource source;

    public AudioClip thunk;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>(); //Let there be thunks!
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
            source.PlayOneShot(thunk, 0.3f); //Low volume so it doesnt drown out button click
          
    }

    
}
