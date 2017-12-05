using UnityEngine;

public class CustomInputController: MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("joystick 1 button 0"))
        {
            // Do nothing.
        }
        if (Input.GetKey("joystick 1 button 1"))
        {
            // Do nothing.
        }
        if (Input.GetKey("joystick 1 button 2"))
        {
            // Do nothing.
        }
        if (Input.GetKey("joystick 1 button 3"))
        {
            // TODO: Car: W Pressed
            Debug.Log("Accelerating...");
        }
        if (Input.GetKey("joystick 1 button 4"))
        {
            // TODO: Question: Z Pressed
            Debug.Log("Answer C");
        }
        if (Input.GetKey("joystick 1 button 5"))
        {
            // TODO: Question: X Pressed
            Debug.Log("Answer D");
        }
        if (Input.GetKey("joystick 1 button 6"))
        {
            // TODO: Question: A Pressed
            Debug.Log("Answer A");
        }
        if (Input.GetKey("joystick 1 button 7"))
        {
            // TODO: Question: S Pressed
            Debug.Log("Answer B");
        }
        if (Input.GetKey("joystick 1 button 8"))
        {
        }
        if (Input.GetKey("joystick 1 button 9"))
        {
            // TODO: GameController: Restart()
            // TODO: GameController: Start()
            // TODO: GameController: Pause()
            Debug.Log("Pause/Play/Restart");
        }
    }
}