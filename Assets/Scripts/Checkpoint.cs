using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
	private void Start()
	{
		var save = new SaveData(SceneManager.GetActiveScene().name);

		string savePath = Path.Combine(Application.persistentDataPath, "game.sav");
		if (File.Exists(savePath)) File.Delete(savePath);

		var formatter = new BinaryFormatter();
		FileStream saveFile = File.Create(savePath);
		formatter.Serialize(saveFile, save);

		saveFile.Close();
	}
}