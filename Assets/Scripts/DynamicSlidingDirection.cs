using System.Collections;
using UnityEngine;

public class DynamicSlidingDirection : MonoBehaviour
{
	public void HandlePlacement(RaycastHit hit)
	{
		GetComponent<SlidingDoor>().Offset = -Vector3.Scale(hit.normal, transform.lossyScale);
	}
}