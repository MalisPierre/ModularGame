using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathbuilderEditor {


	public static string GetDataFolder()
	{
		//Debug.Log ("Path Builder Editor Get Data");
		return System.IO.Path.Combine (Application.dataPath, "../Data");
	}

	public static string GetAssetsFolder()
	{
		return "Assets";
	}

	public static string GetConfigFolder()
	{
		//Debug.Log ("Path Builder Editor Get Config");
		return System.IO.Path.Combine (Application.dataPath, "../Config");
	}

	public static string GetSaveFolder()
	{
		return System.IO.Path.Combine (Application.dataPath, "../Save");
	}


}
