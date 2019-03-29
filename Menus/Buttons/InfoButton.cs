using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InfoButton : MonoBehaviour
{
    public string LINK;

    public void Open()
    {
        Application.OpenURL(LINK);
    }

}
