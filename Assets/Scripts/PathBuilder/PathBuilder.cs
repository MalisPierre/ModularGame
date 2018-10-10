using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public partial class PathBuilder {


	public static string BuildPath(string s1, string s2)
	{
		return System.IO.Path.Combine (s1, s2);
	}

	public static string GetContentFromPath(string FileName)
	{
		if (FileName.Contains (":") == false)
			Debug.LogError ("Error ! {" + FileName + "} Does not specify the Content Name ! ! !");
		return FileName.Split (':')[0];
	}

	public static string GetFileFromPath(string FileName)
	{
		if (FileName.Contains (":") == false)
			Debug.LogError ("Error ! {" + FileName + "} Does not specify the Content Name ! ! !");
		return FileName.Split(':')[1];
	}

	public static string GetAssetsFolder()
	{
		switch (Application.platform)
		{
		case RuntimePlatform.WindowsPlayer:
			return PathbuilderEditor.GetAssetsFolder();

		case RuntimePlatform.WindowsEditor:
			return PathBuilderWindows.GetAssetsFolder();

		case RuntimePlatform.Android:
			return PathBuilderAndroid.GetAssetsFolder();

		default:
			return PathbuilderEditor.GetAssetsFolder();
		}
	}

	public static string GetDataFolder()
	{
		switch (Application.platform)
		{
		case RuntimePlatform.WindowsPlayer:
			return PathbuilderEditor.GetDataFolder();

		case RuntimePlatform.WindowsEditor:
			return PathBuilderWindows.GetDataFolder();

		case RuntimePlatform.Android:
			return PathBuilderAndroid.GetDataFolder();

		default:
			return PathbuilderEditor.GetDataFolder();
		}
	}

	public static string GetConfigFolder()
	{
		switch (Application.platform)
		{
		case RuntimePlatform.WindowsPlayer:
			return PathbuilderEditor.GetConfigFolder();

		case RuntimePlatform.WindowsEditor:
			return PathBuilderWindows.GetConfigFolder();

		case RuntimePlatform.Android:
			return PathBuilderAndroid.GetConfigFolder();

		default:
			return PathbuilderEditor.GetConfigFolder();
		}

	}

	public static string GetSaveFolder()
	{
		switch (Application.platform)
		{
		case RuntimePlatform.WindowsPlayer:
			return PathbuilderEditor.GetSaveFolder();

		case RuntimePlatform.WindowsEditor:
			return PathBuilderWindows.GetSaveFolder();

		case RuntimePlatform.Android:
			return PathBuilderAndroid.GetSaveFolder();

		default:
			return PathbuilderEditor.GetSaveFolder();
		}

	}

}