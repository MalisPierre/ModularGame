using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

#endif

public partial class ContentLoader {

#if UNITY_EDITOR


	public static GameObject GetElementInEditor(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "Assets/Contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".prefab";
		return Bundle.GetElementInEditor(FilePath);
	}

    public static Texture2D GetTextureInEditor(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "Assets/Contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".png";
		return Bundle.GetTextureInEditor(FilePath);
	}


	public static string GetScriptInEditor(string BasePath)
	{
		string[] Sep = BasePath.Split (':');
		string ContentPath = Sep [0];
		string BundlePath = Sep [1];
		string FilePath = "assets/contents/" + ContentPath + "/" + BundlePath + "/" + Sep [2] + ".txt";
		return Bundle.LoadScriptInEditor (FilePath);
	}

#endif
}
