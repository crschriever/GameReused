using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{

    public float amount;
    public float speed;
    public bool lockX;
    public bool lockY;

    private Vector2 destination;
    private Vector2 originalPosition;
    private bool movingTowardsOrigin = false;


    void Start()
    {
        originalPosition = transform.position;
        destination = originalPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.Equals(destination))
        {
            if (movingTowardsOrigin)
            {
                float newX = lockX ? 0 : Random.Range(-amount, amount);
                float newY = lockY ? 0 : Random.Range(-amount, amount);
                destination = originalPosition + new Vector2(newX, newY);
            }
            else
            {
                destination = originalPosition;
            }

            movingTowardsOrigin = !movingTowardsOrigin;
        }

        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }
}
