using System.Collections;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
	public Vector3 Offset;
	public float Duration;
	private Vector3 _start;
	private Vector3 _end;
	private bool _run;

	private void Start()
	{
		_start = transform.position;
		_end = _start + Offset;
		_run = false;
	}

	public void Slide()
	{
		if (_run) return;
		StartCoroutine(DoSlide());
	}

	private IEnumerator DoSlide()
	{
		_run = true;
		float startTime = Time.time;
		while ((Time.time - startTime) < Duration)
		{
			transform.position = Vector3.Lerp(_start, _end, (Time.time - startTime) / Duration);
			yield return null;
		}
		transform.position = _end;
	}

}