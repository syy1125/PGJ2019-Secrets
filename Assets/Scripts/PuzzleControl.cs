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
			Input = "";
			OnFailure.Invoke();
			Invoke(nameof(ClearInput), 1);
		}
	}

	private void ClearInput()
	{
		OnInputChange.Invoke();
	}
}