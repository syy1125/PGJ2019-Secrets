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
	private Image _image;

	private void Start()
	{
		_image = GetComponent<Image>();
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
		yield return new WaitForSeconds(FadeDuration);

		AsyncOperation loadOp = SceneManager.LoadSceneAsync(NextScene);
		yield return new WaitForSeconds(HoldDuration);
		yield return new WaitUntil(() => loadOp.isDone);

		_image.CrossFadeAlpha(0, FadeDuration, false);
		yield return new WaitForSeconds(FadeDuration);

		Destroy(transform.parent.gameObject);

		InTransition = false;
	}
}