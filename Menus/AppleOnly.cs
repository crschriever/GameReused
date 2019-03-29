using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleOnly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_IOS
#else
        this.gameObject.SetActive(false);
#endif
    }
}
