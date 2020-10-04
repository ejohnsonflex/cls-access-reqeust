using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private const string path = @"Assets/config.dat";

    void Start()
    {
        ConfigDat.ConfigStart();

        Communications communicationsScript = (GameObject.FindGameObjectWithTag("AppPanel")).AddComponent<Communications>();

        // thought to make a UWR, pass it to PreviewRequestSend and check uWR.isDone
        //UnityWebRequest uWR

        communicationsScript.PreviewRequestSend();

    }

    void Update()
    {
        //Communications comms = new Communications();
        //StartCoroutine(comms.PreviewRequestSend
    }
}

    /*if (string.IsNullOrEmpty(communicationsScript.JSON))
       {
           Debug.Log("It's null");
       }

       Display.ShowPreviewResponse(communicationsScript.GetJsonPreviewResponse());*/
