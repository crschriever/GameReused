using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeveledStoreItemDisplay : MonoBehaviour
{
    private LeveledStoreItem item;

    [Header("Format")]
    public string LABEL_FORMAT_STRING;
    public string COST_FORMAT_STRING;

    [Header("Leveled Item")]
    public string LEVELED_ITEM_ID;

    [Header("Display")]
    public Text LABEL;
    public Text COST;
    public Button BUY_BUTTON;
    public Text MAXED_LABEL;
    public GameObject POPUP_PREFAB;

    // Start is called before the first frame update
    void Start()
    {
        item = MyIAPManager.instance.LEVELED_ITEMS[LEVELED_ITEM_ID];
        LABEL_FORMAT_STRING = LABEL_FORMAT_STRING.Replace("\\n", "\n");
        COST_FORMAT_STRING = COST_FORMAT_STRING.Replace("\\n", "\n");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        LeveledStoreItem.Level level;
        if (item.MaxedOut())
        {
            level = item.GetCurrentLevel();
            BUY_BUTTON.gameObject.SetActive(false);
            MAXED_LABEL.gameObject.SetActive(true);
        }
        else
        {
            BUY_BUTTON.gameObject.SetActive(true);
            MAXED_LABEL.gameObject.SetActive(false);
            level = item.GetNextLevel();
        }

        LABEL.text = string.Format(LABEL_FORMAT_STRING, level.label);
        COST.text = string.Format(COST_FORMAT_STRING, level.cost);
    }

    public void Purchase()
    {
        if (!MyIAPManager.instance.MakeCurrencyPurchase(item))
        {
            ShowPopup("Not enough coins to purchase this item. Tap Get More for more coins.");
        }
    }

    private void ShowPopup(string body)
    {
        GameObject popup = Instantiate(POPUP_PREFAB);
        popup.GetComponent<PopupManager>().ShowModal("Purchase", body);
    }
}
