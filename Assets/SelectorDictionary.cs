using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class SelectorsDictionary
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string ROLE { get; private set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string REGION { get; private set; }

    public SelectorsDictionary(List<string> strings)
    {
        string[] array = strings.ToArray();

        for (int i = 0; i < strings.Count; i++)
        {
            if (array[i] != null && array[i] == "ANY")
            {
                ROLE = array[i];
            }

            else if (array[i] != null && array[i] == "EMEA")
            {
                REGION = array[i];
            }

            else
            {
                ;
            }
        }
    }
}
