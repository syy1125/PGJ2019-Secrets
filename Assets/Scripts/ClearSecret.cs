using System.IO;
using UnityEngine;

public class ClearSecret : MonoBehaviour
{
	public void ResetSecret()
	{
		if (File.Exists(SecretRoom.SecretPath))
		{
			File.Delete(SecretRoom.SecretPath);
		}
	}
}