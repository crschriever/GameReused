using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateButton : MonoBehaviour
{

    public string APP_NAME;
    public string APPLE_STR;
    public void Rate()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + APP_NAME);

#elif UNITY_IOS
        Application.OpenURL("itms-apps://itunes.apple.com/app/" + APPLE_STR);

#endif

    }
}
