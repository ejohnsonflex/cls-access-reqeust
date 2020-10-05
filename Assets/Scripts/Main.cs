using System.Collections;
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
        //StartCoroutine(Communications.SetJson());

        //Communications.PreviewRequestSend(communicationsScript);

        StartCoroutine(PreviewRequestUpdate(communicationsScript));

        //Debug.Log(Communications.JsonPreviewResponse);
    }

    IEnumerator PreviewRequestUpdate(Communications communicationsScript)
    {
        while (true)
        {
            Communications.PreviewRequestSend(communicationsScript);
            yield return new WaitForSeconds(10);

            string temp = Communications.JsonPreviewResponse;
            if (string.IsNullOrEmpty(temp))
            {

            }

            else
            {
               Debug.Log($"{temp}");
            }
        }

    }

}