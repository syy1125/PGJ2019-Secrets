using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
	public static string SavePath => Path.Combine(Application.persistentDataPath, "game.sav");
	
	private void Start()
	{
		var save = new SaveData(SceneManager.GetActiveScene().name);

		if (File.Exists(SavePath)) File.Delete(SavePath);

		var formatter = new BinaryFormatter();
		FileStream saveFile = File.Create(SavePath);
		formatter.Serialize(saveFile, save);

		saveFile.Close();
	}
}