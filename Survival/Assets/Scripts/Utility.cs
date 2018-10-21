using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour 
{
    public static Vector3 GetAxis()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
