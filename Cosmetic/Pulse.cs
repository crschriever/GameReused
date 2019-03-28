using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{

    public Vector3 maxScale;
    public Vector3 minScale;
    public float rate;

    private bool shrinking = false;


    // Update is called once per frame
    void Update()
    {
        if (shrinking)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, minScale, rate * Time.deltaTime);
            if (transform.localScale.Equals(minScale))
            {
                shrinking = false;
            }
        }

        if (!shrinking)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, maxScale, rate * Time.deltaTime);
            if (transform.localScale.Equals(maxScale))
            {
                shrinking = true;
            }
        }
    }
}
