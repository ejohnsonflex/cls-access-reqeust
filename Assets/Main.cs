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

            clsURLText.text = CMAPI.CLSURL.ClsURl.Url();
            //List<string> configData = GetConfigData();

            /*
            //PreviewRequest.PreviewRequestTest();

            List<string> array = new List<string>();
            array.Add("ANY");                                                           // implement
            array.Add("EMEA");                                                          // implement

            var pR = new PreviewRequest("string", "ejohnson@revenera.com", array);      // implement
            var f1 = new Feature(1, "dsr", "1.0");                                      // implement
            var f2 = new Feature(1, "dsr.advanced", "1.0");                             // implement
            pR.features.Add(f1);
            pR.features.Add(f2);

            string jsonStr = JsonConvert.SerializeObject(pR);
            Debug.Log(jsonStr);*/
        }
    }

    //private static List<string> GetConfigData()
    //{
    //    return ConfigDat.ConfigDatReader.ConfigDatLines();
    //}

    // Update is called once per frame
    void Update()
    {

    }
}
