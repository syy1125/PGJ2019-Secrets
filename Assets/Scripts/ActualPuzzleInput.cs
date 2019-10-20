using UnityEngine;
using UnityEngine.UI;

public class ActualPuzzleInput : MonoBehaviour
{
	[Header("References")]
	public PuzzleControl Control;
	public Text Text;

	private void Start()
	{
		Text.text = Control.Input;
	}

	public void HandleInputChange()
	{
		Text.text = Control.Input;
		Text.color = Color.white;
	}

	public void HandleSuccess()
	{
		Text.color = Color.green;
	}

	public void HandleFailure()
	{
		Text.color = Color.red;
	}
}
