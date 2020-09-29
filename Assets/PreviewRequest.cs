using System.Collections.Generic;
using Newtonsoft.Json;
[System.Serializable]
public class PreviewRequest
{
    public HostId hostId { get; private set; }
    public List<Feature> features { get; private set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public SelectorsDictionary selectorsDictionary { get; set; }

    public PreviewRequest(string s1, string s2, List<string> strings) : this()
    {
        hostId = new HostId(s1, s2);                                                    // implement
        selectorsDictionary = new SelectorsDictionary(strings);                         // implement
    }

    public PreviewRequest()
    {
        features = new List<Feature>();
    }
}

