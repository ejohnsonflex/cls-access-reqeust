using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        CLSDataLoader.FileLoader.CLSData.Parse();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
