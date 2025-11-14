using UnityEngine;






public class ButtonPress : MonoBehaviour
{
    public object target;
    public int duration;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if(duration == 0)
        {
            
        }
    }
}
