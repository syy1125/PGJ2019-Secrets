using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PuzzleControl : MonoBehaviour
{
	public string Expected;
	public string Input;

	public UnityEvent OnInputChange;
	public UnityEvent OnSuccess;
	public UnityEvent OnFailure;

	public void Append(string c)
	{
		Input += c;
		OnInputChange.Invoke();
	}

	public void Submit()
	{
		if (Input.Equals(Expected))
		{
			OnSuccess.Invoke();
		}
		else
		{
			OnFailure.Invoke();
			Invoke("ClearInput", 0.5f);
		}
	}

	private void ClearInput()
	{
		Input = "";
		OnInputChange.Invoke();
	}
}