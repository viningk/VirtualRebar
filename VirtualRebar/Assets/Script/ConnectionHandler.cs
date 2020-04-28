using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectionHandler : MonoBehaviourPunCallbacks
{

    public GameObject VRRig;
    
    void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 10;
        PhotonNetwork.JoinOrCreateRoom("Room1", options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("On Room Joined");
        SceneManager.LoadScene("Multiplayer");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "Multiplayer")
        {
            PhotonNetwork.Instantiate(VRRig.name, new Vector3(0,1.7f,0), Quaternion.identity);
        }
        
    }
}