using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMAPI
{
    public class ResponseBody : MonoBehaviour
    {
        [System.Serializable]
        public class RequestHostId
        {
            public string value;
            public string type;

            public RequestHostId()
            {
                var RequestHostId = new RequestHostId();

                this.value = string.Empty;
                this.type = string.Empty;
            }
        }

        [System.Serializable]
        public class Feature
        {
            public string name;
            public string version;
            public int count;
            public string expires;
            public string finalExpiry;
            public string vendorString;

            public Feature()
            {
                var Feature = new Feature();

                this.name = string.Empty;
                this.version = string.Empty;
                this.count = 0;
                this.expires = string.Empty;
                this.finalExpiry = string.Empty;
                this.vendorString = string.Empty;
            }
        }

        [System.Serializable]
        public class CmapiResponse
        {
            public RequestHostId requestHostId;
            public List<Feature> features;
            public List<object> statusList;

            public CmapiResponse()
            {

            }
        }

    }
}
