using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using Newtonsoft.Json;

namespace CMAPI
{
    public class License : MonoBehaviour
    {
        string[] data = ConfigManager.AccessRequestData();
        //string url = "https://flex13005-uat.compliance.flexnetoperations.eu/api/1.0/instances/YBS5ZZR2N8X5/authorize";

        [System.Serializable]
        public class HostId
        {
            public string type;
            public string value;

            public HostId()
            {
                this.type = "string";
                this.value = ConfigManager.ReturnHostID();
            }
        }

        [System.Serializable]
        public class Feature
        {
            public int count;
            public string name;
            public string version;

            public Feature()
            {
                this.count = ConfigManager.ReturnCount();
                this.name = ConfigManager.ReturnFeature();
                this.version = ConfigManager.ReturnVersion();
            }
        }

        [System.Serializable]
        public class AccessRequestBody
        {
            public HostId hostId;
            public bool incremental;
            [JsonProperty("borrow-interval")]
            public string borrow_interval;
            public bool partial;
            public List<Feature> features;

            public AccessRequestBody()
            {
                this.hostId = new HostId();

                string incremental = ConfigManager.ReturnIncremental();

                if (ConfigManager.ReturnIncremental() == "false")
                {
                    this.incremental = false;
                }

                else
                {
                    this.incremental = true;
                }

                this.borrow_interval = ConfigManager.ReturnBorrowInterval();

                string partial = ConfigManager.ReturnPartial();

                if (ConfigManager.ReturnPartial() == "false")
                {
                    this.partial = false;
                }

                else
                {
                    this.partial = true;
                }

                Feature feature = new Feature();
                this.features = new List<Feature>();
                features.Add(feature);

            }
        }

        private void GetAccessRequestData()
        {
            data = ConfigManager.AccessRequestData();

            AccessRequestBody accessRequestBody = new AccessRequestBody();

            string json = JsonConvert.SerializeObject(accessRequestBody);
            //[JsonProperty]
            Debug.Log(json);
            //var bodyRaw = Encoding.UTF8.GetBytes(json);
        }
    }
}









