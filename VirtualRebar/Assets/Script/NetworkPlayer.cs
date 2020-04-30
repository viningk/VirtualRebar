using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    private PhotonView view;
    
    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (view.IsMine)
        {
            
        }
        {
            Camera[] cameras = GetComponentsInChildren<Camera>();

            foreach (Camera camera in cameras)
            {
                camera.gameObject.SetActive(false);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}