using System;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class RandomButtonPlacer : MonoBehaviour
{
	[Header("References")]
	public Transform Button;
	public GameObject[] Prohibited;

	[Header("Config")]
	[Range(0,1)]
	public float SinkFactor;
	public float ScaleFactor;

	private void Start()
	{
		RaycastHit hit;
		while (
			!Physics.Raycast(Vector3.zero, Random.onUnitSphere, out hit)
			|| Array.Exists(Prohibited, obj => obj == hit.collider.gameObject)
			) ;

		Button.localScale *= ScaleFactor;
		Button.position = hit.point - Vector3.Scale(hit.normal, Button.lossyScale) * 0.5f * SinkFactor;
		hit.normal.Normalize();
		Button.GetComponent<BoxCollider>().size = new Vector3(
			2 - Mathf.Abs(hit.normal.x),
			2 - Mathf.Abs(hit.normal.y),
			2 - Mathf.Abs(hit.normal.z)
		);
	}
}