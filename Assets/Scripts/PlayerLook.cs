using UnityEngine;

public class PlayerLook : MonoBehaviour
{
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
	}

	private void Update()
	{
		AngleY += Input.GetAxisRaw("Mouse Y");

		transform.parent.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X"));
	}

	private void LateUpdate()
	{
		transform.localRotation = Quaternion.Euler(-AngleY, 0f, 0f);
	}

	private void OnDisable()
	{
		Cursor.lockState = CursorLockMode.None;
	}
}