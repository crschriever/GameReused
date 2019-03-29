using UnityEngine.Monetization;
using UnityEngine;

public class UnityAdsScript : MonoBehaviour
{

#if UNITY_ANDROID
    string gameId = "3009086";
#endif
#if UNITY_IOS
    string gameId = "3009087";
#endif
    bool testMode = false;

    void Start()
    {
        Monetization.Initialize(gameId, testMode);
    }
}