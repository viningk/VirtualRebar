using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Teleport : MonoBehaviour
{
    public string m_buttonName;
    private InputDevice m_VRController;
    public XRNode m_node;

    public Transform headTransform;

    public Transform cameraRigTransform;
    private bool shouldTeleport;


    public GameObject laserPrefab;
    private GameObject laser;
    private Vector3 hitPoint;

     // Use this for initialization
    void Start()
    {
        m_VRController = InputDevices.GetDeviceAtXRNode(m_node);

        laser = Instantiate(laserPrefab);
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Mouse0))
        if (Input.GetButtonDown(m_buttonName))
        //{
        //    Vibrate(m_VRController, 1, 0.25f);
        //}

        //if (OVRInput.Get(OVRInput.Button.One))
            //if(Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        //if(GvrController.AppButton)
        {
            Debug.Log("Button");

            Vibrate(m_VRController, 1, 0.25f);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 1000))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                shouldTeleport = true;
            }
            else
            {
                laser.SetActive(false);
                shouldTeleport = false;
            }
        }
        else
        {
            laser.SetActive(false);
        }

        if (Input.GetButtonUp(m_buttonName) && shouldTeleport) // (OVRInput.GetUp(OVRInput.Button.One) && shouldTeleport)
            //(Input.GetKeyUp("h") && shouldTeleport)
        {
            //Tele();
            TeleWithDifference();
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

    void TeleWithDifference()
    {
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 4;
        shouldTeleport = false;
        cameraRigTransform.position = hitPoint; // + difference;
    }

    void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laser.transform.position = Vector3.Lerp(transform.position, hitPoint, 0.5f);
        laser.transform.LookAt(hitPoint);
        laser.transform.localScale = new Vector3(laser.transform.localScale.x, laser.transform.localScale.y, hit.distance);
    }
}
