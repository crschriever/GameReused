using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pulse : MonoBehaviour
{

    public Vector3 maxScale;
    public Vector3 minScale;
    public float TIME_BETWEEN = 0;
    public float rate;
    public UnityEvent ON_MIN;

    private bool shrinking = false;
    private float waiting = 0;


    // Update is called once per frame
    void Update()
    {
        if (shrinking)
        {
            if (waiting < TIME_BETWEEN)
            {
                waiting += Time.deltaTime;
            }
            else
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, minScale, rate * Time.deltaTime);
                if (transform.localScale.Equals(minScale))
                {
                    shrinking = false;
                    ON_MIN.Invoke();
                }
            }
        }

        if (!shrinking)
        {
            waiting = 0;
            transform.localScale = Vector3.MoveTowards(transform.localScale, maxScale, rate * Time.deltaTime);
            if (transform.localScale.Equals(maxScale))
            {
                shrinking = true;
            }
        }
    }
}
