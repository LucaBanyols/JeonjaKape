using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp_Disjoncted : MonoBehaviour
{
    public GameObject light;
    public Renderer lightBulb;
    public Material offlight, onlight;
    public AudioSource lightSwitchSound;
	private float countdownTimerStartTime;
	private float countdownTimerDuration;

    void Start()
    {
        ResetTimer(Random.Range(0.5f, 3.0f));
    }

    void Update()
    {
        if (GetSecondsRemaining() <= 0.25f)
        {
            lightSwitchSound.Pause();
            light.SetActive(false);
            lightBulb.material = offlight;
            if (GetSecondsRemaining() <= 0.0f)
            {
                lightSwitchSound.UnPause();
                light.SetActive(true);
                lightBulb.material = onlight;
                ResetTimer(Random.Range(0.5f, 3.0f));
            }
        }
    }

	public void ResetTimer(float seconds)
	{
		countdownTimerStartTime = Time.time;
		countdownTimerDuration = seconds;
	}

	public float GetSecondsRemaining()
	{
		float elapsedSeconds = (float)(Time.time - countdownTimerStartTime);
		float secondsLeft = (countdownTimerDuration - elapsedSeconds);
		return secondsLeft;
	}
}
