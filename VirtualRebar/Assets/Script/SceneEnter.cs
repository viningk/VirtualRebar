using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEnter : MonoBehaviour {

    //public GameObject player;

    public void EnterScene()
    {
        //player.SetActive(true);
        SceneManager.LoadScene("Main");
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
