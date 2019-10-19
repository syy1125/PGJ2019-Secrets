using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [Header("References")]
    public AudioSource Audio;

    [Header("Config")]
    public bool Single = true;
    public float SoundDuration;
    public AnimationCurve VolumeCurve;
    
    private bool _played;
    private Coroutine _playCoroutine;

    private void Start()
    {
        _played = false;
    }

    public void PlaySound()
    {
        if (Single && _played) return;

        if (_playCoroutine != null)
        {
            StopCoroutine(_playCoroutine);
        }
        _playCoroutine = StartCoroutine(DoPlaySound());
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
        _playCoroutine = null;
    }
}
