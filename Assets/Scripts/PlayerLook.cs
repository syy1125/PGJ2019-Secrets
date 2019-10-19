using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	private static int _activeCount;
	
	public float MinY;
	public float MaxY;

	private float _angleY;

	private float AngleY
	{
		get => _angleY;
		set => _angleY = Mathf.Clamp(value, MinY, MaxY);
	}


	private void OnEnable()
	{
		Cursor.lockState = CursorLockMode.Locked;
		_activeCount++;
	}

	private void Update()
	{
		if (SceneTransition.InTransition) return;
		
		AngleY += Input.GetAxisRaw("Mouse Y");

		transform.parent.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X"));
	}

	private void LateUpdate()
	{
		transform.localRotation = Quaternion.Euler(-AngleY, 0f, 0f);
	}

	private void OnDisable()
	{
		if (--_activeCount == 0)
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}