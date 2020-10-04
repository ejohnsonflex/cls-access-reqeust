using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display
{
    [SerializeField]
    Text text = GameObject.FindGameObjectWithTag("Display").GetComponent<Text>();

    public static void ShowPreviewResponse ()
    {
        //Debug.Log(jsonString);

        //var pr = PreviewResponse.DeserializePreviewResponse(jsonString);

        //Debug.Log("Feature Count: " + pr.Features.Count);
        //Debug.Log("StatusList Count: " + pr.StatusList.Count);


    }
}
