using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatSpawn : MonoBehaviour
{
    public GameObject PREFAB;
    public Vector3 offset;

    // Update is called once per frame
    public void Spawn()
    {
        GameObject spawn = Instantiate(PREFAB);
        spawn.transform.position = transform.position + offset;
    }
}
