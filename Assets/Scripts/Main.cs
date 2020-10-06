using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Michsky.UI;

public class Main : MonoBehaviour
{
    //public GameObject list = GameObject.FindGameObjectsWithTag("List");
    //public GameObject newFeature;

    private const string path = @"Assets/config.dat";
    [SerializeField] Text text = null;

    void Start()
    {
        ConfigDat.ConfigStart();
        text.text = ConfigDat.URL;

        Communications communicationsScript = (GameObject.FindGameObjectWithTag("AppPanel")).AddComponent<Communications>();
        PreviewResponseDisplay displayPreviewResponse = (GameObject.FindGameObjectWithTag("AppPanel")).AddComponent<PreviewResponseDisplay>();


        StartCoroutine(PreviewRequestUpdate(communicationsScript));
        StartCoroutine(PreviewResponseDisplay.PollPreviewResponseChange()); ;

    }

    IEnumerator PreviewRequestUpdate(Communications communicationsScript)
    {
        while (true)
        {
            Communications.PreviewRequestSend(communicationsScript);
            yield return new WaitForSeconds(5);
        }
    }
}