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
		if (SceneTransition.InTransition)
		{
			_body.velocity = Vector3.zero;
			return;
		}
		
		var input = new Vector3(
			Input.GetAxisRaw("Horizontal"),
			0,
			Input.GetAxisRaw("Vertical")
		);

		if (input.magnitude > 1)
		{
			input.Normalize();
		}
		
		_body.velocity = Speed * transform.TransformVector(input);
	}
}