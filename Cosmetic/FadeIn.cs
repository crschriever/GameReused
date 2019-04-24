using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float FADE_SPEED;
    private SpriteRenderer renderer;
    private CanvasGroup canvasGroup;
    public float target = 1;
    private bool shouldFade;

    void OnEnable()
    {
        renderer = GetComponent<SpriteRenderer>();
        canvasGroup = GetComponent<CanvasGroup>();

        shouldFade = true;
        if (renderer != null)
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0);
        }
        else if (canvasGroup != null)
        {
            canvasGroup.alpha = 0;
        }
    }

    void Update()
    {
        if (shouldFade)
        {
            if (renderer != null)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b,
                    Mathf.MoveTowards(renderer.color.a, target, FADE_SPEED * Time.deltaTime));

                if (renderer.color.a == target)
                {
                    shouldFade = false;
                }
            }
            else if (canvasGroup != null)
            {
                canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, FADE_SPEED * Time.deltaTime);

                if (canvasGroup.alpha == target)
                {
                    shouldFade = false;
                }
            }
        }
    }
}
