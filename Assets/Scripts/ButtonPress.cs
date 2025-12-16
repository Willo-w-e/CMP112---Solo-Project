using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;





public class ButtonPress : MonoBehaviour
{
    public float duration; //Button press duration
    private float countdown;
    private bool pressed;

    private AudioSource source;

    public AudioClip press;
    public AudioClip release;

    public activator otherObject; //Links to activator

    private bool hasbeenpressed;

    public float minpitch = 1.0f;
    public float maxpitch = 2.0f;

    public int collisions = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>(); //Let me make clicks!
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0) 
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0) 
            {
                otherObject.active = false; //Disables the other object when countdown hits 0 via the activator
                pressed = false; //Lets button be pressed again
            }
        }
    }
    

    private void OnCollisionEnter(Collision other)
    {

        collisions++;

        if (pressed == true)
        {
            if(duration < 0)
            {
                source.pitch = RandomPitch(minpitch, maxpitch);
                source.PlayOneShot(press, 1.0f); //Click
            }

            return; //Breaks out the function if button is already pressed
        }

        pressed = true; //Says the button is pressed

        if (duration >= 0)
        {
            otherObject.active = true; //Activates the other objects functions via the activator 
        } else 
        {
            otherObject.active = !otherObject.active; //Inverts active
        }


        if (duration > 0) //Sets countdown up if the press has duration
        {
            countdown = duration; //Sets countdown
        }

        source.pitch = RandomPitch(minpitch, maxpitch);
        source.PlayOneShot(press, 1.0f);

        hasbeenpressed = true;
    }

    private void OnCollisionExit(Collision collision)
    {

        collisions = Mathf.Max(0, collisions - 1); //Clamps collisions value at 0 preventing it from ever going negative

        if (duration == 0 && collisions == 0) //Makes sure the button doesnt turn off when somethings still on it 
        {

           
            pressed = false; //lets button be pressed again
            otherObject.active = false; //Disables other object on getting off the button if theres no duration, making it so that negative durations make it toggle
        }
        source.pitch = 1;
        source.PlayOneShot(release, 1.0f); //Click
    }

    public void ResetButton()
    {

        if (hasbeenpressed == true)
        {
            countdown = 0;

            if (duration < 0)
            {
                otherObject.active = !otherObject.active;
            }

            hasbeenpressed = false;
            pressed = false;

        }


    }

    public float RandomPitch(float min, float max)
    {
        float number = Random.Range(min, max);

        return number;
    }


}
