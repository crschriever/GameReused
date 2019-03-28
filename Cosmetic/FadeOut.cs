using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FadeOut : MonoBehaviour
{
    public float FADE_SPEED;
    private SpriteRenderer renderer;
    private bool shouldFade;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (shouldFade)
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b,
                Mathf.MoveTowards(renderer.color.a, 0, FADE_SPEED * Time.deltaTime));

            if (renderer.color.a == 0)
            {
                Destroy(this.gameObject);
                shouldFade = false;
            }
        }
    }

    public void Fade()
    {
        Debug.Log("Fade");
        this.gameObject.SetActive(true);
        shouldFade = true;
    }
}
