using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class ResumeGame : MonoBehaviour
{
	public SceneTransition Transition;

	private SaveData _save;

	private void Start()
	{
		if (File.Exists(Checkpoint.SavePath))
		{
			using (FileStream saveFile = File.OpenRead(Checkpoint.SavePath))
			{
				var formatter = new BinaryFormatter();
				_save = (SaveData) formatter.Deserialize(saveFile);
				GetComponent<Button>().interactable = true;

				return;
			}
		}

		GetComponent<Button>().interactable = false;
	}

	public void Resume()
	{
		Debug.Assert(_save != null);
		Transition.Transition(_save.LevelName);
	}
}