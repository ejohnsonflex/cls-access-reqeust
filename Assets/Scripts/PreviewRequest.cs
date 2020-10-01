using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class PreviewRequest
{
    public HostId HostId { get; private set; }
    public List<Feature> Features { get; private set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public SelectorsDictionary SelectorsDictionary { get; set; }

    public PreviewRequest(string s1, string s2, List<string> strings) : this()
    {
        HostId = new HostId(s1, s2);                                                    // implement
        SelectorsDictionary = new SelectorsDictionary(strings);                         // implement
    }

    public PreviewRequest()
    {
        Features = new List<Feature>();
    }
}

