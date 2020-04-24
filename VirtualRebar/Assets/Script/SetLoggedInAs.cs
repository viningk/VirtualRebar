using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetLoggedInAs : MonoBehaviour {

    public TMP_Text UserName;
    private void Awake()
    {
        UserName.text = UserAccountManager.LoggedIn_Username;
    }
}
