using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateButton : MonoBehaviour
{

    public string APP_NAME;
    public void Rate()
    {
        Application.OpenURL("market://details?id=" + APP_NAME);
    }
}
