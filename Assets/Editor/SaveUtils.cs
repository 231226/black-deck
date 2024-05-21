using System.IO;
using UnityEditor;
using UnityEngine;

public static class SaveUtils
{
	private const string FileName = "gameSave.json";

	[MenuItem("Tools/Player Save/Delete JSON Save File")]
	private static void DeleteJsonSaveFile()
	{
		if (File.Exists(Path.Combine(Application.persistentDataPath, FileName)))
		{
			File.Delete(Path.Combine(Application.persistentDataPath, FileName));
		}
	}
}