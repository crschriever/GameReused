using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayRewardedAd : MonoBehaviour
{
    public UnityEvent ON_COMPLETE;
    public GameObject POPUP_PREFAB;

    public void PlayAd()
    {
        if (!UnityAdsPlacement.RewardedAdReady())
        {
            ShowPopup("Sorry, we were unable to load the ad.");
        }
        else
        {
            UnityAdsPlacement.ShowRewardedAd((succ) =>
            {
                if (succ)
                {
                    ON_COMPLETE.Invoke();
                }
                else
                {
                    ShowPopup("You must finish watching the ad to receive your reward.");
                }
            });
        }
    }

    private void ShowPopup(string body)
    {
        GameObject popup = Instantiate(POPUP_PREFAB);
        popup.GetComponent<PopupManager>().ShowModal("Rewarded Ad", body);
    }
}
