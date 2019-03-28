using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject followObject;
    public float MIN_CAMERA_SIZE;
    public float MAX_CAMERA_SIZE;
    public float ZOOM_OUT_RATE;
    public float ZOOM_IN_RATE;
    private bool adjustZoom = true;
    private float zoomModifier = 0;

    public float leftPercent;

    public Camera camera;

    void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (followObject == null)
        {
            return;
        }

        float height = camera.orthographicSize;

        // Both ortho and perspective cameras calculate width using height
        float width = height * camera.aspect;

        transform.position = new Vector3(
            followObject.transform.position.x + width - (width * leftPercent),
            followObject.transform.position.y,
            transform.position.z
        );

        if (adjustZoom)
        {
            float wantedZoom = MIN_CAMERA_SIZE + zoomModifier * (MAX_CAMERA_SIZE - MIN_CAMERA_SIZE);
            float zoomRate = wantedZoom < camera.orthographicSize ? ZOOM_IN_RATE : ZOOM_OUT_RATE;
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, wantedZoom, zoomRate * Time.deltaTime);
        }

    }

    public void ResetZoom()
    {
        camera.orthographicSize = MIN_CAMERA_SIZE;
    }

    public void StopAdjustingZoom()
    {
        adjustZoom = false;
    }

    public void SetZoomModifier(float mod)
    {
        if (mod < 0)
        {
            zoomModifier = 0;
        }
        else
        {
            zoomModifier = mod;
        }
    }
}
