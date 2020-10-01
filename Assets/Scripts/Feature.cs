// used to Decorate Properties to conform to CMAPI json syntax
using Newtonsoft.Json;

[System.Serializable]
public class Feature
{
    [JsonProperty("count")]                         // Decorator 
    public int Count { get; set; }
    [JsonProperty("Name")]                          // Decorator 
    public string Name { get; set; }
    [JsonProperty("Version")]                       // Decorator 
    public string Version { get; set; }
}