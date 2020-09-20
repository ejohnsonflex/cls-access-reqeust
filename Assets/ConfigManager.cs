using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace CMAPI
{
    public class ConfigManager
    {
        private const string path = @"Assets/config.dat";

        private static string tenant;
        private static string uatProd;
        private static string comEu;
        private static string clsId;
        private static string hostId;
        private static string incremental;
        private static string borrowInterval;
        private static string partial;
        private static string feature;
        private static string version;
        private static string count;
        private static string vendorDictionary;

        private static string[] configLines = { };
        private static string[] parsedConfigLines = { };

        ConfigManager()
        {
            var cLSData = new ConfigManager();
        }

        public static void ReadConfigData()
        {
            try
            {
                configLines = File.ReadAllLines(path);

                /*foreach (var line in lineData)
                {
                    // skip over empty lines in config.dat
                    if (!(string.IsNullOrEmpty(configLines.ToString())))
                    {
                        Debug.Log(configLines.ToString());
                    }
                }*/
            }

            catch (Exception e)
            {
                Debug.Log(e.Message.ToString());
            }
        }

        public static void ParseConfigData()
        {
            List<string> list = new List<string>();

            // split and read only right hand side of '=' sign in config.dat
            foreach (var line in configLines)
            {
                list.Add(line.Split('=').Last().Trim());
            }

            parsedConfigLines = list.ToArray();

            /*foreach (string line in parsedConfigLines)
            {
                Debug.Log(line);
            }*/
        }

        public static void Assign()
        {
            tenant = parsedConfigLines[0];
            uatProd = parsedConfigLines[1];
            comEu = parsedConfigLines[2];
            clsId = parsedConfigLines[3];
            hostId = parsedConfigLines[4];
            incremental = parsedConfigLines[5];
            borrowInterval = parsedConfigLines[6];
            partial = parsedConfigLines[7];
            count = parsedConfigLines[8];
            feature = parsedConfigLines[9];
            version = parsedConfigLines[10];
            vendorDictionary = parsedConfigLines[11];

            /*foreach (var line in configLines)
            {
                // skip over empty lines in config.dat
                if (!(string.IsNullOrEmpty(line.ToString())))
                {
                    Debug.Log(line.ToString());
                }
            }*/
        }

        public static string ReturnHostID()
        {
            return hostId;
        }

        public static string ReturnIncremental()
        {
            return incremental;
        }

        public static string ReturnBorrowInterval()
        {
            return borrowInterval;
        }

        public static string ReturnPartial()
        {
            return partial;
        }

        public static int ReturnCount()
        {
            return Convert.ToInt32(count);
        }

        public static string ReturnFeature()
        {
            return feature;
        }

        public static string ReturnVersion()
        {
            return version;
        }
    }
}

