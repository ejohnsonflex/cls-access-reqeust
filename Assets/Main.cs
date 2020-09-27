using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] Text clsURLText;
    const string path = @"Assets/config.dat";
    //const string path = @"config.dat";

    // Start is called before the first frame update
    void Start()
    {
        if (!CMAPI.Config.Dat.ConfigDatReader.ReadConfigData(path))
        { }

        else
        {
            //Debug.Log(CMAPI.CLSURL.ClsURl.Url());

            clsURLText.text = CMAPI.CLSURL.ClsURl.Url();
        }

        //CMAPI.ConfigManager.ReadConfigData();
        //CMAPI.ConfigManager.ParseConfigData();
        //CMAPI.ConfigManager.ParseMultipleFeatures();
        //CMAPI.ConfigManager.Assign();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
