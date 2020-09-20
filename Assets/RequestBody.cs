using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace CMAPI
{
    public class RequestBody : MonoBehaviour
    {
        [System.Serializable]
        public class HostId
        {
            public string type = "string";
            public string value = ConfigManager.ReturnHostID();
        }

        [System.Serializable]
        public class Feature
        {
            //public int count = ConfigManager.ReturnCount();
            public int count = 0;
            public string name = string.Empty;
            public string version = string.Empty;

        }

        [System.Serializable]
        public class AccessRequestBody
        {
            public HostId hostId = new HostId();
            public bool incremental = true;
            [JsonProperty("borrow-interval")]   // Decorator 
            public string borrow_interval = ConfigManager.ReturnBorrowInterval();
            public bool partial = true;
            public List<Feature> features = new List<Feature>();

            public AccessRequestBody()
            {
                string incremental = ConfigManager.ReturnIncremental();
                string partial = ConfigManager.ReturnPartial();

                if (ConfigManager.ReturnIncremental() != "false")
                {
                    this.incremental = true;
                }

                else
                {
                    this.incremental = false;
                }

                if (ConfigManager.ReturnPartial() != "false")
                {
                    this.partial = true;
                }

                else
                {
                    this.partial = false;
                }

                Debug.Log("NumFeatures = " + ConfigManager.NumFeatures().ToString());

                for (int i=0; i < ConfigManager.NumFeatures(); i++)
                {
                    Feature feature = new Feature();
                    
                    feature.count = ConfigManager.ReturnCounts()[i];
                    feature.name = ConfigManager.ReturnFeatures()[i];
                    feature.version = ConfigManager.ReturnVersions()[i];

                    features.Add(feature);
                }
            }
        }
    }
}


