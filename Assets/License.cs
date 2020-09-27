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
using Newtonsoft.Json.Linq;
using LitJson;

namespace CMAPI
{
    public class License : MonoBehaviour
    {
        //string url = "https://flex13005-uat.compliance.flexnetoperations.eu/api/1.0/instances/YBS5ZZR2N8X5/authorize";
        private JsonData jsonData;
        private string jsonString;

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
            //Debug.Log("Number of Byes in Request: " + System.Text.ASCIIEncoding.ASCII.GetByteCount(json));

            UnityWebRequest request = new UnityWebRequest(url, "POST");

            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            string getByte = Encoding.ASCII.GetString(bodyRaw);
            //Debug.Log(getByte);

            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + ConfigManager.ReturnBearerToken());

            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.downloadHandler.text);
            }

            Debug.Log("Status Code: " + request.responseCode);
            Debug.Log("Number of Bytes: " + request.downloadedBytes);
            Debug.Log(request.downloadHandler.text);

            //string json2 = JsonConvert.SerializeObject(request.downloadHandler.text);

            byte[] _byte = Encoding.UTF8.GetBytes(request.downloadHandler.text);
            string results = request.downloadHandler.text;

            string jsonResult = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data);
            Debug.Log(jsonResult);

            jsonString = results;
            jsonData = JsonMapper.ToObject(jsonString);

            Debug.Log(jsonData["features"][0]["name"]);
            Debug.Log(jsonData["features"][0]["expires"]);

            string mystring = results;

            mystring = JValue.Parse(results).ToString(Formatting.Indented);
            Debug.Log(mystring);


            //ResponseBody.CmapiResponse[] entities = JsonHelper.getJsonArray<ResponseBody.CmapiResponse>(jsonResult);
            //entities.Select()
            /* https://www.youtube.com/watch?v=9rPJeRF7S_8&t=226s */




            //CmapiResponse cmapiResponse = new CmapiResponse();
            //cmapiResponse = JsonConvert.DeserializeObject<CmapiResponse>(results);

            //Debug.Log(cmapiResponse.requestHostId.value);



            //ResponseBody.CmapiResponse cmapiResponse = new ResponseBody.CmapiResponse();
            //cmapiResponse = JsonConvert.DeserializeObject<ResponseBody.CmapiResponse>(results);

            //Debug.Log(cmapiResponse.featureList[0].name.ToString());






            //List<ResponseBody.Feature> fl = new List<ResponseBody.Feature>(1);

            //ResponseBody.CmapiResponse player = JsonUtility.FromJson<ResponseBody.CmapiResponse>(results);
            //Debug.Log(player.featureList[0].name);

            //ResponseBody.CmapiResponse cmapiResponse = new ResponseBody.CmapiResponse();

            //cmapiResponse = (ResponseBody.CmapiResponse)JsonConvert.DeserializeObject(results); //keep


            //Debug.Log(cmapiResponse.requestHostId.value);

            //ResponseBody.Feature[] array = cmapiResponse.featureList.ToArray();
            //Debug.Log(array[0].name);
            //Debug.Log("featureListCount= " + cmapiResponse.featureList.Count.ToString());
            //Debug.Log("statusListCount= " + cmapiResponse.statusList.Count.ToString());


            //Debug.Log(cmapiResponse.featureList.ToString());
            //Debug.Log(cmapiResponse.featureList[1].name);
            //Debug.Log(cmapiResponse.featureList[0].name + " license, succcessfully acquired by: " + cmapiResponse.requestHostId.value + " expiring: " + cmapiResponse.featureList[0].expires);
            //Debug.Log("License configuration metadata: " + cmapiResponse.featureList[0].vendorString);


            // Unsuccessful license requests
            /*bool isEmpty = !cmapiResponse.statusList.Any();
            if (isEmpty)
            {
                // check empty StatusList
                ;
            }

            else//
            {
                Debug.Log("Status: " + cmapiResponse.statusList[0].message);
                Debug.Log("Code  : " + cmapiResponse.statusList[0].code);
            }*/

        }



    }

}








