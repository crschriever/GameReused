using UnityEngine;
using UnityEngine.Purchasing;
using System;
using System.Collections.Generic;

public class MyIAPManager : MonoBehaviour
{
    public GameObject POPUP_PREFAB;
    public string CURRENCY_ID;

    [SerializeField]
    private LeveledStoreItem[] LEVEL_ITEMS;
    public Dictionary<string, LeveledStoreItem> LEVELED_ITEMS = new Dictionary<string, LeveledStoreItem>();

    [SerializeField]
    private RadioStoreItem[] RAD_ITEMS;
    public Dictionary<string, RadioStoreItem> RADIO_ITEMS = new Dictionary<string, RadioStoreItem>();

    public static MyIAPManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;

        if (!PlayerPrefs.HasKey(CURRENCY_ID))
        {
            PlayerPrefs.SetInt(CURRENCY_ID, 0);
        }

        foreach (var entry in LEVEL_ITEMS)
        {
            if (!PlayerPrefs.HasKey(entry.ID))
            {
                PlayerPrefs.SetInt(entry.ID, 0);
            }

            LEVELED_ITEMS[entry.ID] = entry;
        }

        foreach (var entry in RAD_ITEMS)
        {
            Debug.Log("Entry: " + entry.ID);
            if (!PlayerPrefs.HasKey(entry.ID))
            {
                PlayerPrefs.SetInt(entry.ID, entry.DEFAULT);
            }

            RADIO_ITEMS[entry.ID] = entry;
            entry.UnlockIndex(entry.DEFAULT);
        }
    }

    public bool MakeCurrencyPurchase(LeveledStoreItem item)
    {
        int currency = PlayerPrefs.GetInt(CURRENCY_ID);
        LeveledStoreItem.Level nextLevel = item.GetNextLevel();

        if (nextLevel == null)
        {
            return false;
        }

        int cost = nextLevel.cost;
        if (currency >= cost)
        {
            PlayerPrefs.SetInt(CURRENCY_ID, currency - cost);
            item.PurchaseNextLevel();
            return true;
        }

        return false;
    }

    public bool MakeCurrencyPurchase(RadioStoreItem item, int index)
    {
        int currency = PlayerPrefs.GetInt(CURRENCY_ID);

        int cost = item.COST[index];
        if (currency >= cost)
        {
            PlayerPrefs.SetInt(CURRENCY_ID, currency - cost);
            item.UnlockIndex(index);
            return true;
        }

        return false;
    }

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

    public void AddCurrency(int amount)
    {
        PlayerPrefs.SetInt(CURRENCY_ID, PlayerPrefs.GetInt(CURRENCY_ID) + amount);
    }

    public void ClearCurrency()
    {
        PlayerPrefs.SetInt(CURRENCY_ID, 0);
    }

    public void ClearPurchases()
    {
        foreach (var entry in LEVEL_ITEMS)
        {
            PlayerPrefs.SetInt(entry.ID, 0);
        }

        foreach (var entry in RAD_ITEMS)
        {
            for (int ind = 0; ind < entry.COST.Length; ind++)
            {
                PlayerPrefs.SetInt(entry.ID + "_" + ind, 0);
            }
            entry.UnlockIndex(entry.DEFAULT);
        }
    }

    public int GetCurrency()
    {
        return PlayerPrefs.GetInt(CURRENCY_ID);
    }

    public float GetLeveledItemValue(string ID)
    {
        Debug.Log(ID);
        return LEVELED_ITEMS[ID].GetCurrentValue();
    }

    public float GetRadioItemValue(string ID)
    {
        Debug.Log(ID);
        return RADIO_ITEMS[ID].GetCurrentValue();
    }
}