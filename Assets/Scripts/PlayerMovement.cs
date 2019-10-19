using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody _body;

	[Header("Config")]
	public float Speed;

	private void Start()
	{
		_body = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		var input = new Vector3(
			Input.GetAxisRaw("Horizontal"),
			0,
			Input.GetAxis("Vertical")
		);

		if (input.magnitude > 1)
		{
			input.Normalize();
		}
		
		_body.velocity = Speed * transform.TransformVector(input);
	}
}