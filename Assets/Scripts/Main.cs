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
        Communications communicationsScript = (GameObject.FindGameObjectWithTag("AppPanel")).AddComponent<Communications>();

        ConfigDat.ConfigStart();
        Communications.PreviewRequestSend(communicationsScript);

        StartCoroutine(PreviewRequestUpdate(communicationsScript));
    }

    void Update()
    {
        
    }

    IEnumerator PreviewRequestUpdate(Communications communicationsScript)
    {

        while (true)
        {
            Communications.PreviewRequestSend(communicationsScript);
            yield return new WaitForSeconds(10);
        }

    }

}