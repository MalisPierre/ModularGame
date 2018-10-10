using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBuilderAndroid {


	public static string GetDataFolder()
	{
		return System.IO.Path.Combine (Application.persistentDataPath, "Data");
	}

	public static string GetAssetsFolder()
	{
		return "Assets";
	}

	public static string GetConfigFolder()
	{
		return System.IO.Path.Combine (Application.persistentDataPath, "Config");
	}

	public static string GetSaveFolder()
	{
		return System.IO.Path.Combine (Application.persistentDataPath, "Save");
	}

}
