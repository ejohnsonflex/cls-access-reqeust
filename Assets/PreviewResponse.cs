using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewResponse
{
    public HostId HostId { get; private set; }
    public List<Feature> Feature { get; private set; }
    public SelectorsDictionary selectorsDictionary { get; private set; }

    public PreviewResponse()
    {
        HostId = new HostId();
        Feature = new List<Feature>();
    }
}
