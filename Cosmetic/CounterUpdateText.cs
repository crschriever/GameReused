using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CounterUpdateText : MonoBehaviour
{
    public string FORMAT;
    public float time;
    private Text text;
    private float currentValue = 0;
    private float targetValue = 0;
    private float vel = 0;

    public float MIN_PULSE = 1;
    public float GROW_AMOUNT = 0;
    public float DOWN_SIZE_AMOUNT = 0;
    public float MAX_PULSE = 1;
    private float pulseAmount;
    private Pulse pulse;

    void Start()
    {
        text = GetComponent<Text>();
        pulse = GetComponent<Pulse>();
        pulseAmount = MIN_PULSE;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = Mathf.SmoothDamp(currentValue, targetValue, ref vel, time);
        text.text = string.Format(FORMAT, currentValue);
    }

    public void SetValue(float value)
    {
        pulseAmount += GROW_AMOUNT * (value - targetValue);
        pulseAmount = Mathf.Clamp(pulseAmount, MIN_PULSE, MAX_PULSE);
        if (pulse != null)
        {
            pulse.minScale = new Vector3(pulseAmount - DOWN_SIZE_AMOUNT, pulseAmount - DOWN_SIZE_AMOUNT, pulse.minScale.z);
            pulse.maxScale = new Vector3(pulseAmount, pulseAmount, pulse.maxScale.z);
        }
        else
        {
            transform.localScale = new Vector3(pulseAmount, pulseAmount, transform.localScale.z); ;
        }
        targetValue = value;

    }

    public void JumpToValue(float value)
    {
        currentValue = targetValue = value;
    }
}
