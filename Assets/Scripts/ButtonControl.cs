using System.Collections;
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
		if (PauseMenuControl.Paused) return;
		
		if (Physics.Raycast(PlayerHeadTransform.position, PlayerHeadTransform.forward, out RaycastHit hit))
		{
			if (_hasAnimator)
			{
				Animator.SetBool(Focused, hit.collider.gameObject == gameObject);
			}

			if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.gameObject == gameObject)
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