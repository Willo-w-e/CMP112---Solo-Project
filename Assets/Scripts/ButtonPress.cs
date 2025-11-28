using UnityEngine;





public class ButtonPress : MonoBehaviour
{
    public int duration;
    private int countdown;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown--;

            if (countdown == 0)
            {
                DisableTarget();
            }
        }
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (duration == 0)
        {
            ActivateTarget();
        }

        else
        {
            ActivateTarget();
            countdown = duration;
        }
    }

    private void ActivateTarget()
    {
        
    }

    private void DisableTarget()
    {
        
    }
}
