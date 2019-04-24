using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private float intensity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shake(float intensity, float time)
    {
        // Debug.Log("Shake");
        this.intensity = intensity;
        InvokeRepeating("MoveCamera", 0, .05f);
        Invoke("ReturnToCenter", time);
    }

    private void MoveCamera()
    {
        float offX = Random.Range(-intensity, intensity);
        float offY = Random.Range(-intensity, intensity);

        transform.localPosition = new Vector3(offX, offY, transform.position.z);
    }

    private void ReturnToCenter()
    {
        CancelInvoke("MoveCamera");
        transform.localPosition = new Vector3(0, 0, transform.position.z);
    }
}
