using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

[System.Serializable]
public class PreviewRequest
{
    [JsonProperty("hostId")]
    public HostId HostId { get; set; }
    [JsonProperty("features", NullValueHandling = NullValueHandling.Ignore)]
    public List<Feature> Features { get; set; }
    [JsonProperty("selectorsDictionary", NullValueHandling = NullValueHandling.Ignore)]
    public SelectorsDictionary SelectorsDictionary { get; set; }

    /*public PreviewRequest(string s1, string s2, List<string> strings) : this()
    {
        HostId = new HostId(s1, s2);                                                    // implement
        SelectorsDictionary = new SelectorsDictionary(strings);                         // implement
    }*/

    public PreviewRequest()
    {
        HostId = new HostId
        {
            Type = ConfigDat.HostType,
            Value = ConfigDat.HostId
        };
    }

    public string SerializePreviewRequest(PreviewRequest previewRequest)
    {
        return JsonConvert.SerializeObject(previewRequest);
    }

    public static void InjectSelectorsDictionary(string jsonPreviewRequest)
    {
        ParseSelectorsString(jsonPreviewRequest);

        Debug.Log($"{jsonPreviewRequest}");

        JObject jsonParse = JObject.Parse(jsonPreviewRequest);
        jsonParse.Add(new JProperty("selectorsDictionary", new JObject(new JProperty("ROLE", "ANY"), new JProperty("REGION", "EMEA"))));

        string temp = JsonConvert.SerializeObject(jsonParse);
        Debug.Log($"{temp}");
    }

    private static void ParseSelectorsString(string jsonPreviewRequest)
    {
        //string temp = ConfigDat.SelectorsDictionary;
        //Debug.Log($"{temp}");

        string[] items = ConfigDat.SelectorsDictionary.Split(new string[] { "," }, StringSplitOptions.None);
        string[] trimmedItems = items;
        char[] charsToTrim = { '{', '\"', '}' };

        //{ "ROLE": "ANY", "REGION": "EMEA"}
        for (int i = 0; i < items.Length; i++)
        {
            //Debug.Log($"{items[i]}");
            trimmedItems[i] = items[i].Trim(charsToTrim);
            items[i] = trimmedItems[i].Replace("\"", string.Empty);

            Debug.Log($"{items[i]}");
        }
    }
}

