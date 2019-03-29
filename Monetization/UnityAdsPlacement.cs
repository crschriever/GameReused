using UnityEngine;
using UnityEngine.Monetization;
using System.Collections;

public class UnityAdsPlacement : MonoBehaviour
{

    private static UnityAdsPlacement instance;

    public string placementId = "video";

    void Awake()
    {
        instance = this;
    }

    public static void AddEventOccurred()
    {
        Debug.Log(AdCount.eventsSinceLastAd);
        Debug.Log(Time.time - AdCount.lastAdTime);
        AdCount.eventsSinceLastAd++;
        if (AdCount.eventsSinceLastAd >= AdCount.eventsBeforeAd && Time.time - AdCount.lastAdTime >= AdCount.timeBeforeAd)
        {
            ShowAd();
        }
    }

    public static void ShowAd()
    {
        if (PlayerPrefs.HasKey("NoAds") && PlayerPrefs.GetInt("NoAds") == 1)
        {
            return;
        }
        instance.ShowAdIfReady();
    }

    private void ShowAdIfReady()
    {
        if (!Monetization.IsReady(placementId))
        {
            return;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show();
            AdCount.eventsSinceLastAd = 0;
            AdCount.lastAdTime = Time.time;
        }
    }
}