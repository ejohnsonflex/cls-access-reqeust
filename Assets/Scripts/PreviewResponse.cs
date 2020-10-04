using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class PreviewResponse
{
    [JsonProperty("requestHostId")]
    public RequestHostId RequestHostId { get; set; }
    [JsonProperty("features", NullValueHandling = NullValueHandling.Ignore)]
    public List<FeatureResponse> Features { get; set; }
    [JsonProperty("statusList", NullValueHandling = NullValueHandling.Ignore)]
    public List<StatusList> StatusList { get; set; }

    public PreviewResponse()
    {
        RequestHostId = new RequestHostId();
        Features = new List<FeatureResponse>();
        StatusList = new List<StatusList>();
    }

    public void DeserializePreviewResponse(string jsonString)
    {
        Text text = GameObject.FindGameObjectWithTag("Display").GetComponent<Text>();

        var previewResponse = new PreviewResponse();
        previewResponse = JsonConvert.DeserializeObject<PreviewResponse>(jsonString);

        int featureCount = previewResponse.Features.Count;
        int statusListCount = previewResponse.StatusList.Count;

        Debug.Log("Feature Count: " + featureCount);
        Debug.Log("StatusList Count: " + statusListCount);

        text.text = ("Requested HostId: " + previewResponse.RequestHostId.value + "\n");

        for (int i = 0; i < featureCount; i++)
        {
            text.text += ("Feature: " + previewResponse.Features[i].name + "\t\t\tAvailable: " + previewResponse.Features[i].count + "\t\tTotal: " + previewResponse.Features[i].maxCount + "\t\tExpiration: " + previewResponse.Features[i].expires.ToLongDateString());

        }
    }
}