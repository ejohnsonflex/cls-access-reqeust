using System;
using System.IO;
using UnityEngine;

namespace CLSDataLoader
{
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
                    string[] lineData = File.ReadAllLines(path);
                    foreach (var line in lineData)
                    {
                        // skip over empty lines in config.dat
                        if (!(string.IsNullOrEmpty(line.ToString())))
                        {
                            Debug.Log(line.ToString());
                        }
                    }
                }

                catch (Exception e)
                {
                    Debug.Log(e.Message.ToString());
                }

            }
        }
    }
}

