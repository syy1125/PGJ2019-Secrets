using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
	public static bool Paused;
	private CanvasGroup _group;
	public PlayerLook Look;
	public SceneTransition Transition;
	
	private void Start()
	{
		_group = GetComponent<CanvasGroup>();
	}

	private void Update()
	{
		if (!Input.GetKeyDown(KeyCode.Escape)) return;
		
		if (Paused)
		{
			Resume();
		}
		else
		{
			Pause();
		}
	}

	public void Resume()
	{
		Paused = false;
		Time.timeScale = 1;
		_group.alpha = 0;
		_group.interactable = false;
		_group.blocksRaycasts = false;
		Look.enabled = true;
	}

	public void Pause()
	{
		Paused = true;
		Time.timeScale = 0;
		_group.alpha = 1;
		_group.interactable = true;
		_group.blocksRaycasts = true;
		Look.enabled = false;
	}

	public void RestartLevel()
	{
		Resume();
		Transition.GetComponent<AudioSource>().enabled = false;
		Transition.Transition(SceneManager.GetActiveScene().name);
	}

	public void MainMenu()
	{
		Resume();
		Transition.GetComponent<AudioSource>().enabled = false;
		Transition.Transition("Main Menu");
	}

	private void OnDestroy()
	{
		Paused = false;
	}
}