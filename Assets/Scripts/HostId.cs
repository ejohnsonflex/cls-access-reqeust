using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class HostId
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("value")]
    public string Value { get; set; }

    public HostId() { }

    public HostId(string s1, string s2)    
    {
        Type = s1;
        Value = s2;
    }
}
