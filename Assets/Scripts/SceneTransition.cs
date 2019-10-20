using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
	public static bool InTransition = false;

	public float FadeDuration;
	public float HoldDuration;
	public string NextScene;
	public AnimationCurve VolumeCurve;
	private AudioSource _audio;
	private Image _image;

	private void Start()
	{
		_audio = GetComponent<AudioSource>();
		_image = GetComponent<Image>();
	}

	public void SetNextScene(string sceneName)
	{
		NextScene = sceneName;
	}

	public void Transition(string sceneName)
	{
		NextScene = sceneName;
		Transition();
	}

	public void Transition()
	{
		StartCoroutine(DoTransition());
	}

	private IEnumerator DoTransition()
	{
		InTransition = true;

		DontDestroyOnLoad(transform.parent.gameObject);

		_image.color = Color.white;
		_image.CrossFadeAlpha(0, 0, true);

		_image.CrossFadeAlpha(1, FadeDuration, false);
		float fadeInStartTime = Time.time;

		if (_audio.isActiveAndEnabled)
		{
			_audio.Play();
		}

		while ((Time.time - fadeInStartTime) < FadeDuration)
		{
			_audio.volume = VolumeCurve.Evaluate((Time.time - fadeInStartTime) / FadeDuration);
			yield return null;
		}

		_audio.volume = VolumeCurve.Evaluate(1);

		AsyncOperation loadOp = SceneManager.LoadSceneAsync(NextScene);
		yield return new WaitForSeconds(HoldDuration);
		yield return new WaitUntil(() => loadOp.isDone);

		_image.CrossFadeAlpha(0, FadeDuration, false);
		float fadeOutStartTime = Time.time;
		while ((Time.time - fadeOutStartTime) < FadeDuration)
		{
			_audio.volume = VolumeCurve.Evaluate(1 - (Time.time - fadeOutStartTime) / FadeDuration);
			yield return null;
		}

		if (_audio.isActiveAndEnabled)
		{
			_audio.Stop();
		}

		Destroy(transform.parent.gameObject);

		InTransition = false;
	}
}