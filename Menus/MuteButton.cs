using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MuteButton : MonoBehaviour
{

    private Image image;
    private Text buttonText;

    void Start()
    {
        image = GetComponent<Image>();
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
        float opacity = PlayerPrefs.GetInt("muted") == 1 ? 1f : .4f;

        image.color = new Color(image.color.r, image.color.g, image.color.b, opacity);
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
