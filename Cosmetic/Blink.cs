using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Blink : MonoBehaviour
{

    public float maxOpacity;
    public float minOpacity;
    public float rate;
    public bool triggered;

    private float currOpacity;
    private bool dimming = true;

    private SpriteRenderer renderer;


    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        currOpacity = renderer.color.a;
    }

    // Update is called once per frame
    void Update()
    {

        if (!triggered)
        {
            return;
        }

        if (currOpacity == minOpacity)
        {
            dimming = false;
        }

        if (currOpacity == maxOpacity)
        {
            dimming = true;
        }

        if (dimming)
        {
            currOpacity = Mathf.MoveTowards(currOpacity, minOpacity, rate * Time.deltaTime);
        }
        else
        {
            currOpacity = Mathf.MoveTowards(currOpacity, maxOpacity, rate * Time.deltaTime);
        }

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, currOpacity);
    }
}
