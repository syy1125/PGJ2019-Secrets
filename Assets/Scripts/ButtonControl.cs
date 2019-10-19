using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ButtonControl : MonoBehaviour
{
	[Header("References")]
	public Transform PlayerHeadTransform;
	public Animator Animator;
	public AudioSource Audio;

	[Header("Config")]
	public float SoundDuration;
	public AnimationCurve VolumeCurve;

	private static readonly int Focused = Animator.StringToHash("Focused");

	public UnityEvent OnClick;
	private bool _hasAnimator;
	private bool _played;

	private void Start()
	{
		_hasAnimator = Animator != null;
		_played = false;
	}

	private void Update()
	{
		if (Physics.Raycast(PlayerHeadTransform.position, PlayerHeadTransform.forward, out RaycastHit hit))
		{
			if (_hasAnimator)
			{
				Animator.SetBool(Focused, hit.collider.gameObject == gameObject);
			}

			if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.gameObject == gameObject)
			{
				OnClick.Invoke();
			}
		}
		else
		{
			if (_hasAnimator)
			{
				Animator.SetBool(Focused, false);
			}
		}
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