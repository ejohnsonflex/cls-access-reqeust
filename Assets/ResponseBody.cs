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
            public string value = string.Empty;
            public string type = string.Empty;
        }

        [System.Serializable]
        public class Feature
        {
            public string name = string.Empty;
            public string version = string.Empty;
            public int count = 0;
            public string expires = string.Empty;
            public string finalExpiry = string.Empty;
            public string vendorString = string.Empty;
        }

        [System.Serializable]
        public class StatusList
        {
            public string message = string.Empty;
            public string code = string.Empty;
            public string name = string.Empty;
            public string version = string.Empty;
        }

        [System.Serializable]
        public class CmapiResponse
        {
            public RequestHostId requestHostId = new RequestHostId();
            [SerializeField]
            public List<Feature> featureList = new List<Feature>();
            [SerializeField]
            public List<StatusList> statusList = new List<StatusList>();
        }
    }
}