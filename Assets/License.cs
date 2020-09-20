//----------------------------------------------
//  Accredetation
//  LitJson Ruler
// © 2015 yedo-factory
//----------------------------------------------

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
        //string url = "https://flex13005-uat.compliance.flexnetoperations.eu/api/1.0/instances/YBS5ZZR2N8X5/authorize";

        [System.Serializable]
        public class HostId
        {
            public string type = "string";
            public string value = ConfigManager.ReturnHostID();
        }

        [System.Serializable]
        public class Feature
        {
            public int count = ConfigManager.ReturnCount();
            public string name = ConfigManager.ReturnFeature();
            public string version = ConfigManager.ReturnVersion();

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

                Feature feature = new Feature();
                features.Add(feature);
            }
        }

        public void CmapiAccessRequest()
        {
            // Connected to License Button and OnClick EventSystem / CmapiAccessRequest
            StartCoroutine(AccessRequest());
        }


        IEnumerator AccessRequest()
        {
            string url = "https://flex13005-uat.compliance.flexnetoperations.eu/api/1.0/instances/0YBV7VG7HDL1/access_request";

            //string[] data = ConfigManager.AccessRequestData();
            AccessRequestBody accessRequestBody = new AccessRequestBody();

            string json = JsonConvert.SerializeObject(accessRequestBody);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            //Debug.Log(json);

            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            
            string getByte = Encoding.ASCII.GetString(bodyRaw);
            //Debug.Log(getByte);

            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwicm9sZXMiOiJST0xFX0NBUEFCSUxJVFkifQ.C8K43qlPcD8GR5ZfhqsZkPfc_Srkcx9RYnF5gcSeIik6dT9yIFaWJrBTzo5Ar0Yj0jfFXp0XdoWi6dS2vATgl31aBFHC4hcOf_kz2aAzS7FuWEelIxauYWz2kfJxS5VPqwRlKLFd7V1rXFVcUbIqbUScN0tyyUkeNgXHDa2oM4fELhflqMlrLqvwJPmONNQAhhYhXX67JLRimV0jmmAG3MN48T3FsjBMUOJEU2kUwJSX-RjggfG39DuOKiXb7b68e2PevDmcwgjKh6CVSXp9bds3jGTraYe6iQKUFYhyGJHHhzdArXLiUrra0xuKlwN38aDp9qcJgMaFpi3oW7rmlw");

            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.downloadHandler.text);
            }

            Debug.Log("Status Code: " + request.responseCode);
            Debug.Log("Number of Bytes: " + request.downloadedBytes);

            string results = request.downloadHandler.text;

            ResponseBody.CmapiResponse cmapiResponse = new ResponseBody.CmapiResponse();
            cmapiResponse = JsonConvert.DeserializeObject<ResponseBody.CmapiResponse>(results);

            Debug.Log("HostId: " + cmapiResponse.requestHostId.value);
            Debug.Log("Expiration: " + cmapiResponse.features[0].expires);
            Debug.Log("Vendor String: " + cmapiResponse.features[0].vendorString);
        }
    }
}









