using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class ApiHandler : MonoBehaviour
{
    private static ApiHandler _instance;
    public static ApiHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("ApiHandler");
                _instance = obj.AddComponent<ApiHandler>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public void GetRequest(string uri, Action<string> callback)
    {
        StartCoroutine(GetRequestCoroutine(uri, callback));
    }

    private IEnumerator GetRequestCoroutine(string uri, Action<string> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.LogError("Error: " + webRequest.error);
                callback?.Invoke(null);
            }
            else
            {
                callback?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }
}
