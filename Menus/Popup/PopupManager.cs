using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{

    public Text TITLE;
    public Text BODY;
    // Start is called before the first frame update

    public void ShowModal(string title, string body)
    {
        TITLE.text = title;
        BODY.text = body;
        gameObject.active = true;
    }

    public void OnOkay()
    {
        Destroy(gameObject);
    }
}
