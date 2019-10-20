using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SecretComment : MonoBehaviour
{
	[TextArea]
	public string ReplaceText;

	private void Start()
	{
		if (File.Exists(SecretRoom.SecretPath))
		{
			GetComponent<Text>().text = ReplaceText;
		}
	}
}