using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class PreviewRequest
{
    [JsonProperty("hostId")]
    public HostId HostId { get; set; }
    [JsonProperty("features", NullValueHandling = NullValueHandling.Ignore)]
    public List<Feature> Features { get; set; }
    [JsonProperty("selectorsDictionary", NullValueHandling = NullValueHandling.Ignore )]
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

    public string SerializePreviewRequest(PreviewRequest pR)
    {
        return JsonConvert.SerializeObject(pR);
    }
}

