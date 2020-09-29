using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Unity;
using UnityEngine;


[System.Serializable]
public class PreviewRequest
{
    public HostId hostId { get; private set; }
    public List<Feature> features { get; private set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string ROLE { get; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string REGION { get; }

    public PreviewRequest(string s1, string s2) : this()
    {
        hostId = new HostId(s1, s2);
    }

    public PreviewRequest()
    {
        features = new List<Feature>();
         
    }

    public static void PreviewRequestTest()
    {
        //private string selectorsDictionary = "";
        string clsUrl = CMAPI.CLSURL.ClsURl.Url() + "/preview_request";

        //Debug.Log(clsUrl);

        //var t = new HostId("string", "ejohnson@revenera.com");
        //Debug.Log(t.Type);
        //Debug.Log(t.Value);

        //var f = new Feature(1, "dsr", "1.0");
        //Debug.Log(f.Name);
        //Debug.Log(f.Version);
        //Debug.Log(f.Count);

        var p = new PreviewRequest("string", "ejohnson@revenera.com");
        var f = new Feature(1, "dsr", "1.0");
        p.features.Add(f);

        Debug.Log(p.hostId.type);
        Debug.Log(p.hostId.value);
        Debug.Log("Feature count: " + p.features.Count);

        foreach (var Feature in p.features)
        {
            Debug.Log(Feature.name + "     " + Feature.version + "     " + Feature.count);
        }
    }
}

