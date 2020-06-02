using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Voice.PUN;
using Photon.Voice.Unity;
using UnityEngine;
using UnityEngine.SpatialTracking;
using UnityEngine.UI;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    public MeshRenderer quad;
    public AudioListener listener;
    private PhotonView view;
    public Text textfield;

    public static string loginName = "";

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {

        if (view.IsMine)
        {
            view.Owner.NickName = loginName;
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
        textfield.text = view.Owner.NickName;

    }

    // Update is called once per frame
    void Update()
    {
    }
}