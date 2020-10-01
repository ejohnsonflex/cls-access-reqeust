using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureResponse
{
    public string name { get; set; }
    public string version { get; set; }
    public int count { get; set; }
    public DateTime expires { get; set; }
    public string entitlementExpiry { get; set; }
    public string finalExpiry { get; set; }
    public string vendorString { get; set; }
    public int maxCount { get; set; }
}
