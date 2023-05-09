using BomberSquad.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    [SerializeField] JoystickInput joystickInput;
    Vector3 rotationVector;
    private void Update()
    {
        rotationVector = Vector3.zero;
        rotationVector.z = joystickInput.RotationVector.z;

        transform.rotation = Quaternion.Euler(rotationVector*10);

        Debug.Log(rotationVector * 10);


    }
}
