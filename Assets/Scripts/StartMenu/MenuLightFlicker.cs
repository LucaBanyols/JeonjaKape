using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MenuLightFlicker : MonoBehaviour
{
    public float originalIntensity = 6.0f;
    public float minIntensity = 0.5f;
    public float maxIntensity = 6.0f;
    public float minWait = 0.010f;
    public float maxWait = 0.095f;
    public float minInterval = 3f;
    public float maxInterval = 6f;
    public float minDuration = 0.1f;
    public float maxDuration = 0.3f;

    private Light light;

    void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minInterval, maxInterval));
            float duration = UnityEngine.Random.Range(minDuration, maxDuration);
            float endTime = Time.time + duration;
            while (Time.time < endTime)
            {
                light.intensity = UnityEngine.Random.Range(minIntensity, maxIntensity);
                yield return new WaitForSeconds(UnityEngine.Random.Range(minWait, maxWait));
            }
            light.intensity = originalIntensity;
        }
    }
}
