using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraGroupFollow : MonoBehaviour
{
    private Camera camera;
    public float PADDING_TOP;
    public float PADDING_RIGHT;
    public float PADDING_BOTTOM;
    public float PADDING_LEFT;
    public float MIN_ORTHO_HEIGHT;
    public List<GameObject> objects = new List<GameObject>();
    public float CHANGE_SPEED;
    private Vector3 moveSpeed = Vector3.zero;
    private float zoomSpeed = 0;
    private Bounds screenSize;
    private float ortho;

    void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        screenSize = GetBounds();
        Vector2 center = GetCenter(screenSize);

        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(center.x, center.y, -10), ref moveSpeed, CHANGE_SPEED);

        ortho = WorldSizeToOrthoSize(new Vector2(screenSize.size.x, screenSize.size.y));
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, ortho, ref zoomSpeed, CHANGE_SPEED);

        if (AtDestination())
        {
            zoomSpeed = 0;
            moveSpeed = Vector3.zero;
        }
    }

    public void Jump()
    {
        screenSize = GetBounds();
        Vector2 center = GetCenter(screenSize);
        transform.position = new Vector3(center.x, center.y, -10);

        ortho = WorldSizeToOrthoSize(new Vector2(screenSize.size.x, screenSize.size.y));
        camera.orthographicSize = ortho;
    }

    public bool AtDestination()
    {
        screenSize = GetBounds();
        ortho = WorldSizeToOrthoSize(new Vector2(screenSize.size.x, screenSize.size.y));
        Vector2 center = GetCenter(screenSize);

        // Debug.Log("Center: " + (Mathf.Approximately(center.x, transform.position.x) && Mathf.Approximately(center.y, transform.position.y)) + ", " + center + ", " + new Vector2(transform.position.x, transform.position.y));
        // Debug.Log("Ortho: " + Mathf.Approximately(camera.orthographicSize, ortho));
        return Mathf.Approximately(center.x, transform.position.x) && Mathf.Approximately(center.y, transform.position.y) && Mathf.Approximately(camera.orthographicSize, ortho);
    }

    public Vector2 GetCenter(Bounds bounds)
    {
        Vector2 center = bounds.center; // Get rid of z

        center = new Vector2(center.x + (PADDING_LEFT - ((PADDING_LEFT + PADDING_RIGHT) / 2)), center.y + (PADDING_TOP - ((PADDING_TOP + PADDING_BOTTOM) / 2)));

        return center;
    }

    public Bounds GetBounds()
    {
        if (objects.Count == 0)
        {
            return new Bounds(Vector2.zero, Vector2.zero);
        }

        var bounds = new Bounds(objects[0].transform.position, Vector2.zero);
        for (int i = 1; i < objects.Count; i++)
        {
            if (objects[i] == null)
            {
                continue;
            }
            bounds.Encapsulate(objects[i].transform.position);
        }

        return bounds;
    }

    float WorldSizeToOrthoSize(Vector2 dimensions)
    {
        // height = 2f * ortho
        // width = height * cameraAspect
        // width = 2f * ortho * camerAspect
        float orthoByHeight = (dimensions.y + PADDING_BOTTOM + PADDING_TOP) / 2f;
        float orthoByWidth = (dimensions.x + PADDING_LEFT + PADDING_RIGHT) / (2f * camera.aspect);

        return Mathf.Max(orthoByHeight, orthoByWidth, MIN_ORTHO_HEIGHT);
    }
}
