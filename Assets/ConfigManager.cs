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
        private static string[] features;
        private static string[] versions;
        private static string[] counts;
        private static string vendorDictionary;
        private static string bearerToken;

        private static string[] configLines = { };
        private static string[] parsedConfigLines = { };
        private static string[] countsParse, featuresParse, versionsParse = { };

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

        public static void ParseMultipleFeatures()
        {
            countsParse = parsedConfigLines[8].Split(',');
            featuresParse = parsedConfigLines[9].Split(',');
            versionsParse = parsedConfigLines[10].Split(',');
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
            counts = countsParse;
            features = featuresParse;
            versions = versionsParse;
            vendorDictionary = parsedConfigLines[11];
            bearerToken = parsedConfigLines[12];

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

        public static int NumFeatures()
        {
            return countsParse.Length;
        }

        public static int[] ReturnCounts()
        {

            List<int> list = new List<int>();
            int[] counts;

            foreach (var line in countsParse)
            {
                list.Add(Convert.ToInt32(line));
            }

            counts = list.ToArray();

            return counts;
        }

        public static string[] ReturnFeatures()
        {
            List<string> list = new List<string>();
            string[] features;

            foreach (var line in featuresParse)
            {
                list.Add(line);
            }

            features = list.ToArray();

            return features;
        }

        public static string[] ReturnVersions()
        {
            List<string> list = new List<string>();
            string[] versions;

            foreach (var line in versionsParse)
            {
                list.Add(line);
            }

            versions = list.ToArray();

            return versions;
        }

        public static string ReturnBearerToken()
        {
            return bearerToken;
        }
    }
}

