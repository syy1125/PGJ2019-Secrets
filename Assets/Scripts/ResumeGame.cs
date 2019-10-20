using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class ResumeGame : MonoBehaviour
{
	public SceneTransition Transition;
	
	private SaveData _save;

	private void Start()
	{
		string savePath = Path.Combine(Application.persistentDataPath, "game.sav");
		
		if (File.Exists(savePath))
		{
			try
			{
				FileStream saveFile = File.OpenRead(savePath);
				var formatter = new BinaryFormatter();
				_save = (SaveData) formatter.Deserialize(saveFile);
				GetComponent<Button>().interactable = true;

				return;
			}
			catch
			{}
		}

		GetComponent<Button>().interactable = false;
	}

	public void Resume()
	{
		Debug.Assert(_save != null);
		Transition.Transition(_save.LevelName);
	}
}