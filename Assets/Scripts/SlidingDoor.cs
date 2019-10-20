using System.Collections;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
	public Vector3 Offset;
	public float Duration;
	private bool _run;

	private void Start()
	{
		_run = false;
	}

	public void Slide()
	{
		if (_run) return;
		StartCoroutine(DoSlide());
	}

	private IEnumerator DoSlide()
	{
		Vector3 start = transform.position;
		Vector3 end = start + Offset;
		_run = true;
		
		float startTime = Time.time;
		while ((Time.time - startTime) < Duration)
		{
			transform.position = Vector3.Lerp(start, end, (Time.time - startTime) / Duration);
			yield return null;
		}
		transform.position = end;
	}

}