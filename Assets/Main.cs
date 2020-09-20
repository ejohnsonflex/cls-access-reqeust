using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] Text clsURL;

    // Start is called before the first frame update
    void Start()
    {
        CMAPI.ConfigManager.ReadConfigData();
        CMAPI.ConfigManager.ParseConfigData();
        CMAPI.ConfigManager.ParseMultipleFeatures();
        CMAPI.ConfigManager.Assign();
      
        //clsURL.text += @"https:\\";
        clsURL.text += @"https:\";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
