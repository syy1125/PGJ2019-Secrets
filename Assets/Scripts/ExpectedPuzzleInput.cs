using UnityEngine;
using UnityEngine.UI;

public class ExpectedPuzzleInput : MonoBehaviour
{
	[Header("References")]
	public PuzzleControl Control;
	public Text Text;

	private void Start()
	{
		Text.text = Control.Expected;
	}
}
