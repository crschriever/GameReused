using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ExpandOut : MonoBehaviour
{
    private bool expanding = false;
    private SpriteRenderer renderer;
    public float EXPAND_SPEED;
    public float FADE_SPEED;
    public bool ON_SPAWN = false;
    public bool SHOULD_DESTROY = false;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        if (ON_SPAWN)
        {
            expanding = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (expanding)
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b,
                Mathf.MoveTowards(renderer.color.a, 0, FADE_SPEED * Time.deltaTime));

            if (renderer.color.a == 0)
            {
                if (SHOULD_DESTROY)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                expanding = false;
            }

            gameObject.transform.localScale += new Vector3(EXPAND_SPEED * Time.deltaTime, EXPAND_SPEED * Time.deltaTime, 0);
        }
    }

    public void Expand()
    {
        this.gameObject.SetActive(true);
        expanding = true;
    }
}
