using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyPurchase : MonoBehaviour
{
    public int COST;
    public GameObject POPUP_PREFAB;
    public UnityEvent ON_SUCCESS;
    public void Purchase()
    {
        if (!MyIAPManager.instance.MakeCurrencyPurchase(COST))
        {
            ShowPopup("Not enough coins to purchase this item.");
        }
        else
        {
            ON_SUCCESS.Invoke();
        }
    }

    private void ShowPopup(string body)
    {
        GameObject popup = Instantiate(POPUP_PREFAB);
        popup.GetComponent<PopupManager>().ShowModal("Purchase", body);
    }
}
