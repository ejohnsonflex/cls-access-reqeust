using UnityEngine;
using UnityEngine.UI;

public class FeatureManager
{
    //public Sprite Icon;
    public string Feature, Version, Count, Available, Status;

    //public FeatureManager(Sprite icon, string feature, string version, string count, string total, string status)
    public FeatureManager(string feature, string version, string count, string total, string status)
    {
        //Icon = icon;
        Feature = feature;
        Version = version;
        Count = count;
        Available = total;
        Status = status;
    }
}
