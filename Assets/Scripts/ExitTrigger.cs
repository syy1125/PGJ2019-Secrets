using UnityEngine;
using UnityEngine.Events;

public class ExitTrigger : MonoBehaviour
{
	public GameObject Player;
	public UnityEvent OnExit;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == Player)
		{
			OnExit.Invoke();
		}
	}
}