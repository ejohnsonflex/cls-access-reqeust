using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ConfigDat
{
    [SerializeField]
    Text text = GameObject.FindGameObjectWithTag("ClsUrlText").GetComponent<Text>();
    Color red = new Color(.9f, .3f, .3f);

    private readonly string path = "Assets/config.dat";

    private List<string> configDatList = new List<string>();
    private List<string> configDaLeftParseList = new List<string>();
    private List<string> configDatRightParseList = new List<string>();

    public string Tenant { get; set; }
    public string UatProd { get; set; }
    public string Domain { get; set; }
    public static string ClsId { get; set; }

    public static string HostType { get; set; }
    public static string HostId { get; set; }

    public string Incremental { get; set; }
    public string BorrowInterval { get; set; }
    public string Partial { get; set; }

    public List<Feature> Features { get; set; }

    public VendorDictionary VendorDictionary { get; set; }
    public SelectorsDictionary SelectorDicionary { get; set; }

    public static string BearerToken { get; set; }

    public static string URL { get; set; }

    public ConfigDat()
    {
        if (!OpenFile(path))
        {
            //text.color = red;
            //text.text = "Error: Somethin' bad done blew up..";
        }

        else
        {
            Tenant = configDatRightParseList[0];

            if (!string.IsNullOrEmpty(configDatRightParseList[1]))
            {
                UatProd = configDatRightParseList[1];

                if (UatProd.Equals("uat"))
                {
                    UatProd = "-uat";
                }

            }

            Domain = configDatRightParseList[2];
            ClsId = configDatRightParseList[3];
            HostType = configDatRightParseList[4];


            if (!string.IsNullOrEmpty(configDatRightParseList[5]))
            {
                HostId = configDatRightParseList[5];
            }

            else
            {
                text.color = red;
                text.text = "Error: No hostId supplied in config.dat";
            }

            Incremental = configDatRightParseList[6];
            BorrowInterval = configDatRightParseList[7];
            Partial = configDatRightParseList[8];
            Features = new List<Feature>(ParseFeatureDat());

            //VendorDictionary = new VendorDictionary(ParseVendorDictionaryDat());
            //Debug.Log(VendorDictionary.JOBS);

            if (!string.IsNullOrEmpty(configDatRightParseList[15]))
            {
                BearerToken = configDatRightParseList[15];
            }

            else
            {
                text.color = red;
                text.text = "Error: No Bearer Token supplied in config.dat";
            }

            URL = ("https://flex" + Tenant + UatProd + ".compliance.flexnetoperations." + Domain + "/api/1.0/instances/" + ClsId);
        }
    }

    private bool OpenFile(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            else
            {
                ReadConfigData();
                ParseConfigDat();
                ParseFeatureDat();
                ParseVendorDictionaryDat();

                return true;
            }
        }

        catch (FileNotFoundException)
        {
            text.color = red;
            text.text = "Error: config.dat file not found";

            //Text myText = GameObject.Find("Canvas/Panel/ClsUrlText").GetComponent<Text>();
            //myText.text = ("Error: config.dat file not found!");
        }

        catch (IOException)
        {
            text.color = red;
            text.text = "Error: config.dat is likely corrupt";
        }

        return false;
    }

    private void ReadConfigData()
    {
        configDatList = File.ReadAllLines(path).ToList<string>();

        /*foreach (var line in configDatList)
        {
            Debug.Log(line);
        }*/
    }

    private void ParseConfigDat()
    {
        foreach(var line in configDatList)
        {
            configDaLeftParseList.Add(line.Split('=').First().Trim());
            configDatRightParseList.Add(line.Split('=').Last().Trim());
        }
    }

    public static string ClsUrl ()
    {
        return "blah";
    }

    private List<Feature> ParseFeatureDat()
    {
        string[] counts = configDatRightParseList[9].Split(new string[] { "," }, StringSplitOptions.None);
        string[] features = configDatRightParseList[10].Split(new string[] { "," }, StringSplitOptions.None);
        string[] versions = configDatRightParseList[11].Split(new string[] { "," }, StringSplitOptions.None);

        var fl = new List<Feature>();

        for (int i = 0; i < counts.Length; i++)
        {
            Feature f = new Feature();

            f.Count =  Convert.ToInt32(counts[i]);
            f.Name = features[i];
            f.Version = versions[i];

            fl.Add(f);
        }

        return fl;
    }

    private int ParseVendorDictionaryDat()
    {
        string[] vdIntsArray = configDatRightParseList[12].Split(new string[] { "=" }, StringSplitOptions.None);
        string[] vdStringsArray = configDatRightParseList[13].Split(new string[] { "=" }, StringSplitOptions.None);

        string[] vdBitPairs = { };
        int num = 0;
        //VendorDictionary vd = new VendorDictionary();

        for (int i = 0; i < vdIntsArray.Length; i++)
        {
            vdBitPairs = vdIntsArray[i].Split(new string[] { ":" }, StringSplitOptions.None);
            num = Convert.ToInt32(vdBitPairs[1]);

            //VendorDictionary.JOBS = num;
        }

        return num;
    }

    public static void ConfigStart()
    {
        var configDat = new ConfigDat();
    }
}