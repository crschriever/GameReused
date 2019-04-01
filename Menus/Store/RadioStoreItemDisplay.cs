using UnityEngine;
using UnityEngine.UI;

public class RadioStoreItemDisplay : MonoBehaviour
{
    private RadioStoreItem item;

    [Header("Format")]
    public string COST_FORMAT_STRING;

    [Header("Leveled Item")]
    public string RADIO_ITEM_ID;
    public int INDEX;

    [Header("Display")]
    public Text COST;
    public Image SELECTED_INDICATOR;
    public GameObject LOCKED;
    public GameObject POPUP_PREFAB;
    // Start is called before the first frame update
    void Start()
    {
        item = MyIAPManager.instance.RADIO_ITEMS[RADIO_ITEM_ID];
        COST_FORMAT_STRING = COST_FORMAT_STRING.Replace("\\n", "\n");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bool unlocked = item.IndexUnlocked(INDEX);
        if (unlocked)
        {
            LOCKED.SetActive(false);
        }
        else
        {
            LOCKED.SetActive(true);
        }

        if (item.GetCurrentValue() == INDEX)
        {
            SELECTED_INDICATOR.color = new Color(SELECTED_INDICATOR.color.r, SELECTED_INDICATOR.color.g, SELECTED_INDICATOR.color.b, 1);
        }
        else
        {
            SELECTED_INDICATOR.color = new Color(SELECTED_INDICATOR.color.r, SELECTED_INDICATOR.color.g, SELECTED_INDICATOR.color.b, 0);
        }
    }

    public void Purchase()
    {
        if (item.IndexUnlocked(INDEX))
        {
            item.SetIndex(INDEX);
        }
        else if (!MyIAPManager.instance.MakeCurrencyPurchase(item, INDEX))
        {
            ShowPopup("Not enough coins to purchase this item. Tap Get More for more coins.");
        }
        else
        {
            item.SetIndex(INDEX);
        }
    }

    private void ShowPopup(string body)
    {
        GameObject popup = Instantiate(POPUP_PREFAB);
        popup.GetComponent<PopupManager>().ShowModal("Purchase", body);
    }
}
