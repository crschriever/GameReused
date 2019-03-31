using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FallAway : MonoBehaviour
{
    public float START_SPEED_MAX;
    public float START_SPEED_MIN;
    public float FALL_ACCELERATION;
    public float FALL_TIME;
    private bool shouldFall;
    private float fallSpeed;
    private float startTime;

    void Update()
    {
        if (shouldFall)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
            fallSpeed += FALL_ACCELERATION * Time.deltaTime;


            if (Time.time - startTime >= FALL_TIME)
            {
                Destroy(this.gameObject);
                shouldFall = false;
            }
        }
    }

    public void Fall()
    {
        fallSpeed = Random.Range(START_SPEED_MIN, START_SPEED_MAX);
        startTime = Time.time;
        this.gameObject.SetActive(true);
        shouldFall = true;
    }
}