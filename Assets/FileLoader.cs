using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileLoader : MonoBehaviour
{
    public class CLSData
    {
        private const string path = @"Assets/config.dat";
  
        private static string CLSID;
        private static string feature;
        private static string version;
        private static string hostID;
        private static string vendorDictionary;

        public static void Parse()
        {
            var cLSData = new CLSData();
           
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    Debug.Log(line.ToString());
                }
            }

            catch(Exception e)
            {
                Debug.Log(e.Message.ToString());
            }

            
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        CLSData.Parse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
