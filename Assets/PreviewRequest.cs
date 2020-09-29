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

    public static void PreviewRequestTest()
    {
        //private string selectorsDictionary = "";
        //string clsUrl = CMAPI.CLSURL.ClsURl.Url() + "/preview_request";

        //Debug.Log(clsUrl);

        //var t = new HostId("string", "ejohnson@revenera.com");
        //Debug.Log(t.Type);
        //Debug.Log(t.Value);

        //var f = new Feature(1, "dsr", "1.0");
        //Debug.Log(f.Name);
        //Debug.Log(f.Version);
        //Debug.Log(f.Count);

        //var p = new PreviewRequest("string", "ejohnson@revenera.com");
        //var f = new Feature(1, "dsr", "1.0");
        //p.features.Add(f);

        //var sD = new SelectorsDictionary("ANY", "EMEA");
        //p.selectorsDictionaries.Add(sD);

        //Debug.Log(p.hostId.type);
        //Debug.Log(p.hostId.value);
        //Debug.Log("Feature count: " + p.features.Count);

        //foreach (var Feature in p.features)
        //{
         //   Debug.Log(Feature.name + "     " + Feature.version + "     " + Feature.count);
        //}
    }
}

