using UnityEngine;





public class ButtonPress : MonoBehaviour
{
    public int duration;
    private int countdown;

    public activator otherObject;
    

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

            if (countdown <= 0)
            {
                otherObject.active = false;
            }
        }
    }
    

    private void OnCollisionEnter(Collision other)
    { 

        otherObject.active = true;

        if (duration > 0)
        {
            countdown = duration;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (duration > 0)
        {
            countdown = duration;
        }
        else
        {
            otherObject.active = false;
        }
    }


}
