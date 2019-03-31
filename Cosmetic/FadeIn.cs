using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float FADE_SPEED;
    private SpriteRenderer renderer;
    private bool shouldFade;
    private

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void OnAwake()
    {
        shouldFade = true;
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0);
    }

    void Update()
    {
        if (shouldFade)
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b,
                Mathf.MoveTowards(renderer.color.a, 1, FADE_SPEED * Time.deltaTime));

            if (renderer.color.a == 1)
            {
                shouldFade = false;
            }
        }
    }
}
