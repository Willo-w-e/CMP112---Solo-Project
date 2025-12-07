using UnityEngine;





public class ButtonPress : MonoBehaviour
{
    public int duration; //Button press duration
    private int countdown;

    public activator otherObject; //Links to activator
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0) 
        {
            countdown--; //De-increments countdown (Is that a word? I dont really know i'm not that good at English)

            if (countdown <= 0) 
            {
                otherObject.active = false; //Disables the other object when countdown hits 0 via the activator
            }
        }
    }
    

    private void OnCollisionEnter(Collision other)
    { 

        otherObject.active = true; //Activates the other objects functions via the activator 

        if (duration > 0) //Sets countdown up if the press has duration
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
            otherObject.active = false; //Disables other object on getting off the button if theres no duration
        }
    }


}
