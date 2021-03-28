using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;

public class VRControllerManager : MonoBehaviour
{
    private InputDevice controller;
    private Transform startRotation;

    [SerializeField] private GameObject doors;  
    [SerializeField] private GameObject mazda;
   


    void Start()
    {
        // find and asign right controller

        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightController = InputDeviceCharacteristics.Right;
        InputDevices.GetDevicesWithCharacteristics(rightController, devices);

        if(devices.Count > 0)
        {
            controller = devices[0];
        }

        startRotation = doors.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        // joystick or touchpad input        
        if (controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joyVector) && joyVector != Vector2.zero)
        {
            mazda.transform.Rotate(0, joyVector.x, 0); // rotate the car

            doors.transform.rotation = Quaternion.Lerp(doors.transform.rotation, startRotation.rotation, 0.1f);

        }

    }

}
