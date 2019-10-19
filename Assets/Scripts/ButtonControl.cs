using UnityEngine;
using UnityEngine.Events;

public class ButtonControl : MonoBehaviour
{
	[Header("References")]
	public Transform PlayerHeadTransform;

	public Animator Animator;

	private static readonly int Focused = Animator.StringToHash("Focused");

	public UnityEvent OnClick;
	private bool _hasAnimator;

	private void Start()
	{
		_hasAnimator = Animator != null;
	}
	
	private void Update()
	{
		if (Physics.Raycast(PlayerHeadTransform.position, PlayerHeadTransform.forward, out RaycastHit hit))
		{
			if (_hasAnimator)
			{
				Animator.SetBool(Focused, hit.collider.gameObject == gameObject);
			}
			if (hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.Mouse0))
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
}