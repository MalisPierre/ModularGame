using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBuilderWindows {


	public static string GetDataFolder()
	{
		return System.IO.Path.Combine (Application.dataPath, "../Data");
	}

	public static string GetAssetsFolder()
	{
		return "Assets";
	}

	public static string GetConfigFolder()
	{
		return System.IO.Path.Combine (Application.dataPath, "../Config");
	}

	public static string GetSaveFolder()
	{
		return System.IO.Path.Combine (Application.dataPath, "../Save");
	}


}
