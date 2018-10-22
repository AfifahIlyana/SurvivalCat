using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour 
{
    public static Vector3 GetAxis()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    public static Vector3 GetAxisJoystick(Joystick joystick)
    {
        Debug.Log("a"+joystick.Horizontal);
        return new Vector3(joystick.Horizontal, 0, joystick.Vertical);
    }
}
