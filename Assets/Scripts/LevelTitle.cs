using System.Collections;
using UnityEngine;

public class LevelTitle : MonoBehaviour
{
	public float HoldDuration;
	public float FadeDuration;
	
	private IEnumerator Start()
	{
		yield return new WaitWhile(() => SceneTransition.InTransition);
		yield return new WaitForSeconds(HoldDuration);

		var group = GetComponent<CanvasGroup>();
		float startTime = Time.time;
		while ((Time.time - startTime) < FadeDuration)
		{
			group.alpha = 1 - (Time.time - startTime) / FadeDuration;
			yield return null;
		}

		group.alpha = 0;
	}
}