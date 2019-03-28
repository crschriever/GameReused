using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraColorChange : MonoBehaviour
{

    public Color[] colors;
    public float TIME_BETWEEN_CHANGES;
    public float CHANGE_SPEED;
    private int index;
    private float timeOfLastChange;

    void Start()
    {
        index = Random.Range(0, colors.Length);
        timeOfLastChange = Time.time;
        Camera.main.backgroundColor = colors[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeOfLastChange >= TIME_BETWEEN_CHANGES)
        {
            index = (index + 1) % colors.Length;
            timeOfLastChange = Time.time;
        }

        float r = Mathf.MoveTowards(Camera.main.backgroundColor.r, colors[index].r, CHANGE_SPEED * Time.deltaTime);
        float g = Mathf.MoveTowards(Camera.main.backgroundColor.g, colors[index].g, CHANGE_SPEED * Time.deltaTime);
        float b = Mathf.MoveTowards(Camera.main.backgroundColor.b, colors[index].b, CHANGE_SPEED * Time.deltaTime);

        Camera.main.backgroundColor = new Color(r, g, b);
    }
}
