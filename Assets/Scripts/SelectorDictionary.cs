using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

// Modifying JSON
// https://www.newtonsoft.com/json/help/html/ModifyJson.htm

[System.Serializable]
public class SelectorsDictionary
{
    //[JsonProperty(ConfigDat.SelectorDicionary., NullValueHandling = NullValueHandling.Ignore)]
    public string SelectorKey1 { get; private set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string SelectorKey2 { get; private set; }

    public SelectorsDictionary(List<string> strings)
    {
        string[] array = strings.ToArray();
        Debug.Log("Array Count: " + strings.Count);

        for (int i = 0; i < strings.Count; i++)
        {
            if (array[i] != null && array[i] == "ANY")
            {
                //ROLE = array[i];
                SelectorKey1 = array[i];
            }

            else if (array[i] != null && array[i] == "EMEA")
            {
                //REGION = array[i];
                SelectorKey1 = array[i];
            }

            else
            {
                ;
            }
        }
    }
}
