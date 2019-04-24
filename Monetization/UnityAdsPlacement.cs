using System;
using UnityEngine;
using UnityEngine.Monetization;
using System.Collections;

[RequireComponent(typeof(UnityAdsScript))]
public class UnityAdsPlacement : MonoBehaviour
{

    private static UnityAdsPlacement instance;

    public static string interstitialId = "video";
    public static string rewardedId = "rewardedVideo";

    void Awake()
    {
        instance = this;
    }

    public static void AddEventOccurred()
    {
        // Debug.Log(AdCount.eventsSinceLastAd);
        // Debug.Log(Time.time - AdCount.lastAdTime);
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
        if (!Monetization.IsReady(interstitialId))
        {
            return;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(interstitialId) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show();
            AdCount.eventsSinceLastAd = 0;
            AdCount.lastAdTime = Time.time;
        }
    }

    public static bool RewardedAdReady()
    {
        return Monetization.IsReady(rewardedId);
    }

    public static void ShowRewardedAd(Action<bool> cb)
    {
        if (!Monetization.IsReady(rewardedId))
        {
            cb(false);
            return;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(rewardedId) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show(result =>
            {
                cb(result == ShowResult.Finished);
            });
        }
    }
}