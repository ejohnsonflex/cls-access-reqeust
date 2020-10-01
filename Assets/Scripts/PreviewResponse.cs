using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewResponse
{
    public RequestHostId requestHostId { get; set; }
    public List<FeatureResponse> features { get; set; }
    public List<StatusList> statusList { get; set; }
}
