using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Teleport : MonoBehaviour
{
    public string m_buttonName;
    public VRTeleporter vrTeleporter;
    private InputDevice m_VRController;
 
     // Use this for initialization
    void Start()
    {
        //m_VRController = InputDevices.GetDeviceAtXRNode(m_node);
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(m_buttonName))
        {
            Debug.Log("Button");

            //Vibrate(m_VRController, 1, 0.25f);

            vrTeleporter.ToggleDisplay(true);
      
        }
   
        if (Input.GetButtonUp(m_buttonName)) 
        {
            vrTeleporter.Teleport();
            vrTeleporter.ToggleDisplay(false);
        }
    }

    
    void Vibrate(InputDevice controller, float amplitude, float time)
    {
        if (controller.isValid)
        {
            HapticCapabilities hapCap = new HapticCapabilities();
            controller.TryGetHapticCapabilities(out hapCap);

            if (hapCap.supportsImpulse)
            {
                controller.SendHapticImpulse(0, amplitude, time);
            }
        }
    }
}
