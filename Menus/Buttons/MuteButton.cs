using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MuteButton : MonoBehaviour
{

    private Image[] images;
    private Text buttonText;
    private Image buttonImage;

    public bool ACTIVE_WHEN_MUTED = true;

    void Start()
    {
        images = GetComponentsInChildren<Image>();
        buttonText = GetComponentInChildren<Text>();

        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
        }
        AudioListener.volume = PlayerPrefs.GetInt("muted") == 1 ? 0 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        float opacity;
        if (ACTIVE_WHEN_MUTED)
        {
            opacity = PlayerPrefs.GetInt("muted") == 1 ? 1f : .4f;
        }
        else
        {
            opacity = PlayerPrefs.GetInt("muted") != 1 ? 1f : .4f;
        }

        foreach (var image in images)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, opacity);
        }
        if (buttonText != null)
        {
            buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, opacity);
        }
    }

    public void Toggle()
    {
        PlayerPrefs.SetInt("muted", PlayerPrefs.GetInt("muted") == 1 ? 0 : 1);
        AudioListener.volume = PlayerPrefs.GetInt("muted") == 1 ? 0 : 1;
    }
}
