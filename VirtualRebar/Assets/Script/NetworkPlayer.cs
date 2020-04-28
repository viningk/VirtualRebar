using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{
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
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}