using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Feature
{
    public int count { get; private set; }
    public string name { get; private set; }
    public string version { get; private set; }

    public Feature(int i, string s1, string s2)    // implement
    {
        count = i;
        name = s1;
        version = s2;
    }
}
