﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour 
{
    public static string objectMovedUp = "";

    public static Vector3 GetAxis()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    public static Vector3 GetAxisJoystick(Joystick joystick)
    {
        return new Vector3(joystick.Horizontal, joystick.Vertical, 0 );
    }



}
