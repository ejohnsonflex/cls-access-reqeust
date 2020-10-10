using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


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

        StartCoroutine(PreviewRequestManager(communicationsScript));
        StartCoroutine(PreviewResponseDisplay.PollPreviewResponseChange()); ;
    }

    IEnumerator PreviewRequestManager(Communications communicationsScript)
    {
        var jsonPreviewRequest = new PreviewRequest().SerializePreviewRequest(new PreviewRequest());
        PreviewRequest.InjectSelectorsDictionary(jsonPreviewRequest);

        while (true)
        {
            Communications.SendPreviewRequest(communicationsScript, jsonPreviewRequest);
            yield return new WaitForSeconds(5);
        }
    }
}