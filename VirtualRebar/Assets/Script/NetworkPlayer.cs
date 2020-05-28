using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Voice.PUN;
using Photon.Voice.Unity;
using UnityEngine;
using UnityEngine.SpatialTracking;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    public MeshRenderer quad;
    public AudioListener listener;
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
            PhotonVoiceNetwork.Instance.PrimaryRecorder = FindObjectOfType<Recorder>();
            PhotonVoiceNetwork.Instance.InitRecorder(PhotonVoiceNetwork.Instance.PrimaryRecorder);
        }
        else
        {
            quad.enabled = false;
            listener.enabled = false;

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