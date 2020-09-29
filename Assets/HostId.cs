using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HostId
{
    public string type { get; private set; }
    public string value { get; private set; }

    public HostId() { }

    public HostId(string s1, string s2)     // implement
    {
        type = s1;
        value = s2;
    }
}
