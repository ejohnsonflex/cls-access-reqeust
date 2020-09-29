using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class ServerCommunications : MonoBehaviour
{
    public void TalkToServer()
    {
        // Connected to License Button and OnClick EventSystem / CmapiAccessRequest
        StartCoroutine(CommunicateToServer());
    }

    IEnumerator CommunicateToServer()
    {
        //string url = "https://flex13005-uat.compliance.flexnetoperations.eu/api/1.0/instances/0YBV7VG7HDL1/preview_request";

        string url = CMAPI.CLSURL.ClsURl.Url() + ("/preview_request");
        Debug.Log(url);


        //PreviewRequest.PreviewRequestTest();

        List<string> array = new List<string>();
        //array.Add("ANY");                                                           // implement
        //array.Add("EMEA");                                                          // implement

        var pR = new PreviewRequest("string", "wmelby@revenera.com", array);        // implement
        var f1 = new Feature(1, "dsr", "1.0");                                      // implement
        var f2 = new Feature(1, "dsr.advanced", "1.0");                             // implement
        pR.features.Add(f1);
        pR.features.Add(f2);

        string jsonStr = JsonConvert.SerializeObject(pR);
        Debug.Log(jsonStr);

        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStr);
        Debug.Log("Number of Byes in Request: " + System.Text.ASCIIEncoding.ASCII.GetByteCount(jsonStr));

        UnityWebRequest request = new UnityWebRequest(url, "POST");

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        string getByte = Encoding.ASCII.GetString(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");
        //request.SetRequestHeader("Authorization", "Bearer " + ConfigManager.ReturnBearerToken());
        request.SetRequestHeader("Authorization", "Bearer " + "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwicm9sZXMiOiJST0xFX0NBUEFCSUxJVFkifQ.C8K43qlPcD8GR5ZfhqsZkPfc_Srkcx9RYnF5gcSeIik6dT9yIFaWJrBTzo5Ar0Yj0jfFXp0XdoWi6dS2vATgl31aBFHC4hcOf_kz2aAzS7FuWEelIxauYWz2kfJxS5VPqwRlKLFd7V1rXFVcUbIqbUScN0tyyUkeNgXHDa2oM4fELhflqMlrLqvwJPmONNQAhhYhXX67JLRimV0jmmAG3MN48T3FsjBMUOJEU2kUwJSX-RjggfG39DuOKiXb7b68e2PevDmcwgjKh6CVSXp9bds3jGTraYe6iQKUFYhyGJHHhzdArXLiUrra0xuKlwN38aDp9qcJgMaFpi3oW7rmlw");

        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.downloadHandler.text);
        }

        Debug.Log("Status Code: " + request.responseCode);
        Debug.Log("Number of Bytes: " + request.downloadedBytes);
        Debug.Log(request.downloadHandler.text);

        byte[] _byte = Encoding.UTF8.GetBytes(request.downloadHandler.text);
        string results = request.downloadHandler.text;

        string jsonResult = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data);
        Debug.Log(jsonResult);

        string jsonString = results;


        //jsonData = JsonMapper.ToObject(jsonString);

        //Debug.Log(jsonData["features"][0]["name"]);
        //Debug.Log(jsonData["features"][0]["expires"]);

        //string mystring = results;

        //mystring = JValue.Parse(results).ToString(Formatting.Indented);
        //Debug.Log(mystring);
    }
}