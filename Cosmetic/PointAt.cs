using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAt : MonoBehaviour
{
    public GameObject target;
    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;
            transform.up = dir;
        }
    }
}
