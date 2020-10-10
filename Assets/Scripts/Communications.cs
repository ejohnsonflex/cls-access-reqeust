using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

//public class ServerCommunications : MonoBehaviour
public class Communications : MonoBehaviour
{
    public static string URI { get; set; }
    private const string Name = "Authorization";
    private const string Bearer = "Bearer ";

    public Communications()
    {
        URI = ConfigDat.URL + "/preview_request";
    }

    public static IEnumerator NetworkManager(string jsonPreviewRequest, System.Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(URI, jsonPreviewRequest))
        {
            //Debug.Log($"{URI}");
            //Debug.Log($"{JsonPreviewRequest}");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPreviewRequest);
            //Debug.Log("Number of Byes in Request: "  + $"{System.Text.ASCIIEncoding.ASCII.GetByteCount(JsonPreviewRequest)}");
          
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            string getByte = Encoding.ASCII.GetString(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.timeout = -1;
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader(Name, Bearer + ConfigDat.BearerToken);

            // Send the request and wait for a response
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    public static void SendPreviewRequest(Communications comms, string jsonPreviewRequest)
    {
        comms.StartCoroutine(NetworkManager(jsonPreviewRequest, (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            }

            // callback
            else
            {
                PreviewResponseDisplay.JsonPreviewResponse = req.downloadHandler.text;
                PreviewResponseDisplay.PreviewResponseBytes = Encoding.ASCII.GetByteCount(req.downloadHandler.text);

            }
        }));
    }
}