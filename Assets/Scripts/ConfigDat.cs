using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ConfigDat
{
    [SerializeField]
    private Text _clsUrlText = null;
    Text text = GameObject.FindGameObjectWithTag("ClsUrlText").GetComponent<Text>();
    Color red = new Color(.9f, .3f, .3f);

    private readonly string path = "Assets/config.dat";

    private List<string> configDatList = new List<string>();
    private List<string> configDaLeftParseList = new List<string>();
    private List<string> configDatRightParseList = new List<string>();

    public string Tenant { get; set; }
    public string UatProd { get; set; }
    public string Domain { get; set; }
    public string ClsId { get; set; }

    public string HostType { get; set; }
    public string HostId { get; set; }

    public string Incremental { get; set; }
    public string BorrowInterval { get; set; }
    public string Partial { get; set; }

    public List<Feature> Features { get; set; }

    public IList<string> VendorDictionary { get; set; }
    public IList<string> SelectorDicionary { get; set; }

    public string BearerToken { get; set; }

    public ConfigDat()
    {
        if (!OpenFile(path))
        {
            text.color = red;
            text.text = "Error: Something blew up";
        }

        else
        {
            Tenant = configDatRightParseList[0];
            UatProd = configDatRightParseList[1];
            Domain = configDatRightParseList[2];
            ClsId = configDatRightParseList[3];
            HostId = configDatRightParseList[4];
            HostId = configDatRightParseList[5];
            Incremental = configDatRightParseList[6];
            BorrowInterval = configDatRightParseList[7];
            Partial = configDatRightParseList[8];
            Features = new List<Feature>(ParseFeatureDat());

            BearerToken = configDatRightParseList[14];
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
}