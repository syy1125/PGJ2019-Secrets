using System.IO;
using UnityEngine;

public class SecretRoom : MonoBehaviour
{
	public static string SecretPath => Path.Combine(Application.persistentDataPath, "secret.sav");
	
	private void Start()
	{
		if (!File.Exists(SecretPath))
		{
			File.Create(SecretPath).Dispose();
		}
	}
}