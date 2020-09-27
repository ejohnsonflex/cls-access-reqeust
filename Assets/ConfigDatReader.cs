using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CMAPI.Config.Dat
{
    public class ConfigDatReader : MonoBehaviour
    {
        [SerializeField] private Text _clsUrlText;
        private static List<string> _configDatLines = new List<string>();

        public static bool ReadConfigData(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException();

                    
                }

                else
                {
                    //read all lines in config.dat

                    _configDatLines = File.ReadAllLines(path).ToList();

                    return true;

                    //foreach (var line in lines)
                    //{
                    //    Debug.Log(line);
                        // skip over empty lines in config.dat
                        //if (!(string.IsNullOrEmpty(configLines.ToString())))
                        //{
                        //    Debug.Log(configLines.ToString());
                        //}
                    //}
                }

               

            }

            catch (FileNotFoundException)
            {
                Text text = GameObject.FindGameObjectWithTag("ClsUrlText").GetComponent<Text>();
                Color red = new Color(.9f, .3f, .3f);
                text.color = red;
                text.text = "Error: config.dat file not found";

                return false;

                //2
                //Text myText = GameObject.Find("Canvas/Panel/ClsUrlText").GetComponent<Text>();
                //myText.text = ("Error: config.dat file not found!");

                //1
                //Debug.Log("Error: config.dat file not found!");
                //Debug.Log(path);
            }

            catch(IOException)
            {
                Text text = GameObject.FindGameObjectWithTag("ClsUrlText").GetComponent<Text>();
                Color red = new Color(.9f, .3f, .3f);
                text.color = red;
                text.text = "Error: config.dat is likely corrupt";

                return false;
            }

        }

        public static List<string> ConfigDatLines()
        {
            return _configDatLines;
        }

    }
}

    /*public static void ReadConfigData(string path)
    {
        try
        {
            lines = File.ReadAllLines(path);

            foreach (var line in lineData)
            {
                // skip over empty lines in config.dat
                if (!(string.IsNullOrEmpty(configLines.ToString())))
                {
                    Debug.Log(configLines.ToString());
                }
            }
        }

        catch (Exception e)
        {
            Debug.Log(e.Message.ToString());
        }*/

