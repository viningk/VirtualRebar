using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] Behaviour[] componentsToDisable;

=======
 
>>>>>>> 19b5dc0994294acfafce7a8b42ff9bb8e66e69b1
    private PhotonView view;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Is mine: " + view.IsMine);
        if (view.IsMine)
        {
        }
        else
        {
<<<<<<< HEAD
            OVRCameraRig cameraRig = GetComponentInChildren<OVRCameraRig>();
            cameraRig.enabled = false;
            
            OVRHeadsetEmulator headsetEmulator = GetComponentInChildren<OVRHeadsetEmulator>();
            headsetEmulator.enabled = false;
            
            OvrAvatar avatar = GetComponentInChildren<OvrAvatar>();
            avatar.enabled = false;
            
            OvrAvatarLocalDriver driver = GetComponentInChildren<OvrAvatarLocalDriver>();
            driver.enabled = false;
            
            Camera[] cameras = GetComponentsInChildren<Camera>();
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }
=======
            //Camera[] cameras = GetComponentsInChildren<Camera>();

            //foreach (Camera camera in cameras)
            //{
            //    camera.gameObject.SetActive(false);
            //}
>>>>>>> 19b5dc0994294acfafce7a8b42ff9bb8e66e69b1
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}