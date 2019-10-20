using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HoldButtonControl : MonoBehaviour
{
	[Header("References")]
	public Transform PlayerHead;
	public Image ProgressBar;

	[Header("Config")]
	public float MaxProgress;
	public bool Single = true;

	public UnityEvent OnMaxProgress;

	private bool _clicking;
	private float _progress = 0;

	private void Update()
	{
		bool onTarget = Physics.Raycast(PlayerHead.position, PlayerHead.forward, out RaycastHit hit)
		                && hit.collider.gameObject == gameObject;

		if (Input.GetKeyDown(KeyCode.Mouse0) && onTarget)
		{
			ProgressBar.gameObject.SetActive(true);
		}

		if (!Input.GetKey(KeyCode.Mouse0))
		{
			ProgressBar.gameObject.SetActive(false);
			_progress = 0;
		}

		if (ProgressBar.gameObject.activeSelf)
		{
			_progress += Time.deltaTime;
			ProgressBar.fillAmount = Mathf.Clamp(_progress / MaxProgress, 0, 1);

			if (_progress >= MaxProgress)
			{
				OnMaxProgress.Invoke();
				ProgressBar.gameObject.SetActive(false);
				
				if (Single)
				{
					enabled = false;
				}
			}
		}
	}
}