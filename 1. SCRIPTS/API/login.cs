using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
// using Newtonsoft.Json;


public class login : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(GetRequest("http://127.0.0.1:8000/api/login?email=kenderman.8@gmail.com&password=password1234"));
        // UnityWebRequest myWr = UnityWebRequest.Get("http://127.0.0.1:8000/api/login?email=kenderman.8@gmail.com&password=password1234");

        // UnityWebRequest myWr = UnityWebRequest.Get("http://127.0.0.1:8000/api/ping");
        // print(myWr);

        // StartCorroutine( GetRequest('http://127.0.0.1:8000/api/ping') );
    }

    // IEnumerator GetRequest(string uri)
    // {
    //     using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
    //     {
    //         yield return webRequest.SendWebRequest();

    //         switch (webRequest.result)
    //         {
    //             case UnityWebRequest.Result.ConnectionError:
    //             case UnityWebRequest.Result.DataProcessingError:
    //                 Debug.LogError(string.Format("Something went wrong: {0}", webRequest.error));
    //                 break;
    //             case UnityWebRequest.Result.Success:
    //                 // Fact fact = JsonConvert.DeserializeObject<Fact>(webRequest.downloadHandler.text);

    //                 print(JsonConvert.DeserializeObject<Fact>(webRequest.downloadHandler.text));

    //                 // Aquí puedes usar la variable 'fact' según necesites.
    //                 break;
    //         }
    //     }
    // }

}
