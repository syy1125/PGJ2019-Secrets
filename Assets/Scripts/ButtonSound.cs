using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [Header("References")]
    public AudioSource Audio;
    
    [Header("Config")]
    public float SoundDuration;
    public AnimationCurve VolumeCurve;
    
    private bool _played;

    private void Start()
    {
        _played = false;
    }

    public void PlaySound()
    {
        if (_played) return;
        StartCoroutine(DoPlaySound());
    }

    private IEnumerator DoPlaySound()
    {
        _played = true;

        float startTime = Time.time;
        Audio.Play();
        while ((Time.time - startTime) < SoundDuration)
        {
            Audio.volume = VolumeCurve.Evaluate((Time.time - startTime) / SoundDuration);
            yield return null;
        }

        Audio.Stop();
    }
}
