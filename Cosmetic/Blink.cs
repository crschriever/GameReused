using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public float maxOpacity;
    public float minOpacity;
    public float rate;
    public bool triggered;

    private float currOpacity;
    private bool dimming = true;

    private SpriteRenderer renderer;
    private Image image;

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
        currOpacity = renderer == null ? image.color.a : renderer.color.a;
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

        if (renderer != null)
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, currOpacity);
        }

        if (image != null)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, currOpacity);
        }
    }
}
