using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeatureListController : MonoBehaviour
{
    //public GameObject FeatureContent;
    public ScrollRect scrollView;
    public GameObject scrolllContent;
    public GameObject featureItemPrefab;

    ArrayList FeatureManagers;

    private void Start()
    {
        FeatureManagers = new ArrayList() { new FeatureManager("ALM", "2020", "1", "5", "OK"), new FeatureManager("ESD", "2020", "1", "1", "Fail") };
        scrollView.verticalNormalizedPosition = 1;

        foreach (FeatureManager featureManager in FeatureManagers)
        {
            //GameObject newFeatureManager = Instantiate(FeaturePrefab) as GameObject;
            //FeatureItemListController controller = newFeatureManager.GetComponent<FeatureItemListController>();
            //controller.Feature.text = featureManager.Feature;
            //controller.Version.text = featureManager.Version;
            //controller.Count.text = featureManager.Count;
            //controller.Available.text = featureManager.Available;
            //controller.Status.text = featureManager.Status;

            GameObject scrollFeatureItemObj = Instantiate(featureItemPrefab);
            scrollFeatureItemObj.transform.SetParent(scrolllContent.transform, false);

            scrollFeatureItemObj.transform.Find("Feature").gameObject.GetComponent<TextMeshProUGUI>().text = ("dsr").ToString();
            

            //controller.Feature.text = featureManager.Feature;
            //controller.Version.text = featureManager.Version;
            //controller.Count.text = featureManager.Count;
            //controller.Available.text = featureManager.Available;
            //controller.Status.text = featureManager.Status;
            //featureScrollItem.transform.SetParent(controller.transform, false);
        }
    }
}
