using System;
using UnityEngine;

[Serializable]
public class SaveData
{
	[SerializeField]
	public string LevelName;

	public SaveData(string levelName)
	{
		LevelName = levelName;
	}
}