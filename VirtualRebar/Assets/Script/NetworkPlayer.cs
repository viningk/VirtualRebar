using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable;


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
            /* OVRCameraRig cameraRig = GetComponentInChildren<OVRCameraRig>();
             cameraRig.enabled = false;
             
             OVRHeadsetEmulator headsetEmulator = GetComponentInChildren<OVRHeadsetEmulator>();
             headsetEmulator.enabled = false;
             
             OvrAvatar avatar = GetComponentInChildren<OvrAvatar>();
             avatar.enabled = false;
             
             OvrAvatarLocalDriver driver = GetComponentInChildren<OvrAvatarLocalDriver>();
             driver.enabled = false;
             */
            Camera[] cameras = GetComponentsInChildren<Camera>();
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}