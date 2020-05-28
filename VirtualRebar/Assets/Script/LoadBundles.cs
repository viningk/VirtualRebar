using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadBundles : MonoBehaviour
{
    public GameObject loadingParent;

    void Start()
    {
        StartCoroutine(LoadAndInstantiateObject());
        
    }

    IEnumerator LoadAndInstantiateObject()
    {
        string url = "https://streamlinedocs.blob.core.windows.net/virtualrebar/ParadiseRebar/pumpback";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url, 0);

        //loadingParent.gameObject.SetActive(true);

        yield return request.Send();
        
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        GameObject prefab = bundle.LoadAsset<GameObject>("assets/assetbundles/model.prefab");
        Instantiate(prefab);

        //loadingParent.gameObject.SetActive(false);

    }
}
