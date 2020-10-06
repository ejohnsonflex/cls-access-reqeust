using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

//public class ServerCommunications : MonoBehaviour
public class Communications : MonoBehaviour
{
    public static string URI { get; set; }
    public static string JsonPreviewRequest { get; set; }
    private const string Name = "Authorization";

    public Communications()
    {
        URI = ConfigDat.URL + "/preview_request";
        JsonPreviewRequest = new PreviewRequest().SerializePreviewRequest(new PreviewRequest());
    }

    public static IEnumerator NetworkManager(string URI, System.Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(URI, JsonPreviewRequest))
        {
            //Debug.Log($"{URI}");
            //Debug.Log($"{JsonPreviewRequest}");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(JsonPreviewRequest);
            //Debug.Log("Number of Byes in Request: "  + $"{System.Text.ASCIIEncoding.ASCII.GetByteCount(JsonPreviewRequest)}");
          
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            string getByte = Encoding.ASCII.GetString(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.timeout = -1;
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader(Name, "Bearer " + ConfigDat.BearerToken);

            // Send the request and wait for a response
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    public static void PreviewRequestSend(Communications comms)
    {
        comms.StartCoroutine(NetworkManager(URI, (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            }

            else
            {
                PreviewResponseDisplay.JsonPreviewResponse = req.downloadHandler.text;
                PreviewResponseDisplay.PreviewResponseBytes = Encoding.ASCII.GetByteCount(req.downloadHandler.text);

                //int num = DisplayPreviewResponse.PreviewResponseBytes = Encoding.ASCII.GetByteCount(req.downloadHandler.text);
                //Debug.Log($"{num}");

                //PreviewResponse previewresponse = PreviewResponse.DeserializePreviewResponse(JsonPreviewResponse);

                //int featureCount = previewresponse.Features.Count;

                //foreach (var feature in previewresponse.Features)
                //{
                //    Debug.Log("Feature: " + $"{feature.name}" + "\t\tAvailable: " + $"{feature.count}" + "\t\tTotal: " + $"{feature.maxCount}" + "\t\tExpiration: " + $"{feature.expires.ToLongDateString()}");
                //}

            }
        }));
    }
}