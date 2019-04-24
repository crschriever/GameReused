using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedMessage : MonoBehaviour
{
    public GameObject POPUP;
    public string ID;
    public int TIMES_BEFORE_FIRST_SHOW;
    public bool REPEAT;
    public int TIMES_BETWEEN_SHOW;

    private bool shouldShow = false;

    void Start()
    {
        int times = 0;
        int lastShow = 0;
        if (PlayerPrefs.HasKey("Message_" + ID + "_times"))
        {
            times = PlayerPrefs.GetInt("Message_" + ID + "_times");
            PlayerPrefs.SetInt("Message_" + ID + "_times", times + 1);
        }
        else
        {
            PlayerPrefs.SetInt("Message_" + ID + "_times", 1);
        }

        if (PlayerPrefs.HasKey("Message_" + ID + "_shown"))
        {
            lastShow = PlayerPrefs.GetInt("Message_" + ID + "_shown");
            shouldShow = REPEAT && times - lastShow > TIMES_BETWEEN_SHOW;
        }
        else
        {
            shouldShow = times >= TIMES_BEFORE_FIRST_SHOW;
        }

        if (shouldShow)
        {
            PlayerPrefs.SetInt("Message_" + ID + "_shown", times);
            ShowPopup();
        }

    }

    private void ShowPopup()
    {
        GameObject popup = Instantiate(POPUP);
    }
}
