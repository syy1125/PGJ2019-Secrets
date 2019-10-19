using UnityEngine;
using UnityEngine.Events;

public class ButtonControl : MonoBehaviour
{
	[Header("References")]
	public Transform PlayerHeadTransform;
	public Animator Animator;

	private static readonly int Focused = Animator.StringToHash("Focused");

	public UnityEvent OnClick;

	private void Update()
	{
		if (Physics.Raycast(PlayerHeadTransform.position, PlayerHeadTransform.forward, out RaycastHit hit))
		{
			Animator.SetBool(Focused, hit.collider.gameObject == gameObject);
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				OnClick.Invoke();
			}
		}
		else
		{
			Animator.SetBool(Focused, false);
		}
	}
}