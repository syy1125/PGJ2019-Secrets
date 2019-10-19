using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody _body;

	[Header("Config")]
	public float Speed;

    private Vector3 vel;

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

        if (Input.GetButtonDown("Jump") && _body.position.y < -0.4)
        {
            _body.velocity += Vector3.up * 4f;
        }
		
        Vector3 target_vel = Speed * transform.TransformVector(input);
        vel += (target_vel - vel) * 0.1f;
        if (vel.sqrMagnitude < Speed * 0.01)
        {
            vel = Vector3.zero;
        }
        _body.velocity = Vector3.ProjectOnPlane(vel, Vector3.up) + Vector3.Project(_body.velocity, Vector3.up);
	}
}