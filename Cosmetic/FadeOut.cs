using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float FADE_SPEED;
    public bool DESTROY_ON_FADE = true;
    private SpriteRenderer renderer;
    private Image image;
    private Text text;
    private CanvasGroup cG;
    private bool shouldFade;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
        text = GetComponent<Text>();
        cG = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (shouldFade)
        {
            if (renderer != null)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Mathf.MoveTowards(renderer.color.a, 0, FADE_SPEED * Time.deltaTime));

                if (renderer.color.a == 0)
                {
                    Remove();
                    renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1);
                }
            }
            else if (image != null)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.MoveTowards(image.color.a, 0, FADE_SPEED * Time.deltaTime));

                if (image.color.a == 0)
                {
                    Remove();
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                }
            }
            else if (text != null)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.MoveTowards(text.color.a, 0, FADE_SPEED * Time.deltaTime));

                if (text.color.a == 0)
                {
                    Remove();
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                }
            }
            else if (cG != null)
            {
                cG.alpha = Mathf.MoveTowards(cG.alpha, 0, FADE_SPEED * Time.deltaTime);

                if (cG.alpha == 0)
                {
                    Remove();
                    cG.alpha = 1;
                }

            }
        }
    }

    public void Fade()
    {
        Debug.Log("Fade");
        this.gameObject.SetActive(true);
        shouldFade = true;
    }

    private void Remove()
    {
        if (DESTROY_ON_FADE)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        shouldFade = false;
    }
}
