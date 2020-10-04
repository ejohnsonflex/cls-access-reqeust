using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

//public class ServerCommunications : MonoBehaviour
public class CommunicationsBK : MonoBehaviour
{
    private const string Name = "Authorization";

    //private string _jsonResponse = string.Empty;
    public static string JSON { get; set; }

    public static IEnumerator NetworkManager(string uri, string jsonString, System.Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(uri, jsonString))
        {
            Debug.Log(uri);
            Debug.Log(jsonString);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonString);
            Debug.Log("Number of Byes in Request: " + System.Text.ASCIIEncoding.ASCII.GetByteCount(jsonString));

            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            string getByte = Encoding.ASCII.GetString(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.timeout = -1;
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader(Name, "Bearer " + ConfigDat.BearerToken);

            // Send the request and wait for a response
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("No response from CLS or network error");
            }

            else
            {
                //Debug.Log("HERE");
                callback(request.downloadHandler.text);
            }
        }
    }

    public static void PreviewRequestSend()
    {
        
        string uri = ConfigDat.URL + "/preview_request";
        string jsonString = new PreviewRequest().SerializePreviewRequest(new PreviewRequest());
        CommunicationsBK communicationsScript = (GameObject.FindGameObjectWithTag("AppPanel")).AddComponent<CommunicationsBK>();

        communicationsScript.StartCoroutine(NetworkManager(uri, jsonString, (value) => { JSON = value; Debug.Log(JSON); }));
        //communicationsScript.StartCoroutine(NetworkManager(uri, jsonString, (value) => { JSON = value; }));
    }
}