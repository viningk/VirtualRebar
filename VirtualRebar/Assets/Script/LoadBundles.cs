using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadBundles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAndInstantiateObject());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadAndInstantiateObject()
    {
        string url = "https://circuitstream.s3.amazonaws.com/bundles/bundle";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url, 0);
        yield return request.Send();
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        string[] names = bundle.GetAllAssetNames();
        //GameObject prefab = bundle.LoadAsset<GameObject>("assets/bundle.prefab");

       // Instantiate(prefab);

    }
}
