using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] Text clsURL;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        CMAPI.ConfigManager.ReadConfigData();
        CMAPI.ConfigManager.ParseConfiData();
        CMAPI.ConfigManager.Assign();
        CMAPI.ConfigManager.AccessRequestData();
      
        clsURL.text += @"https\";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
