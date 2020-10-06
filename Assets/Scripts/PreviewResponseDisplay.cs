using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewResponseDisplay : MonoBehaviour
{
    public static string JsonPreviewResponse { get; set; }
    public static int PreviewResponseBytes { get; set; }
    private static int CurrentNumBytes { get; set; }

    public static IEnumerator PollPreviewResponseChange()
    {
        while(true)
        {
            //Debug.Log($"{JsonPreviewResponse}");
            //Debug.Log($"{PreviewResponseBytes}");
            //Debug.Log($"{CurrentNumBytes}");

            if (!string.IsNullOrEmpty(JsonPreviewResponse) && (PreviewResponseBytes != 0))
            {
                CurrentNumBytes = PreviewResponseBytes;
                Display();
            }

            yield return new WaitForSeconds(2);
        }
    }

    public static void Display()
    {
        Text text = GameObject.FindGameObjectWithTag("PreviewResponseText").GetComponent<Text>();

        //Debug.Log(JsonPreviewResponse);

        var previewResponse  = PreviewResponse.DeserializePreviewResponse(JsonPreviewResponse);

        if (previewResponse.Features.Count == 0)
        {
            text.text = "No licenses available";
        }

        else
        {
            foreach (var feature in previewResponse.Features)
            {

                var timeSpan = feature.expires - DateTime.Today;
                var days = timeSpan.Days;

                //Debug.Log("Feature: " + $"{feature.name}" + "\t\tAvailable: " + $"{feature.count}" + "\t\tTotal: " + $"{feature.maxCount}" + "\t\tExpiration: " + $"{feature.expires.ToLongDateString()}");
                text.text = "Feature: " + $"{feature.name}" + "\t\t\tAvailable: " + $"{feature.count}" + "\t\tTotal: "
                            + $"{feature.maxCount}"  + "\t\t\tLicense Expiry: " + $"{feature.entitlementExpiry}" + "\t\tMax Borrow: " + $"{days}" + " days";
            }
        }
       
    }
}
