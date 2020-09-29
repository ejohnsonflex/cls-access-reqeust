using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] Text clsURLText;
    private const string path = @"Assets/config.dat";

    // Start is called before the first frame update
    void Start()
    {
        if (!ConfigDat.ConfigDatReader.ReadConfigData(path))
        {
            clsURLText.text = "Error reading config.dat"; 
        }

        else
        {
            //Debug.Log(CMAPI.CLSURL.ClsURl.Url());
            clsURLText.text = CMAPI.CLSURL.ClsURl.Url();
            List<string> configData = GetConfigData();

            //PreviewRequest.PreviewRequestTest();
            var pR = new PreviewRequest("string", "ejohnson@revenera.com");
            var f = new Feature(1, "dsr", "1.0");
            pR.features.Add(f);

            string jsonStr = JsonConvert.SerializeObject(pR);
            Debug.Log(jsonStr);
        }

        //CMAPI.ConfigManager.ReadConfigData();
        //CMAPI.ConfigManager.ParseConfigData();
        //CMAPI.ConfigManager.ParseMultipleFeatures();
        //CMAPI.ConfigManager.Assign();

    }

    private static List<string> GetConfigData()
    {
        return ConfigDat.ConfigDatReader.ConfigDatLines();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
