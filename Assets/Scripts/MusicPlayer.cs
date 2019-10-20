using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	private static MusicPlayer _instance;

	private void Start()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (_instance != this)
		{
			Destroy(gameObject);
		}
	}

	private void OnDestroy()
	{
		if (_instance == this)
		{
			_instance = null;
		}
	}
}