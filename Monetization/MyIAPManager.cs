using UnityEngine;
using UnityEngine.Purchasing;
using System;
using System.Collections.Generic;

public class MyIAPManager : MonoBehaviour
{
    public GameObject POPUP_PREFAB;

    public void NoAds(Product prod)
    {
        ShowPopup("No Ads purchase completed. Thanks for supporting us. Enjoy the ad free game!");
        PlayerPrefs.SetInt("NoAds", 1);
        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", prod.definition.id));
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        if (!failureReason.Equals(PurchaseFailureReason.UserCancelled))
        {
            // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
            // this reason with the user to guide their troubleshooting actions.
            ShowPopup("Unable to complete transaction. Reason: " + failureReason);

            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }
    }

    private void ShowPopup(string body)
    {
        GameObject popup = Instantiate(POPUP_PREFAB);
        popup.GetComponent<PopupManager>().ShowModal("Purchase", body);
    }
}