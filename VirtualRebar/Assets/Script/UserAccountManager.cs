using UnityEngine;
using System.Collections;
using DatabaseControl;
using UnityEngine.SceneManagement;

public class UserAccountManager : MonoBehaviour
{
    public static UserAccountManager UACInst;

    void Awake()
    {
        if (UACInst != null)
        {
            Destroy(gameObject);
            return;
        }

        UACInst = this;
        DontDestroyOnLoad(this);
    }

    //These store the username and password of the player when they have logged in
    public static string LoggedIn_Username { get; protected set; }
    private static string LoggedIn_Password = "";
    //public static string LoggedIn_Data { get; protected set; }

    public static bool IsLoggedIn { get; protected set; }

    public delegate void OnDataReceivedCallBack(string data);

    public void LogIn(string username, string password)
    {

        Debug.Log("Login: " + username + "  " + password);

        LoggedIn_Username = username;
        LoggedIn_Password = password;

        IsLoggedIn = true;

        SceneManager.LoadScene("Lobby");
    }

    public void LogOut()
    {
        LoggedIn_Username = "";
        LoggedIn_Password = "";

        IsLoggedIn = false;
    }

    //public void GetData(OnDataReceivedCallBack onDataReceived)
    //{
    //    if (IsLoggedIn)
    //    {
    //        StartCoroutine(GetDataRequest(LoggedIn_Username, LoggedIn_Password, onDataReceived));
    //    }
    //}

    //IEnumerator GetDataRequest(string username, string password, OnDataReceivedCallBack onDataReceived)
    //{
    //    string data = "Error";

    //    IEnumerator e = DCF.GetUserData(username, password); // << Send request to get the player's data string. Provides the username and password
    //    while (e.MoveNext())
    //    {
    //        yield return e.Current;
    //    }
    //    string response = e.Current as string; // << The returned string from the request

    //    if (response == "Error")
    //    {
    //        //There was another error. Automatically logs player out. This error message should never appear, but is here just in case.
    //        LoggedIn_Username = "";
    //        LoggedIn_Password = "";
    //    }
    //    else
    //    {
    //        //The player's data was retrieved. Goes back to loggedIn UI and displays the retrieved data in the InputField
    //        data = response;
    //    }

    //    if (onDataReceived != null) onDataReceived.Invoke(data);
    //}

    //public void SendData(string data)
    //{
    //    if (IsLoggedIn)
    //    {
    //        StartCoroutine(SendDataRequest(LoggedIn_Username, LoggedIn_Password, data));
    //    }
    //}

    //IEnumerator SendDataRequest(string username, string password, string data)
    //{
    //    IEnumerator e = DCF.SetUserData(username, password, data); // << Send request to set the player's data string. Provides the username, password and new data string
    //    while (e.MoveNext())
    //    {
    //        yield return e.Current;
    //    }
    //    string response = e.Current as string; // << The returned string from the request

    //    if (response == "Success")
    //    {
    //        //The data string was set correctly. Goes back to LoggedIn UI
    //        //loadingParent.gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        //There was another error. Automatically logs player out. This error message should never appear, but is here just in case.
    //        LoggedIn_Username = "";
    //        LoggedIn_Password = "";
    //    }
    //}
}
