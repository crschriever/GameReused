using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnScreen : MonoBehaviour
{
    public float OFFSET_LEFT;
    public float OFFSET_RIGHT;
    public float OFFSET_TOP;
    public float OFFSET_BOTTOM;

    void LateUpdate()
    {
        var vertExtent = Camera.main.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        float minX = Camera.main.transform.position.x - horzExtent + OFFSET_LEFT;
        float maxX = Camera.main.transform.position.x + horzExtent - OFFSET_RIGHT;
        float minY = Camera.main.transform.position.y - vertExtent + OFFSET_BOTTOM;
        float maxY = Camera.main.transform.position.y + vertExtent - OFFSET_TOP;

        Vector3 t = transform.position;
        t.x = Mathf.Clamp(t.x, minX, maxX);
        t.y = Mathf.Clamp(t.y, minY, maxY);

        transform.position = t;
    }
}
