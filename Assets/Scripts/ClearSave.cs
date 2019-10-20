using System.IO;
using UnityEngine;

public class ClearSave : MonoBehaviour
{
	public void ResetSave()
	{
		if (File.Exists(Checkpoint.SavePath))
		{
			File.Delete(Checkpoint.SavePath);
		}
		if (File.Exists(SecretRoom.SecretPath))
		{
			File.Delete(SecretRoom.SecretPath);
		}
	}
}