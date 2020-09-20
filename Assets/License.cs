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
using System.Linq;

namespace CMAPI
{
    public class License : MonoBehaviour
    {
        //string url = "https://flex13005-uat.compliance.flexnetoperations.eu/api/1.0/instances/YBS5ZZR2N8X5/authorize";

        public void CmapiAccessRequest()
        {
            // Connected to License Button and OnClick EventSystem / CmapiAccessRequest
            StartCoroutine(AccessRequest());
        }

        IEnumerator AccessRequest()
        {
            string url = "https://flex13005-uat.compliance.flexnetoperations.eu/api/1.0/instances/0YBV7VG7HDL1/access_request";

            RequestBody.AccessRequestBody accessRequestBody = new RequestBody.AccessRequestBody();

            string json = JsonConvert.SerializeObject(accessRequestBody);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            Debug.Log(json);

            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            
            string getByte = Encoding.ASCII.GetString(bodyRaw);
            //Debug.Log(getByte);

            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + ConfigManager.ReturnBearerToken());

            //request.downloadHandler.

            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.downloadHandler.text);
            }

            string results = request.downloadHandler.text;
            //byte[] byteresults = request.downloadHandler.data;  //new

            Debug.Log("Status Code: " + request.responseCode);
            //Debug.Log("Number of Bytes: " + request.downloadedBytes);

            ResponseBody.CmapiResponse cmapiResponse = new ResponseBody.CmapiResponse();
            cmapiResponse = JsonConvert.DeserializeObject<ResponseBody.CmapiResponse>(results);

            //byte[] bites = Encoding.ASCII.GetBytes(results);
            //Debug.Log(bites);

            Debug.Log(cmapiResponse.featureList[0].name + " license, succcessfully acquired by: " + cmapiResponse.requestHostId.value + " expiring: " + cmapiResponse.featureList[0].expires);
            //Debug.Log("License configuration metadata: " + cmapiResponse.featureList[0].vendorString);


            // Unsuccessful license requests
            bool isEmpty = !cmapiResponse.statusList.Any();
            if (isEmpty)
            {
                // check empty StatusList
                ;
            }

            else
            {
                Debug.Log("Status: " + cmapiResponse.statusList[0].message);
                Debug.Log("Code  : " + cmapiResponse.statusList[0].code);
            }
             
        }
    }
}






