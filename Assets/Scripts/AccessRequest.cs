using System.Collections.Generic;
// used to Decorate Properties to conform to CMAPI json syntax
using Newtonsoft.Json;                          

[System.Serializable]
public class AccessRequest
{
    public HostId HostId { get; set; }
    [JsonProperty("incremental")]                           // Decorator 
    public string Incremental { get; set; }
    [JsonProperty("borrow-interval")]                       // Decorator 
    public string BorrowInterval { get; set; }
    [JsonProperty("partial")]                               // Decorator 
    public string Partial { get; set; }
    public List<Feature> Features { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public SelectorsDictionary SelectorsDictionary { get; set; }
}