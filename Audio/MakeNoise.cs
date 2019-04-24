using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNoise : MonoBehaviour
{
    public string NOISE_ID;

    public void Noise()
    {
        SoundManager.PlaySound(NOISE_ID);
    }
}
