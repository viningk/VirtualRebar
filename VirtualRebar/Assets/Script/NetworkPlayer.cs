using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SpatialTracking;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    public MeshRenderer quad;
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
        else
        {
            quad.enabled = false;
            foreach (Behaviour component in componentsToDisable)
            {
                component.enabled = false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}